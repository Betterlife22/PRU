using TMPro;
using UnityEngine;

public class GameStartPopup : MonoBehaviour
{
    public GameObject popupPanel;
    public TextMeshProUGUI instructionText; 

    void Start()
    {      
        popupPanel.SetActive(true);
        Time.timeScale = 0; 

        instructionText.text = "<color=#FF0000>The castle is cursed...No one escapes alive...</color>\n" +
                               "<color=#FF0000>Slay all the minions before you face the master of this dark domain...</color>\n" +
                               "<color=#8B0000>Press any key to enter your doom...</color>";

    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            popupPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
