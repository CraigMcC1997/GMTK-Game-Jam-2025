using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public int STARTING_HEALTH = 100;
    public int STARTING_DAMAGE = 10;
    public int STARTING_SPEED = 5;

    public int PlayerHealth;
    public int PlayerDamage;
    public int PlayerSpeed;

    public int EnemyDamage = 10; // Example value for enemy damage, adjust as needed

    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_Text speedText;

    RoundManager roundManager; // Reference to the RoundManager to get max enemies


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roundManager = FindFirstObjectByType<RoundManager>().GetComponent<RoundManager>();
        loadStats(); // Load player stats from PlayerPrefs
    }

    public void UpdateUI()
    {
        healthText.text = "Health: " + PlayerHealth.ToString();
        damageText.text = "Damage: " + PlayerDamage.ToString();
        speedText.text = "Speed: " + PlayerSpeed.ToString();
    }

    void loadStats()
    {
        PlayerHealth = PlayerPrefs.GetInt("PlayerHealth", STARTING_HEALTH); // Default to 100 if not set
        PlayerDamage = PlayerPrefs.GetInt("PlayerDamage", STARTING_DAMAGE); // Default to 10 if not set
        PlayerSpeed = PlayerPrefs.GetInt("PlayerSpeed", STARTING_SPEED); // Default to 5 if not set

        UpdateUI(); // Update the UI with loaded stats
    }

    public void saveStats()
    {
        PlayerPrefs.SetInt("PlayerHealth", PlayerHealth);
        PlayerPrefs.SetInt("PlayerDamage", PlayerDamage);
        PlayerPrefs.SetInt("PlayerSpeed", PlayerSpeed);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("PlayerHealth", STARTING_HEALTH);
        PlayerPrefs.SetInt("PlayerDamage", STARTING_DAMAGE);
        PlayerPrefs.SetInt("PlayerSpeed", STARTING_SPEED);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHealth -= EnemyDamage; // Reduce player health by enemy damage
            UpdateUI(); // Update the UI after taking damage
            
            Destroy(collision.gameObject); // Destroy the enemy on collision
            roundManager.EnemyKilled(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
