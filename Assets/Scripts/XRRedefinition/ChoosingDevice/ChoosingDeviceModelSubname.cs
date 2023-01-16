using System;
using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    [Serializable]
    public class ChoosingDeviceModelSubname
    {
        [SerializeField]
        private ObjectSelectionXR device;
        [SerializeField]
        private string subName;

        public ObjectSelectionXR Device => device;
        public string SubName => subName;
    }
}