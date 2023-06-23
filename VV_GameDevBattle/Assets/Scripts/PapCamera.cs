using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PapCamera : MonoBehaviour
{
    public float delay = 1f;
    public UnityEvent onTakePicture;
    private Transform target;

    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TakePicture(other.transform));
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            target = null;
        }
    }


    private IEnumerator TakePicture(Transform subject)
    {
        yield return new WaitForSeconds(delay);
        subject.SendMessage("OnHit", SendMessageOptions.RequireReceiver);
        onTakePicture.Invoke();
        yield return null;
        print("Picture Taken!");
    }
}
