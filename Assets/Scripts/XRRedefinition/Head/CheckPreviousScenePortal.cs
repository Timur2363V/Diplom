using UnityEngine;

namespace Assets.Scripts.XRRedefinition.Head
{
    public class CheckPreviousScenePortal : MonoBehaviour
    {
        [SerializeField]
        private ScenePortalPair scenePortalPairDefault;
        [SerializeField]
        private ScenePortalPair[] scenePortalPairs;

        //private void Awake()
        //{
        //    if (SceneLoader.PreviousSceneName == null || SceneLoader.PreviousSceneName == scenePortalPairDefault.SceneName)
        //    {
        //        Teleport(scenePortalPairDefault);
        //    }

        //    for (int i = 0; i < scenePortalPairs.Length; i++)
        //    {
        //        if (scenePortalPairs[i].SceneName == SceneLoader.PreviousSceneName)
        //        {
        //            Teleport(scenePortalPairs[i]);
        //            return;
        //        }
        //    }
        //}

        private void Teleport(ScenePortalPair scenePortalPair)
        {
            var origin = XRROrigin.Instance;
            var portal = scenePortalPair.Portal;
            var nextPosition = origin.transform.position + portal.position - origin.CameraOrigin.transform.position;
            nextPosition.y = portal.position.y;
            origin.transform.position = nextPosition;
            origin.transform.rotation = portal.rotation;
            scenePortalPair.AwakeEvent.Invoke();
        }
    }
}