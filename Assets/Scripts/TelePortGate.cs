using System.Collections;
using UnityEngine;

public class TelePortGate : MonoBehaviour
{
    public Transform teleDestination; 
    public GameObject portalA; 
    public GameObject portalB; 
    public float delayTime = 0.5f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleDestination.position; 
            StartCoroutine(HidePortals()); 
        }
    }
    private void Awake()
    {
        portalA.SetActive(false);
    }

    IEnumerator HidePortals()
    {
        yield return new WaitForSeconds(delayTime);
        portalA.SetActive(false); 
        portalB.SetActive(false); 
    }
}
