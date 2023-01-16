using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    public class MonoSingleton<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        private static T instance;
        public static T Instance => instance = instance == null || ReferenceEquals(instance, null) ? FindObjectOfType<T>() : instance;
    }
}