using UnityEngine;
using UnityEngine.UI;

public class PlayGameManager : MonoBehaviour
{
    public Button playButton;
    public Button InstructionsButton;
    public Button ControlsButton;

    void Start()
    {
        playButton.onClick.AddListener(StartGame);
        InstructionsButton.onClick.AddListener(ShowInstructions);
        ControlsButton.onClick.AddListener(ShowControls);
    }

    void resetAllStats()
    {
        PlayerPrefs.SetInt("PlayerHealth", 100);
        PlayerPrefs.SetInt("PlayerDamage", 10);
        PlayerPrefs.SetInt("PlayerSpeed", 5);
        PlayerPrefs.SetInt("HighestHealth", 0);
        PlayerPrefs.SetInt("HighestDamage", 0);
        PlayerPrefs.SetInt("HighestSpeed", 0);
        PlayerPrefs.SetInt("HighestRound", 0);
        PlayerPrefs.SetInt("CurrentRound", 0);
        PlayerPrefs.Save(); // Ensure all changes are saved
    }

    void StartGame()
    {
        resetAllStats();
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    void ShowInstructions()
    {
        // Load the instructions scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Instructions");
    }

    void ShowControls()
    {
        // Load the controls scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Controls");
    }
}
