using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScenePortal : MonoBehaviour
{
    public string nextScene;
    public GameObject portalScene;

    private void Awake()
    {
        portalScene.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene); 
        }
    }
}
