using TMPro;
using UnityEngine;

public class StoryPopup : MonoBehaviour
{
    public GameObject popupPanel;
    public TextMeshProUGUI instructionText;

    void Start()
    {
        popupPanel.SetActive(true);
        Time.timeScale = 0;

        instructionText.text = "<color=#006400>The forest is bewitched...A sinister force lurks within...</color>\n" +
                               "<color=#006400>Vanquish the shadowy creatures before confronting their vile overlord...</color>\n" +
                               "<color=#228B22>Press any key to step into the haunted woods...</color>";
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