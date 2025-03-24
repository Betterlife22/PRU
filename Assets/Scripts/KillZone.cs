using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Animator animator;
    public GameManager manager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemies"))
        {
            manager.GameOver();
            animator.SetBool(AnimationStrings.isAlive, false);
            Destroy(collision.gameObject);
        }
    }
}
