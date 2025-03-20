 using UnityEngine;

public class TouchingDirection : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.1f;
    public float wallDistance = 0.1f;
    public float ceilingDistance = 0.1f;
    CapsuleCollider2D touchingCol;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];
    Animator animator;
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    /// <summary>
    /// Check if the player is on the ground
    /// </summary>
    [SerializeField]
    private bool _isGrounded = true;
    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        private set 
        {
            _isGrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        }
    }

    /// <summary>
    /// Check if the player is on the wall
    /// </summary>
    [SerializeField]
    private bool _isOnWall = true;
    public bool IsOnWall
    {
        get
        {
            return _isOnWall;
        }
        private set
        {
            _isOnWall = value;
            animator.SetBool(AnimationStrings.isOnWall, value);
        }
    }

    /// <summary>
    /// Check if the player is on the celling
    /// </summary>
    [SerializeField]
    private bool _isOnCeiling = true;
    public bool IsOnCeiling
    {
        get
        {
            return _isOnCeiling;
        }
        private set
        {
            _isOnCeiling = value;
            animator.SetBool(AnimationStrings.isOnCeiling, value);
        }
    }

    void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        IsGrounded =  touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        IsOnWall = touchingCol.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingCol.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;
    }

}
