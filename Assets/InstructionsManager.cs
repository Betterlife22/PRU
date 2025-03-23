using UnityEngine;
using UnityEngine.UI;

public class InstructionsManager : MonoBehaviour
{
    public GameObject instructionsPanel; 


    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }
}
