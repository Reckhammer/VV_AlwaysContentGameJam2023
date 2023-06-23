using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapAnimationController : MonoBehaviour
{
    public Animator animator;

    public void SetPlayerInRange(bool inRange)
    {
        Debug.Log($"Player In Range {inRange} Animation Play");
        animator.SetBool("inRange", inRange);
    }

    public void SetTakePicture()
    {
        Debug.Log("Take Pic Animation Play");
        animator.SetTrigger("TakePic");
    }

    public void SetDeath()
    {
        animator.SetTrigger("Death");
    }

    public void Death()
    {
        StartCoroutine("DeathRoutine");
    }

    private IEnumerator DeathRoutine()
    {
        SetDeath();

        yield return new WaitForSeconds(2f);

        this.gameObject.SetActive(false);
    }
}
