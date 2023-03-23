using System;
using System.Collections.Generic;
using UnityEngine;

namespace HelperPSR.MonoLoopFunctions
{
    public abstract class MonoLoopFunctionsManager<I> : MonoBehaviour where I : class
    {
        static private HashSet<I> IMonoLoopFunctions = new();

        private static HashSet<I> toAdded = new();

        private static HashSet<I> toRemoved = new();

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        // Start is called before the first frame update
        static public void Register(I mono)
        {
            toAdded.Add(mono);
        }

        static public void UnRegister(I mono)
        {
            toRemoved.Add(mono);
        }

        public void LaunchLoop()
        {
            HashSet<I>.Enumerator e = IMonoLoopFunctions.GetEnumerator();
            while (e.MoveNext())
            {
                UpdateElement(e);
            }

            e.Dispose();

              if (toRemoved.Count != 0)
              {
                  foreach (var element in toRemoved)
                  {
                      IMonoLoopFunctions.Remove(element);
                  }
                  toRemoved.Clear();
              }
              if (toAdded.Count != 0)
              {
                  foreach (var element in toAdded)
                  {
                      IMonoLoopFunctions.Add(element);
                  }
                  toAdded.Clear();
              }
        }

        abstract public void UpdateElement(HashSet<I>.Enumerator e);
    }
}