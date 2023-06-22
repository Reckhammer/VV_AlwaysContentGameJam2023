using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int amount = 1;
    public UnityEvent onHit;
    public UnityEvent onDeath;

    public void OnHit()
    {
        amount--;
        onHit.Invoke();
        if (amount <= 0 )
        {
            onDeath.Invoke();
        }
    }
}
