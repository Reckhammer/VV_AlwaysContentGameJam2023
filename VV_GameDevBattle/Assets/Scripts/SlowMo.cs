using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowMo : MonoBehaviour
{
    public float duration = 1f;
    public float factor = 1f;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Activate(other.transform));
        }
    }

    public IEnumerator Activate(Transform subject)
    {
        var speed = subject.GetComponent<NavMeshAgent>().speed;
        subject.GetComponent<NavMeshAgent>().speed = speed * factor;
        yield return new WaitForSeconds(duration);
        subject.GetComponent<NavMeshAgent>().speed = speed;
        yield return null;
    }
}
