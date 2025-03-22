using TMPro;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    public GameObject victoryPanel; 
    public AudioSource victorySound;
    public TextMeshProUGUI instructionText;

    void Start()
    {
        victoryPanel.SetActive(false);
    }

    public void ShowVictory()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0; 
        if (victorySound != null)
        {
            victorySound.Play(); 
        }
    }

    void Update()
    {
        int boss = GameObject.FindGameObjectsWithTag("Boss").Length;
        if (boss <= 0)
        {
            victoryPanel.SetActive(true);
            instructionText.text = "<color=#FFD700>Glory is yours, champion!</color>\n" +
                       "<color=#FFD700>The dark lord has fallen, and the castle is freed from its curse...</color>\n";
                      
        }
    }
}
