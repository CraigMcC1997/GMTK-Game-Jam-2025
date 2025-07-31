using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameOverManager : MonoBehaviour
{
    public TMP_Text gameOverText;
    public TMP_Text highestHealthText;
    public TMP_Text highestDamageText;
    public TMP_Text highestSpeedText;

    public Button restartButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.text = "Game Over!";
        getHighestStats(); // Get the highest stats from PlayerPrefs
        restartButton.onClick.AddListener(RestartGame);
    }

    void getHighestStats()
    {
        int highestHealth = PlayerPrefs.GetInt("HighestHealth", 0);
        int highestDamage = PlayerPrefs.GetInt("PlayerDamage", 0);
        int highestSpeed = PlayerPrefs.GetInt("PlayerSpeed", 0);

        highestHealthText.text = "~ Highest Health: " + highestHealth.ToString();
        highestDamageText.text = "~ Highest Damage: " + highestDamage.ToString();
        highestSpeedText.text = "~ Highest Speed: " + highestSpeed.ToString();
    }

    void RestartGame()
    {
        // Load the game scene to restart
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
