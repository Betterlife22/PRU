using System.Collections;
using System.Collections.Generic;   
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirection))]
public class Wizard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float walkSpeed = 3f;
    public DetectionZone attackZone;
    Rigidbody2D rb;
    TouchingDirection touchingDirection;
    Animator animator;
    public enum WalkableDirection
    {
        Left,
        Right
    };
    private WalkableDirection _walkDirection;
    private Vector2 walkdirectionVector = Vector2.right;

    public WalkableDirection WalkDirection
    {
        get { return _walkDirection; }
        set
        {
            if (_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                if (value == WalkableDirection.Right)
                {
                    walkdirectionVector = Vector2.right;
                }
                else if (value == WalkableDirection.Left)
                {
                    walkdirectionVector = Vector2.left;
                }

            }

            _walkDirection = value;
        }
    }


    private void FixedUpdate()
    {
        if (touchingDirection.IsGrounded && touchingDirection.IsOnWall) {
            FlipDirection();
        }
        rb.linearVelocity = new Vector2(walkSpeed * walkdirectionVector.x, rb.linearVelocity.y);
    }
  
    public bool _hasTarget ;
    public bool HasTarget
    {
        get
        {
            return _hasTarget;
        }
        private set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirection = GetComponent<TouchingDirection>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HasTarget = attackZone.detectedColider.Count > 0;
    }
    public float AttackCooldown
    {
        get
        {
            return animator.GetFloat(AnimationStrings.attackCooldown);
        }
        set
        {
            animator.SetFloat(AnimationStrings.attackCooldown, Mathf.Max(value, 0));
        }
    }
    private void FlipDirection()
    {
        if (WalkDirection == WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
        else if (WalkDirection == WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.Left;
        }
    }

    // Update is called once per frame

}
