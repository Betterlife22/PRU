using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemies"))
        {
            animator.SetBool(AnimationStrings.isAlive, false);
            Destroy(collision.gameObject);
        }
    }
}
