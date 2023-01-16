using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.XRRedefinition.Head
{
    [Serializable]
    public class ScenePortalPair
    {
        [SerializeField]
        private UnityEvent awakeEvent;
        [SerializeField]
        private Transform portal;
        [SerializeField]
        private string sceneName;

        public UnityEvent AwakeEvent => awakeEvent;
        public Transform Portal => portal;
        public string SceneName => sceneName;
    }
}