using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnimations
{
    [SerializeField] Animator animator;

    public void StartRunning()
    {
        animator.SetBool("Running", true);
    }

    public void StopRunning()
    {
        animator.SetBool("Running", false);
    }
}
