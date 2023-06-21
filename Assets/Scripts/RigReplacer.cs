using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
class RigReplacer
{
    [SerializeField]
    MonoBehaviour rig;

    public MonoBehaviour Rig => rig;

    public void Replace(MonoBehaviour rigToFind)
    {
        var rigInScene = MonoBehaviour.FindAnyObjectByType(rigToFind.GetType());
        var rigObject = rigInScene.GameObject();
        var position = rigObject.transform.position;
        var rotation = rigObject.transform.rotation;
        var parent = rigObject.transform.parent;
        MonoBehaviour.DestroyImmediate(rigObject);
        var newRig = MonoBehaviour.Instantiate(rig, position, rotation);
        newRig.transform.parent = parent;
    }
}
