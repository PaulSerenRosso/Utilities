﻿using System.Collections.Generic;

namespace HelperPSR.MonoLoopFunctions
{
    public class OnPostRenderManager : MonoLoopFunctionsManager<IOnPostRender>
    {
        public override void UpdateElement(HashSet<IOnPostRender>.Enumerator e)
        {
            e.Current.OnPostRender();
        }

        private void OnPostRender()
        {
            LaunchLoop();
        }
    }
}
