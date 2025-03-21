using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene("Trung"); // Thay "GameScene" bằng tên scene của bạn
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Thoát game!");
        Application.Quit(); // Thoát game
    }
}
