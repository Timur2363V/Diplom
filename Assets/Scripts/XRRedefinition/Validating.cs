using System.Linq;
using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    public static class Validating
    {
        public static void GetComponent<T>(this MonoBehaviour behaviour, ref T component)
            where T : Component
        {
            if (behaviour.TryGetComponent(out T gettingComponent) && component == null)
            {
                component = gettingComponent;
            }
        }

        public static void GetComponents<T>(this MonoBehaviour behaviour, ref T[] component)
            where T : Component
        {
            var components = behaviour.GetComponents<T>();

            if (component == null || component.Length == 0)
            {
                component = components;
            }
        }

        public static void GetComponentInChildren<T>(this MonoBehaviour behaviour, ref T component)
            where T : Component
        {
            var gettingComponent = behaviour.GetComponentInChildren<T>();

            if (gettingComponent != null && component == null)
            {
                component = gettingComponent;
            }
        }

        public static void GetComponentsInChildren<T>(this MonoBehaviour behaviour, ref T component1, ref T component2)
            where T : Component
        {
            var gettingComponents = behaviour.GetComponentsInChildren<T>();

            if (gettingComponents.Length == 2)
            {
                if (gettingComponents[0] != null && component1 == null)
                {
                    component1 = gettingComponents[0];
                }

                if (gettingComponents[1] != null && component2 == null)
                {
                    component2 = gettingComponents[1];
                }
            }
        }

        public static void GetComponentInParent<T>(this MonoBehaviour behaviour, ref T component)
            where T : Component
        {
            var gettingComponent = behaviour.GetComponentInParent<T>();

            if (gettingComponent != null && component == null)
            {
                component = gettingComponent;
            }
        }

        public static void GetAnotherComponent<T>(this T behaviour, ref T component)
            where T : Component
        {
            var components = behaviour.GetComponents<T>();

            if (components.Length > 0)
            {
                component = components.Where(x => x != behaviour).FirstOrDefault();
            }
        }
    }
}