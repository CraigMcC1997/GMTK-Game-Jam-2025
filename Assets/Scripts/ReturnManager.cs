using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnManager : MonoBehaviour
{
    public Button returnButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        returnButton.onClick.AddListener(ReturnToMenu);
    }

    void ReturnToMenu()
    {
        // Load the menu scene
        SceneManager.LoadScene("Play Screen");
    }
}
