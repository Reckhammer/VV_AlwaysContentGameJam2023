using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Bat : MonoBehaviour
{
    public Collider hurtbox;
    public float hurtboxDuration = 1f;
    public float coolDown = 1f;
    public UnityEvent onAttack;
    private float coolDownTime;

    private void Start()
    {
        hurtbox.enabled = false;
        coolDownTime = coolDown;
    }

    private void Update()
    {
        coolDownTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Bat has touched an Enemy");
            other.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Attack()
    {
        if (coolDownTime < coolDown)
        {
            return;
        }
        StartCoroutine(UpdateHurtbox());
        onAttack.Invoke();
        coolDownTime = 0;
    }

    public IEnumerator UpdateHurtbox()
    {
        hurtbox.enabled = true;
        yield return new WaitForSeconds(hurtboxDuration);
        hurtbox.enabled = false;
        yield return null;
    }

}
