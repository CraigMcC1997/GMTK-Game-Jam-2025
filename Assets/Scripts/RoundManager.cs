using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    int currentRound = 0;
    int currentEnemiesSpawned = 0;
    int maxEnemiesPerRound = 3; // Example value, adjust as needed
    int currentEnemiesKilled = 0; // Track how many enemies have been killed in this round

    public TMP_Text roundText; // Reference to a UI Text element to display the current round
    public TMP_Text enemiesRemainingText; // Reference to a UI Text element to display the current enemy count

    PlayerManager playerManager;

    public GameObject LevelLoader; // Reference to the LevelLoader script
    LevelLoader levelLoaderScript;

    void Start()
    {
        playerManager = FindFirstObjectByType<PlayerManager>();
        UpdateRoundCounter();
        UpdateEnemiesRemainingText();

        levelLoaderScript = LevelLoader.GetComponent<LevelLoader>();

        //TODO: player manager should handle this instead, maybe a call a function here instead
        if (currentRound == 1)
        {
            PlayerPrefs.SetInt("PlayerHealth", playerManager.STARTING_HEALTH);
            PlayerPrefs.SetInt("PlayerDamage", playerManager.STARTING_DAMAGE);
            PlayerPrefs.SetInt("PlayerSpeed", playerManager.STARTING_SPEED);
        }
    }

    public int GetMaxEnemies()
    {
        // Logic to determine the maximum number of enemies for the current round
        return maxEnemiesPerRound * currentRound;
    }

    void loadStats()
    {
        currentRound = PlayerPrefs.GetInt("CurrentRound", 0); // Default to round 1 if not set
    }
    public void UpdateRoundCounter()
    {
        loadStats();
        //TODO: Update this to allow player to choose an upgrade first and only when they choose to continue, then increment the round
        currentRound++;
        currentEnemiesSpawned = 0; // Reset for the next round
        // Logic to handle round progression, such as increasing difficulty or changing enemy types
        if (roundText != null)
        {
            roundText.text = "Round: " + currentRound;
        }
    }

    void UpdateEnemiesRemainingText()
    {
        if (enemiesRemainingText != null)
        {
            enemiesRemainingText.text = "Enemies Remaining: " + (GetMaxEnemies() - currentEnemiesKilled);
        }
    }

    public int GetCurrentRound()
    {
        return currentRound;
    }

    public void EnemySpawned()
    {
        currentEnemiesSpawned++;
    }

    void saveStats()
    {
        playerManager.saveStats(); // Save player stats to be used in the next round
        //save the current round number
        PlayerPrefs.SetInt("CurrentRound", currentRound);
        PlayerPrefs.SetInt("HighestRound", Mathf.Max(currentRound, PlayerPrefs.GetInt("HighestRound", 0))); // Save the highest round reached
    }

    void roundComplete()
    {
        saveStats();

        //TODO: ADD AUDIO HERE TO CELEBRATE ROUND COMPLETION

        //load the upgrade screen
        levelLoaderScript.LoadUpgradesScene();
    }

    void checkForRoundCompletion()
    {
        if (currentEnemiesKilled >= GetMaxEnemies())
        {
            roundComplete();
        }
    }

    public void EnemyKilled()
    {
        currentEnemiesKilled++;
        UpdateEnemiesRemainingText();
        checkForRoundCompletion();
    }

    public bool GetMaxEnemiesReached()
    {
        return currentEnemiesSpawned >= GetMaxEnemies();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("CurrentRound", 0); // Reset the current round when the game ends
        PlayerPrefs.SetInt("HighestRound", 0); // Reset the highest round reached
    }
}
