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

    void StartGame()
    {
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
