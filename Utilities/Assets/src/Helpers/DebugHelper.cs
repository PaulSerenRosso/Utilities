using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelperPSR.Debug
{
public static class DebugHelper
{
 public static float GetFrameRate()
 {
     return 1 / Time.deltaTime;
 }
}
    
}
