using UnityEngine;

internal class Class1 : MonoBehaviour
{
    [SerializeField]
    private TestClass testClass;

    private void Awake()
    {
        testClass.Enter();
    }
}
