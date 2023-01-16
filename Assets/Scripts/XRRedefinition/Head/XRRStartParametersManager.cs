using System.Collections;
using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    public class XRRStartParametersManager : MonoBehaviour
    {
        [SerializeField]
        private Transform startParameters;
        [SerializeField]
        private float adjustmentTime = 1f;

        private XRROrigin origin;

        private void Awake()
        {
            origin = XRROrigin.Instance;
            StartCoroutine(SetStartParameters());
        }

        private IEnumerator SetStartParameters()
        {
            if (startParameters == null)
            {
                yield break;
            }

            var previousPosition = origin.CameraOrigin.transform.position;

            while (origin.CameraOrigin.transform.position == previousPosition &&
                origin.CameraOrigin.transform.position != Vector3.zero)
            {
                yield return null;
            }


            while (adjustmentTime >= 0f)
            {
                var nextPosition = origin.transform.position + startParameters.position - origin.CameraOrigin.transform.position;
                nextPosition.y = startParameters.position.y;
                origin.transform.position = nextPosition;
                var nextRotation = origin.transform.rotation.eulerAngles + startParameters.rotation.eulerAngles - origin.CameraOrigin.transform.rotation.eulerAngles;
                origin.transform.rotation = Quaternion.Euler(0f, nextRotation.y, 0f);
                yield return new WaitForEndOfFrame();
                adjustmentTime -= Time.deltaTime;
            }
        }

        private void OnValidate() => this.GetComponentInParent(ref origin);
    }
}
