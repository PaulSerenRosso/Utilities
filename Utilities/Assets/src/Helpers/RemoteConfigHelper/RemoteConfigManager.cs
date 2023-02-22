using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.RemoteConfig;
using UnityEngine;


namespace HelperPSR.RemoteConfig
{
    public class RemoteConfigManager : MonoBehaviour
    {

        [SerializeField] private bool _isUpdatedRemoteConfigurables;
        private static HashSet<IRemoteConfigurable> _currentRemoteConfigurables = new HashSet<IRemoteConfigurable>();
        public RemoteConfigValuesLinker Linker
        {
            get => _linker;
        }
        private RemoteConfigValuesLinker _linker = new RemoteConfigValuesLinker();
        private struct userAttributes
        {
        }

        private struct appAttributes
        {
        }

        /// <summary>
        /// Method called before the start of the game
        /// </summary>
        private async void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (Utilities.CheckForInternetConnection()) await InitializeRemoteConfigAsync();

            RemoteConfigService.Instance.FetchCompleted += UpdateCurrentRemoteConfigurables;
            CallFetch();
        }

        private void UpdateCurrentRemoteConfigurables(ConfigResponse configResponse)
        {
            if (configResponse.requestOrigin != ConfigOrigin.Remote) return; 
            if(!_isUpdatedRemoteConfigurables) return;
            foreach (var configurable in _currentRemoteConfigurables)
            {
                configurable.SetRemoteConfigurableValues();
            }
        }

        /// <summary>
        /// Async Method which allow to wait for connection before doing something else
        /// </summary>
        private async Task InitializeRemoteConfigAsync()
        {
            await UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }
        }

        /// <summary>
        /// Method which call the appConfig to retrieve all the data and be able to update the value
        /// </summary>
        public static void CallFetch() => RemoteConfigService.Instance.FetchConfigs(new userAttributes(), new appAttributes());

        public static void RegisterRemoteConfigurable(IRemoteConfigurable remoteConfigurable)
        {
            _currentRemoteConfigurables.Add(remoteConfigurable);
            remoteConfigurable.SetRemoteConfigurableValues();
        }

        public static void UnRegisterRemoteConfigurable(IRemoteConfigurable remoteConfigurable)
        {
            _currentRemoteConfigurables.Remove(remoteConfigurable);
        }
        
    }
}
