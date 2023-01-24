﻿using System.Collections.Generic;

namespace HelperPSR.MonoLoopFunctions
{
    public class FixedUpdateManager : MonoLoopFunctionsManager<IFixedUpdate>
    { 
        public override void UpdateElement(HashSet<IFixedUpdate>.Enumerator e)
        {
            e.Current.OnFixedUpdate();
        }
        private void FixedUpdate()
        {
            LaunchLoop();
        }
    }
}
