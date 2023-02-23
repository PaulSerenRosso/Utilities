using System.Collections;
using System.Collections.Generic;
using Unity.Services.RemoteConfig;
using UnityEngine;

namespace HelperPSR.RemoteConfigs

{
    // fps
    // report de bug 
    // remote config
public class RemoteConfigValuesLinker
{
    protected RuntimeConfig config;
    public RemoteConfigValuesLinker()
    {
        config =RemoteConfigService.Instance.appConfig;
    }
  
}
}
