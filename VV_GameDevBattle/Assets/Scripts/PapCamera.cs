using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PapCamera : MonoBehaviour
{
    public float delay = 1f;
    public UnityEvent onTakePicture;
    public UnityEvent onPlayerInRange;
    public UnityEvent onPlayerExitRange;
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
            //Debug.Log("Player In Range");
            onPlayerInRange?.Invoke();
            StartCoroutine(TakePicture(other.transform));
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player Out of Range");
            target = null;
            onPlayerExitRange?.Invoke();
        }
    }


    private IEnumerator TakePicture(Transform subject)
    {
        yield return new WaitForSeconds(delay);
        if (!enabled) yield return null;
        subject.SendMessage("OnHit", SendMessageOptions.RequireReceiver);
        onTakePicture.Invoke();
        yield return null;
        print("Picture Taken!");
    }
}
