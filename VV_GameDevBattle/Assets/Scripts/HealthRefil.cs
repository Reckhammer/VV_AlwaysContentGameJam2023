using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRefil : MonoBehaviour
{
    public Transform target;
    public float duration = 1f;
    public void OnHit()
    {
        StartCoroutine(Activate(target));
    }

    public IEnumerator Activate(Transform subject)
    {
        subject.GetComponent<Health>().amount++;
        yield return null;
    }
}
