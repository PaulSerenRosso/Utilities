using UnityEngine;

namespace HelperPSR.Singletons
{
 public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
 {
  public static T instance;

  protected virtual void Awake()
  {
   if (instance == null)
    instance = this as T;
   else Destroy(gameObject);
  }
 }
}
