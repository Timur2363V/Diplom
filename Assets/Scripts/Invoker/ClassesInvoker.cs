using System;
using UnityEngine;

[Serializable]
public abstract class ClassesInvoker<TPortedOpenXR, TPortedSteamVR, TPortedVRTK, TPortedOculus, TPortedPico, TPortedDPVR, TPortedWave, TPortedCardboard> : MonoBehaviour
    where TPortedOpenXR : MonoBehaviour
    where TPortedSteamVR : MonoBehaviour
    where TPortedVRTK : MonoBehaviour
    where TPortedOculus : MonoBehaviour
    where TPortedPico : MonoBehaviour
    where TPortedDPVR : MonoBehaviour
    where TPortedWave : MonoBehaviour
    where TPortedCardboard : MonoBehaviour
{
    [SerializeField]
    protected TPortedOpenXR portedOpenXR;
    [SerializeField]
    protected TPortedSteamVR portedSteamVR;
    [SerializeField]
    protected TPortedVRTK portedVRTK;
    [SerializeField]
    protected TPortedOculus portedOculus;
    [SerializeField]
    protected TPortedPico portedPico;
    [SerializeField]
    protected TPortedDPVR portedDPVR;
    [SerializeField]
    protected TPortedWave portedWave;
    [SerializeField]
    protected TPortedCardboard portedCardboard;

    #region OpenXR
    public virtual void Invoke(TPortedOpenXR preportTypeClass, TPortedSteamVR portedTypeClass) { }
    public virtual void Invoke(TPortedOpenXR preportTypeClass, TPortedVRTK portedTypeClass) { }
    public virtual void Invoke(TPortedOpenXR preportTypeClass, TPortedOculus portedTypeClass) { }
    public virtual void Invoke(TPortedOpenXR preportTypeClass, TPortedPico portedTypeClass) { }
    public virtual void Invoke(TPortedOpenXR preportTypeClass, TPortedDPVR portedTypeClass) { }
    public virtual void Invoke(TPortedOpenXR preportTypeClass, TPortedWave portedTypeClass) { }
    public virtual void Invoke(TPortedOpenXR preportTypeClass, TPortedCardboard portedTypeClass) { }
    #endregion

    #region SteamVR
    public virtual void Invoke(TPortedSteamVR preportTypeClass, TPortedOpenXR portedTypeClass) { }
    public virtual void Invoke(TPortedSteamVR preportTypeClass, TPortedVRTK portedTypeClass) { }
    public virtual void Invoke(TPortedSteamVR preportTypeClass, TPortedOculus portedTypeClass) { }
    public virtual void Invoke(TPortedSteamVR preportTypeClass, TPortedPico portedTypeClass) { }
    public virtual void Invoke(TPortedSteamVR preportTypeClass, TPortedDPVR portedTypeClass) { }
    public virtual void Invoke(TPortedSteamVR preportTypeClass, TPortedWave portedTypeClass) { }
    public virtual void Invoke(TPortedSteamVR preportTypeClass, TPortedCardboard portedTypeClass) { }
    #endregion

    #region VRTK
    public virtual void Invoke(TPortedVRTK preportTypeClass, TPortedOpenXR portedTypeClass) { }
    public virtual void Invoke(TPortedVRTK preportTypeClass, TPortedSteamVR portedTypeClass) { }
    public virtual void Invoke(TPortedVRTK preportTypeClass, TPortedOculus portedTypeClass) { }
    public virtual void Invoke(TPortedVRTK preportTypeClass, TPortedPico portedTypeClass) { }
    public virtual void Invoke(TPortedVRTK preportTypeClass, TPortedDPVR portedTypeClass) { }
    public virtual void Invoke(TPortedVRTK preportTypeClass, TPortedWave portedTypeClass) { }
    public virtual void Invoke(TPortedVRTK preportTypeClass, TPortedCardboard portedTypeClass) { }
    #endregion

    #region Oculus
    public virtual void Invoke(TPortedOculus preportTypeClass, TPortedOpenXR portedTypeClass) { }
    public virtual void Invoke(TPortedOculus preportTypeClass, TPortedSteamVR portedTypeClass) { }
    public virtual void Invoke(TPortedOculus preportTypeClass, TPortedVRTK portedTypeClass) { }
    public virtual void Invoke(TPortedOculus preportTypeClass, TPortedPico portedTypeClass) { }
    public virtual void Invoke(TPortedOculus preportTypeClass, TPortedDPVR portedTypeClass) { }
    public virtual void Invoke(TPortedOculus preportTypeClass, TPortedWave portedTypeClass) { }
    public virtual void Invoke(TPortedOculus preportTypeClass, TPortedCardboard portedTypeClass) { }
    #endregion

    #region Pico
    public virtual void Invoke(TPortedPico preportTypeClass, TPortedOpenXR portedTypeClass) { }
    public virtual void Invoke(TPortedPico preportTypeClass, TPortedSteamVR portedTypeClass) { }
    public virtual void Invoke(TPortedPico preportTypeClass, TPortedVRTK portedTypeClass) { }
    public virtual void Invoke(TPortedPico preportTypeClass, TPortedOculus portedTypeClass) { }
    public virtual void Invoke(TPortedPico preportTypeClass, TPortedDPVR portedTypeClass) { }
    public virtual void Invoke(TPortedPico preportTypeClass, TPortedWave portedTypeClass) { }
    public virtual void Invoke(TPortedPico preportTypeClass, TPortedCardboard portedTypeClass) { }
    #endregion

    #region DPVR
    public virtual void Invoke(TPortedDPVR preportTypeClass, TPortedOpenXR portedTypeClass) { }
    public virtual void Invoke(TPortedDPVR preportTypeClass, TPortedSteamVR portedTypeClass) { }
    public virtual void Invoke(TPortedDPVR preportTypeClass, TPortedVRTK portedTypeClass) { }
    public virtual void Invoke(TPortedDPVR preportTypeClass, TPortedOculus portedTypeClass) { }
    public virtual void Invoke(TPortedDPVR preportTypeClass, TPortedPico portedTypeClass) { }
    public virtual void Invoke(TPortedDPVR preportTypeClass, TPortedWave portedTypeClass) { }
    public virtual void Invoke(TPortedDPVR preportTypeClass, TPortedCardboard portedTypeClass) { }
    #endregion

    #region Wave
    public virtual void Invoke(TPortedWave preportTypeClass, TPortedOpenXR portedTypeClass) { }
    public virtual void Invoke(TPortedWave preportTypeClass, TPortedSteamVR portedTypeClass) { }
    public virtual void Invoke(TPortedWave preportTypeClass, TPortedVRTK portedTypeClass) { }
    public virtual void Invoke(TPortedWave preportTypeClass, TPortedOculus portedTypeClass) { }
    public virtual void Invoke(TPortedWave preportTypeClass, TPortedPico portedTypeClass) { }
    public virtual void Invoke(TPortedWave preportTypeClass, TPortedDPVR portedTypeClass) { }
    public virtual void Invoke(TPortedWave preportTypeClass, TPortedCardboard portedTypeClass) { }
    #endregion

    #region Cardboard
    public virtual void Invoke(TPortedCardboard preportTypeClass, TPortedOpenXR portedTypeClass) { }
    public virtual void Invoke(TPortedCardboard preportTypeClass, TPortedSteamVR portedTypeClass) { }
    public virtual void Invoke(TPortedCardboard preportTypeClass, TPortedVRTK portedTypeClass) { }
    public virtual void Invoke(TPortedCardboard preportTypeClass, TPortedOculus portedTypeClass) { }
    public virtual void Invoke(TPortedCardboard preportTypeClass, TPortedPico portedTypeClass) { }
    public virtual void Invoke(TPortedCardboard preportTypeClass, TPortedDPVR portedTypeClass) { }
    public virtual void Invoke(TPortedCardboard preportTypeClass, TPortedWave portedTypeClass) { }
    #endregion

    private void Invoke<TPreport, TPorted>(Action<TPreport, TPorted> action, TPorted portedClass)
        where TPreport : MonoBehaviour
        where TPorted : MonoBehaviour
    {
        if (typeof(TPreport).Name == "MonoBehaviour")
            return;
        
        var preportClasses = FindObjectsOfType<TPreport>();
        Debug.Log(typeof(TPorted).Name);
        if (typeof(TPorted).Name == "MonoBehaviour")
        {
            for (int i = 0; i < preportClasses.Length; i++)
            {
                DestroyImmediate(preportClasses[i]);
            }
        }
        else
        {
            for (int i = 0; i < preportClasses.Length; i++)
            {
                var GO = preportClasses[i].gameObject;
                var ported = GO.AddComponent<TPorted>();
                MonoBehaviourCopy.GetCopyOf(ported, portedClass);
                action.Invoke(preportClasses[i], ported);
                DestroyImmediate(preportClasses[i]);
            }
        }
    }

    public void Invoke(VRSystem preportSystem, VRSystem portSystem)
    {
        switch (preportSystem)
        {
            case VRSystem.OpenXR:
                InvokePreportSystem<TPortedOpenXR>(portSystem, null, Invoke, Invoke, Invoke, Invoke, Invoke, Invoke, Invoke);
                break;
            case VRSystem.SteamVR:
                InvokePreportSystem<TPortedSteamVR>(portSystem, Invoke, null, Invoke, Invoke, Invoke, Invoke, Invoke, Invoke);
                break;
            case VRSystem.VRTK:
                InvokePreportSystem<TPortedVRTK>(portSystem, Invoke, Invoke, null, Invoke, Invoke, Invoke, Invoke, Invoke);
                break;
            case VRSystem.OculusIntergration:
                InvokePreportSystem<TPortedOculus>(portSystem, Invoke, Invoke, Invoke, null, Invoke, Invoke, Invoke, Invoke);
                break;
            case VRSystem.PicoIntergration:
                InvokePreportSystem<TPortedPico>(portSystem, Invoke, Invoke, Invoke, Invoke, null, Invoke, Invoke, Invoke);
                break;
            case VRSystem.DPVRSDK:
                InvokePreportSystem<TPortedDPVR>(portSystem, Invoke, Invoke, Invoke, Invoke, Invoke, null, Invoke, Invoke);
                break;
            case VRSystem.WaveXR:
                InvokePreportSystem<TPortedWave>(portSystem, Invoke, Invoke, Invoke, Invoke, Invoke, Invoke, null, Invoke);
                break;
            default:
                InvokePreportSystem<TPortedCardboard>(portSystem, Invoke, Invoke, Invoke, Invoke, Invoke, Invoke, Invoke, null);
                break;
        }
    }

    private void InvokePreportSystem<TPreport>(VRSystem portSystem, 
        Action<TPreport, TPortedOpenXR> actionOpenXR, Action<TPreport, TPortedSteamVR> actionSteamVR, Action<TPreport, TPortedVRTK> actionVRTK, Action<TPreport, TPortedOculus> actionOculus,
        Action<TPreport, TPortedPico> actionPico, Action<TPreport, TPortedDPVR> actionDPVR, Action<TPreport, TPortedWave> actionWave, Action<TPreport, TPortedCardboard> actionCardboard)
    where TPreport : MonoBehaviour
    {
        switch (portSystem)
        {
            case VRSystem.OpenXR:
                Invoke(actionOpenXR, portedOpenXR);
                break;
            case VRSystem.SteamVR:
                Invoke(actionSteamVR, portedSteamVR);
                break;
            case VRSystem.VRTK:
                Invoke(actionVRTK, portedVRTK);
                break;
            case VRSystem.OculusIntergration:
                Invoke(actionOculus, portedOculus);
                break;
            case VRSystem.PicoIntergration:
                Invoke(actionPico, portedPico);
                break;
            case VRSystem.DPVRSDK:
                Invoke(actionDPVR, portedDPVR);
                break;
            case VRSystem.WaveXR:
                Invoke(actionWave, portedWave);
                break;
            default:
                Invoke(actionCardboard, portedCardboard);
                break;
        }
    }
}
