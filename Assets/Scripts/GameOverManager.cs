using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameOverManager : MonoBehaviour
{
    public TMP_Text gameOverText;
    public TMP_Text highestHealthText;
    public TMP_Text highestDamageText;
    public TMP_Text highestSpeedText;
    public TMP_Text highestRoundText;

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
        int highestHealth = PlayerPrefs.GetInt("HighestHealth", 100);
        int highestDamage = PlayerPrefs.GetInt("PlayerDamage", 10);
        int highestSpeed = PlayerPrefs.GetInt("PlayerSpeed", 5);
        int highestRound = PlayerPrefs.GetInt("HighestRound", 1);

        highestHealthText.text = "~ Highest Health: " + highestHealth.ToString();
        highestDamageText.text = "~ Highest Damage: " + highestDamage.ToString();
        highestSpeedText.text = "~ Highest Speed: " + highestSpeed.ToString();
        highestRoundText.text = "~ Highest Round: " + highestRound.ToString();
    }

    void RestartGame()
    {
        // Load the game scene to restart
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play Screen");
    }
}
