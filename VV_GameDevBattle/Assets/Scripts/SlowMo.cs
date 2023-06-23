using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowMo : MonoBehaviour
{
    public float duration = 1f;
    public float factor = 1f;
    public void OnHit()
    {
        StartCoroutine(Activate());
    }

    public IEnumerator Activate()
    {
        Time.timeScale *= factor;
        yield return new WaitForSeconds(duration);
        Time.timeScale /= factor;
        yield return null;
    }
}
