using UnityEngine;

public class PlayerConsillion : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("PlayerConsillion Awake");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("PlayerConsillion OnTriggerEnter2D");
        }
    }
}
