using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    int currentRound = 1;
    int currentEnemiesSpawned = 0;
    int maxEnemiesPerRound = 3; // Example value, adjust as needed

    public TMP_Text roundText; // Reference to a UI Text element to display the current round

    void Start()
    {
        if (roundText != null)
        {
            roundText.text = "Round: " + currentRound;
        }
    }

    public int GetMaxEnemies()
    {
        // Logic to determine the maximum number of enemies for the current round
        return maxEnemiesPerRound * currentRound;
    }
    public void NextRound()
    {
        //TODO: Update this to allow player to choose an upgrade first and only when they choose to continue, then increment the round
        currentRound++;
        // Logic to handle round progression, such as increasing difficulty or changing enemy types
        if (roundText != null)
        {
            roundText.text = "Round: " + currentRound;
        }

        SceneManager.LoadScene("UpgradesScreen");
    }

    public int GetCurrentRound()
    {
        return currentRound;
    }

    public void EnemySpawned()
    {
        currentEnemiesSpawned++;
        // Logic to handle when an enemy is spawned, such as updating UI or checking for round completion
        if (currentEnemiesSpawned >= GetMaxEnemies())
        {
            NextRound();
            currentEnemiesSpawned = 0; // Reset for the next round
        }
    }


}
