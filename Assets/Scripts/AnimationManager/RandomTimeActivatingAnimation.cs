using System.Collections;
using UnityEngine;
using Assets.Scripts.XRRedefinition;

public class RandomTimeActivatingAnimation : MonoBehaviour
{
    [SerializeField]
    private Animation anim;
    [SerializeField]
    private float randomTimeWaitAnimation = 2f;

    private void Awake()
    {
        StartCoroutine(WaitAndInvokeAnimation());
    }

    private IEnumerator WaitAndInvokeAnimation()
    {
        yield return new WaitForSeconds(Random.Range(0f, randomTimeWaitAnimation));
        anim.Play();
    }

    private void OnValidate()
    {
        this.GetComponent(ref anim);
    }
}
