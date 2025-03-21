using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed = 1f; // Tốc độ di chuyển
    public float moveDistance = 10f; // Khoảng cách di chuyển qua lại
    public int damage = 10;
    private Vector2 startPosition;
    private Vector2 targetPosition;
    private bool movingRight = true;
    private Animator animator; // Tham chiếu đến Animator
    Damageable damageable;
    Rigidbody2D rb;

    private void Awake()
    {
        startPosition = transform.position; // Lưu vị trí bắt đầu
        targetPosition = startPosition + new Vector2(moveDistance, 0); // Tính toán vị trí mục tiêu
        animator = GetComponent<Animator>(); // Lấy component Animator
        
        rb = GetComponent<Rigidbody2D>();
        damageable = GetComponent<Damageable>();

        if (animator == null) Debug.LogError("Animator component is missing on " + gameObject.name);
        
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // Di chuyển enemy
        if (movingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                movingRight = false; // Đổi hướng khi đến vị trí mục tiêu
                Flip(); // Quay đầu
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, startPosition) < 0.1f)
            {
                movingRight = true; // Đổi hướng khi trở về vị trí bắt đầu
                Flip(); // Quay đầu
            }
        }

        // Cập nhật Animator
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f || Vector2.Distance(transform.position, startPosition) < 0.1f)
        {
            animator.SetBool("isWalking", false); // Chuyển sang trạng thái Idle
        }
        else
        {
            animator.SetBool("isWalking", true); // Chuyển sang trạng thái Walk
        }
    }

    void Flip()
    {
        // Đảo ngược hướng của enemy
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Đảo ngược trục x
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enemy triggered with Player!");

            Damageable damageable = collision.GetComponent<Damageable>();
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();

            if (damageable != null && playerRb != null)
            {
                Vector2 knockback = new Vector2(movingRight ? 1 : -1, 0.5f) * 5f; // Lực đẩy player
                playerRb.AddForce(knockback, ForceMode2D.Impulse); // Áp dụng knockback

                damageable.Hit(damage, knockback);
            }
        }
    }




}