using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSwing : MonoBehaviour
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
        var coolDown = subject.GetComponent<Bat>().coolDown;
        subject.GetComponent<Bat>().coolDown = 0;
        yield return new WaitForSeconds(duration);
        subject.GetComponent<Bat>().coolDown = coolDown;
        yield return null;
    }
}
