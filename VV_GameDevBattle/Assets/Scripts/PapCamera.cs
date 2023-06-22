using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PapCamera : MonoBehaviour
{
    public float delay = 1f;
    public UnityEvent onTakePicture;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TakePicture(other.transform));
        }
    }

    private IEnumerator TakePicture(Transform subject)
    {
        yield return new WaitForSeconds(delay);
        subject.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);
        onTakePicture.Invoke();
        yield return null;
        print("Picture Taken!");
    }
}
