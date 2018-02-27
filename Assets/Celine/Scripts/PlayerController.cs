using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float SPEED = 10;
    private const float JUMP_FORCE = 14;
    private const float GROUND_RADIUS = 0.2f;

    // INPUT
    public InputSystem inputSystem;
    private float inputHorizontal;
    private float inputVertical;

    // MOVEMENT
    private Rigidbody2D rigidBody2D;
    private float tempMove;

    // GROUNDCHECK
    public LayerMask whatIsGround;  // declare in inspector
    private Transform groundCheck;

    // ANIMATIONS
    public Animator face;         // declare in inspector
    public Animator limbs;        // declare in inspector

    private Vector2 startPosition;
    private bool freezeControls = false;

    private void Awake()
    {
        // Get inputsystem depending on device of player
        inputSystem = InputSystem.GetInputSystem();
        Debug.Log(inputSystem);

        groundCheck = transform.GetChild(0); // TEMP HACK!
        rigidBody2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void Update()
    {
        if (InputMobile.instance != null) // TEMP HACK!
        {
            InputMobile.instance.CheckInput();
        }

        // Check axes of inputsystem
        inputHorizontal = inputSystem.GetAxis(GameAction.MOVE_HORIZONTAL);
        inputVertical = inputSystem.GetAxis(GameAction.JUMP);
    }

    private void FixedUpdate()
    {
        // If player isn't in achievement panel, player can move
        if (!freezeControls)
        {
            if (CheckIfGrounded() == true)
            {
                MoveHorizontal();
                Jump();
            }
            else
            {
                TurnMidJump();
            }
        }
    }

    bool CheckIfGrounded()
    {
        // Check if player touches a ground object
        if (Physics2D.OverlapCircle(groundCheck.position, GROUND_RADIUS, whatIsGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void MoveHorizontal()
    {
        rigidBody2D.velocity = new Vector2(inputHorizontal * SPEED, rigidBody2D.velocity.y);
        if (inputHorizontal >= 0.1)  // right
        {
            limbs.SetBool("isWalking", true);
            FlipPlayer(true);
        }
        else if (inputHorizontal <= -0.1) // left
        {
            limbs.SetBool("isWalking", true);
            FlipPlayer(false);
        }
        else
        {
            limbs.SetBool("isWalking", false);
        }
    }

    private void Jump()
    {
        if (inputVertical >= 0.01)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, JUMP_FORCE);
            tempMove = inputHorizontal;
            limbs.SetTrigger("jumpTrigger");
        }
    }

    private void FlipPlayer(bool facingRight)
    {
        if (facingRight && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (!facingRight && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        }

    }

    private void TurnMidJump()
    {
        if (tempMove > 0.01 && inputHorizontal < -0.01)
        {
            rigidBody2D.velocity = new Vector2(inputHorizontal * SPEED * 0.3f, rigidBody2D.velocity.y);
        }
        else if (tempMove < -0.01 && inputHorizontal > 0.01)
        {
            rigidBody2D.velocity = new Vector2(inputHorizontal * SPEED * 0.3f, rigidBody2D.velocity.y);
        }
    }

    // Called from Killzone
    public void Respawn()
    {
        transform.position = startPosition;
    }

    // Called from AchievementPanel
    public void ControlSwitch(bool freeze)
    {
        freezeControls = freeze;
    }
}