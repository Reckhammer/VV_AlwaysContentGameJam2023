using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;

    public void SetSwing()
    {
        Debug.Log("Play Swing Animation");
        animator.SetTrigger("Swing");
    }

    public void SetPicTaken()
    {
        animator.SetTrigger("PicTaken");
    }
}
