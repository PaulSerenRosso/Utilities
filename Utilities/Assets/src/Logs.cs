using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public static class Logs
{
  [Conditional("DEBUG")]
  public static void Log(string log)
  {
    Debug.Log(log);
  }
}
