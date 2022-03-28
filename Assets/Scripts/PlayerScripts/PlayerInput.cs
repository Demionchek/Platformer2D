using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(Animator))]

public class PlayerInput : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    private Shooter shooter;
    private float lastDir;
    private bool isFinished;

    public delegate void PlayerAction();
    public static event PlayerAction ShootEvent;
    public static event PlayerAction JumpEvent;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
        animator = GetComponent<Animator>();
        lastDir = 1f;
        isFinished = false;
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HorizontalAxis);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.Jump);

        if (isJumpButtonPressed)
        {
            JumpEvent();
        }

        if (horizontalDirection > 0) lastDir = 1;
        else if (horizontalDirection < 0) lastDir = -1;

        CharacterRotation();

        if (Input.GetButtonDown(GlobalStringVars.Fire1) & !isFinished)
        {
            ShootEvent();
            animator.SetTrigger("Throw");
            Invoke("Shoot", 0.2f);
        }

        if(!isFinished)
        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }

    private void CharacterRotation()
    {
        if (lastDir < 0) gameObject.transform.rotation = Quaternion.Euler(0f,180f,0f);
        if (lastDir > 0) gameObject.transform.rotation = Quaternion.Euler(0f,0f,0f);
    }

    private void Shoot()
    {
        shooter.Shoot(lastDir);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish")) isFinished = true;
    }
}
