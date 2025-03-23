using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject deadMenu;

    void Start()
    {
        deadMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        deadMenu.SetActive(true);
        Time.timeScale = 0; 
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
