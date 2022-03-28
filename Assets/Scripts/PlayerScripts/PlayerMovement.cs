using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool is_grounded;
    [SerializeField] private bool isInWater;
    [SerializeField] private float speed;

    [Header("Settings")]
    [SerializeField] private float jumpOffset;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask waterMask;

    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        is_grounded = false;
        isInWater = false;
    }

    private void FixedUpdate()
    {
        Vector3 overlapCircleTransform = groundColliderTransform.position;
        is_grounded = Physics2D.OverlapCircle(overlapCircleTransform, jumpOffset, groundMask);
        isInWater = Physics2D.OverlapCircle(overlapCircleTransform, jumpOffset, waterMask);
    }

    public void Move(float direction, bool is_jumpButtonPressed)
    {
        if (is_jumpButtonPressed)
        {
            animator.SetTrigger("Jump");
            Jump();
        }

        if (Mathf.Abs(direction) > 0.01f)
        {
            animator.SetBool("Run", true);
            HorizontalMovement(direction);
        }
        else animator.SetBool("Run", false);
    }

    private void Jump()
    {
        if (is_grounded || isInWater)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(curve.Evaluate(direction) ,rb.velocity.y);
    }
}
