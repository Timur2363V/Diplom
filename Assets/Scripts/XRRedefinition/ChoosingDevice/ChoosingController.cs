using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    [RequireComponent(typeof(ControllerInteractor))]
    public class ChoosingController : MonoBehaviour
    {
        [SerializeField]
        private ChoosingDeviceModelSubname[] deviceSubNames;

        private void Awake()
        {
            ChooseDevice();
        }

        private void ChooseDevice()
        {
            for (int i = 0; i < deviceSubNames.Length; i++)
            {
                if (SystemInfo.deviceName.Contains(deviceSubNames[i].SubName))
                {
                    var objectSelection = Instantiate(deviceSubNames[i].Device, transform);
                    var interactors = GetComponents<ControllerInteractor>();

                    for (int j = 0; j < interactors.Length; j++)
                    {
                        interactors[j].attach = objectSelection.Attach;
                    }

                    return;
                }
            }
        }
    }
}