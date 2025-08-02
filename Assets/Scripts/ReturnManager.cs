using UnityEngine;
using UnityEngine.UI;

public class ReturnManager : MonoBehaviour
{
    public Button returnButton;
    AudioSource returnAudio;

    public GameObject levelLoader;
    LevelLoader levelLoaderScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        returnButton.onClick.AddListener(ReturnToMenu);

        levelLoaderScript = levelLoader.GetComponent<LevelLoader>();
        returnAudio = GetComponent<AudioSource>();
    }

    void ReturnToMenu()
    {
        // Load the menu scene
        returnAudio.Play();
        levelLoaderScript.LoadTitleScene();
    }
}
