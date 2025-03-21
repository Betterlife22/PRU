using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;
    TouchingDirection touchingDirection;
    public DetectionZone cliffDetection;
    Animator animator;
    public float walkStopRate = 0.05f;
    Damageable damageable;
    public enum WalkableDirection
    {
        Left,
        Right
    }

    private WalkableDirection _walkDirection;
    private Vector2 walkableDirectionVector = Vector2.right;

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
                    walkableDirectionVector = Vector2.right;
                }
                else if (value == WalkableDirection.Left)
                {
                    walkableDirectionVector = Vector2.left;
                }

            }

            _walkDirection = value;
        }
    }
    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }
    public bool _hasTarget;
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

    /// <summary>
    /// The attack cooldown of the enemy
    /// </summary>
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirection = GetComponent<TouchingDirection>();
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if ((touchingDirection.IsGrounded && touchingDirection.IsOnWall) || cliffDetection.detectedColider.Count == 0)
        {
            FlipDirection();
        }
        if (!damageable.LockVelocity)
        {
            if (CanMove)

            {
                rb.linearVelocity = new Vector2(speed * walkableDirectionVector.x, rb.linearVelocity.y);
            }
            else
            {
                rb.linearVelocity = new Vector2(Mathf.Lerp(rb.linearVelocity.x, 0, walkStopRate), rb.linearVelocity.y);
            }
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
}
