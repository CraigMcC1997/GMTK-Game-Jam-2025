using UnityEngine;
using UnityEngine.UI;

public class PlayGameManager : MonoBehaviour
{
    public Button playButton;
    public Button InstructionsButton;
    public Button ControlsButton;

    AudioSource clickAudio;

    void Start()
    {
        playButton.onClick.AddListener(StartGame);
        InstructionsButton.onClick.AddListener(ShowInstructions);
        ControlsButton.onClick.AddListener(ShowControls);

        clickAudio = GetComponent<AudioSource>();
    }

    void resetAllStats()
    {
        PlayerPrefs.SetInt("PlayerHealth", 100);
        PlayerPrefs.SetInt("PlayerDamage", 10);
        PlayerPrefs.SetInt("PlayerSpeed", 5);
        PlayerPrefs.SetInt("HighestHealth", 100);
        PlayerPrefs.SetInt("HighestDamage", 10);
        PlayerPrefs.SetInt("HighestSpeed", 5);
        PlayerPrefs.SetInt("HighestRound", 1);
        PlayerPrefs.SetInt("CurrentRound", 0);
        PlayerPrefs.Save(); // Ensure all changes are saved
    }

    void StartGame()
    {
        clickAudio.Play();
        resetAllStats();
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    void ShowInstructions()
    {
        clickAudio.Play();
        // Load the instructions scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Instructions");
    }

    void ShowControls()
    {
        clickAudio.Play();
        // Load the controls scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Controls");
    }
}
