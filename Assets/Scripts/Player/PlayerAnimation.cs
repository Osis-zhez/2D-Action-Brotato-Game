using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;

    private void Start() 
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();    
    }

    private void Update()
    {
        animator.SetBool("isMove", playerMovement.GetIsMove());
    }
}
