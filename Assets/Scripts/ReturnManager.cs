using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnManager : MonoBehaviour
{
    public Button returnButton;
    AudioSource returnAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        returnButton.onClick.AddListener(ReturnToMenu);

        returnAudio = GetComponent<AudioSource>();
    }

    void ReturnToMenu()
    {
        // Load the menu scene
        returnAudio.Play();
        SceneManager.LoadScene("Play Screen");
    }
}
