using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public List<Collider2D> detectedColider = new List<Collider2D>();
    Collider2D col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectedColider.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detectedColider.Remove(collision);
    }
}
