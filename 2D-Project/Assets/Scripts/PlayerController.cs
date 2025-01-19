using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 input;
    private Vector2 lastInput = Vector2.down;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleInput();
        HandleAnimation();
    }

    private void FixedUpdate()
    {
        HandleMove();
    }

    private void HandleInput()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        input = new Vector2(inputX, inputY);

        if (input != Vector2.zero)
        {
            lastInput = input;
            animator.SetFloat("LastInputX", lastInput.x);
            animator.SetFloat("LastInputY", lastInput.y);
        }
    }

    private void HandleMove()
    {
        rb.velocity = input.normalized * moveSpeed;
    }

    private void HandleAnimation()
    {
        animator.SetFloat("MoveX", input.x);
        animator.SetFloat("MoveY", input.y);

        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
    }
}
