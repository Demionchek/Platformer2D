using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyState : MonoBehaviour
{
    [SerializeField] private float speed, timeToRevert;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sp;

    private Rigidbody2D rb;
    private const float EnemyIdle = 0;
    private const float EnemyWalk = 1;
    private const float EnemyRevert = 2;
    private float currentState, currentTimeToRevert;

    void Start()
    {
        currentState = EnemyWalk;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeToRevert >= timeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = EnemyRevert;
        }

        switch (currentState)
        {
            case EnemyIdle:
                currentTimeToRevert += Time.deltaTime;
                break;
            case EnemyWalk:
                rb.velocity = Vector2.left * speed;
                break;
            case EnemyRevert:
                sp.flipX = !sp.flipX;
                speed *= -1;
                currentState = EnemyWalk;
                break;
        }

        animator.SetFloat("Velocity", rb.velocity.magnitude);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyState"))
            currentState = EnemyIdle;
    }
}
