using System.Xml.Serialization;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    [SerializeField] Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
    }


    void Die()
    {
        Debug.Log("Enemy Die");
        animator.SetBool("IsDie", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        StartCoroutine(DisappearAfterAnimation());
    }

    System.Collections.IEnumerator DisappearAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }

}
