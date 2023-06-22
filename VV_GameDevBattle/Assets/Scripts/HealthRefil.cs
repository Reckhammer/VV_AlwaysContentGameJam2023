using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRefil : MonoBehaviour
{
    public float duration = 1f;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Activate(other.transform));
        }
    }

    public IEnumerator Activate(Transform subject)
    {
        subject.GetComponent<Health>().amount++;
        yield return null;
    }
}
