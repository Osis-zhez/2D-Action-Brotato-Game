using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D playerRigidbody;
    private Vector2 moveAmount;
    private bool isMove;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;
        CheckIsMove();
    }

    private void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + moveAmount * Time.fixedDeltaTime);
    }

    public void CheckIsMove()
    {
        if (moveAmount != Vector2.zero)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }
    }

    public bool GetIsMove()
    {
        return isMove;
    }
}
