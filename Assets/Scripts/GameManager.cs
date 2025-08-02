using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerObject; // Reference to the player prefab
    PlayerManager playerManager;
    RoundManager roundManager;

    LevelLoader levelLoaderScript;
    public GameObject LevelLoader; // Reference to the LevelLoader script

    bool gameOverAudio = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roundManager = FindFirstObjectByType<RoundManager>().GetComponent<RoundManager>();
        playerManager = FindFirstObjectByType<PlayerManager>().GetComponent<PlayerManager>();
        levelLoaderScript = LevelLoader.GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: should be a get function
        if (playerManager.CheckPlayerDeath() && gameOverAudio)
        {
            gameOverAudio = false; // Prevent multiple game over triggers
            levelLoaderScript.LoadGameOver();
        }
    }
}
