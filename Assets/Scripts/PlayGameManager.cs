using UnityEngine;
using UnityEngine.UI;

public class PlayGameManager : MonoBehaviour
{
    public Button playButton;
    public Button InstructionsButton;
    public Button ControlsButton;

    AudioSource clickAudio;

    public GameObject levelLoader;
    LevelLoader levelLoaderScript;

    void Start()
    {
        playButton.onClick.AddListener(StartGame);
        InstructionsButton.onClick.AddListener(ShowInstructions);
        ControlsButton.onClick.AddListener(ShowControls);

        levelLoaderScript = levelLoader.GetComponent<LevelLoader>();

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
        PlayerPrefs.SetInt("EnemiesKilled", 0);
        PlayerPrefs.Save(); // Ensure all changes are saved
    }

    void StartGame()
    {
        clickAudio.Play();
        resetAllStats();
        // Load the game scene
        levelLoaderScript.LoadGame();
    }

    void ShowInstructions()
    {
        clickAudio.Play();
        // Load the instructions scene
        levelLoaderScript.LoadInstructions();
    }

    void ShowControls()
    {
        clickAudio.Play();
        // Load the controls scene
        levelLoaderScript.LoadControls();
    }
}
