using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    public class ObjectSelectionXR : MonoBehaviour
    {
        [SerializeField]
        private Transform attach;

        public Transform Attach => attach;

        private void Awake()
        {
            if (attach == null)
            {
                attach = transform;
            }
        }
    }
}