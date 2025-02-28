using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private int attackDamage = 20;
    private Animator animator;
    private bool isGrounded;
    private Rigidbody2D rb;
    private bool isAttacking = false;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    [SerializeField] float attackRate = 2f; 
    float nextAttackTime = 0f;
    [SerializeField] float pushForce = 100f;
    private Knockback knockback;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        knockback = GetComponent<Knockback>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!knockback.IsGettingKnockback)
        {
            UpdateAnimation();
            HandleAttack();
            if (!isAttacking)
            {
                HandleMovement();
                HandleJump();
            }
        }
    }
    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isJumping = !isGrounded;


        animator.SetBool("IsRunning", isRunning);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsAttacking", isAttacking);
        
    }

    void HandleAttack()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isAttacking = true;
                if (isGrounded)
                {
                    rb.linearVelocity = Vector2.zero;
                }
                

            }
        }
        
    }

    void EndAttack()
    {
        isAttacking = false;
        animator.SetBool("IsAttacking", isAttacking);
    }

    void DealDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyAI>().TakeDamage(attackDamage);
        }
        nextAttackTime = Time.time + 1f / attackRate;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemyLayers == (enemyLayers | (1 << collision.gameObject.layer)))
        {
            Debug.Log("Touch Enemy");
            
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            Debug.Log(knockbackDirection);
            HealthSystem.Instance.TakeDamage(10, knockbackDirection);

        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
