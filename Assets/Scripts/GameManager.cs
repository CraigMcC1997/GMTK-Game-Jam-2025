using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerObject; // Reference to the player prefab
    PlayerManager playerManager;
    RoundManager roundManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roundManager = FindFirstObjectByType<RoundManager>().GetComponent<RoundManager>();
        playerManager = FindFirstObjectByType<PlayerManager>().GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.PlayerHealth <= 0)
        {
            Debug.Log("Game Over! Player has died.");
            SceneManager.LoadScene("Game Over");
        }
    }
}
