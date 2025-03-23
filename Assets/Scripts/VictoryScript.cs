using TMPro;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    public GameObject victoryPanel; 
    public AudioClip victorySound;
    public TextMeshProUGUI instructionText;

    void Start()
    {
        victoryPanel.SetActive(false);
    }

   
}
