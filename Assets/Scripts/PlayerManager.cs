using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public int STARTING_HEALTH = 100;
    public int STARTING_DAMAGE = 10;
    public int STARTING_SPEED = 5;

    public int PlayerHealth;
    public int PlayerDamage;
    public int PlayerSpeed;

    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_Text speedText;

    RoundManager roundManager;

    public Slider healthBar;

    public GameObject enemyOBJ;
    EnemyManager enemy;

    AudioSource[] damageSounds = new AudioSource[5];

    SpriteRenderer sr;
    Color defaultColor;
    bool isHit = false;
    float timeToColor = 0.09f; // Time to change color back to

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roundManager = FindFirstObjectByType<RoundManager>().GetComponent<RoundManager>();
        enemy = enemyOBJ.GetComponent<EnemyManager>();
        loadStats(); // Load player stats from PlayerPrefs
        healthBar.maxValue = STARTING_HEALTH; // Set the maximum value of the health bar
        healthBar.value = PlayerHealth;

        AudioSource[] audioSources = GetComponents<AudioSource>();

        sr = GetComponent<SpriteRenderer>();
        defaultColor = sr.color;

        damageSounds[0] = audioSources[0];
        damageSounds[1] = audioSources[1];
        damageSounds[2] = audioSources[2];
        damageSounds[3] = audioSources[3];
        damageSounds[4] = audioSources[4];
    }

    public void UpdateUI()
    {
        if (PlayerHealth <= 0)
            PlayerHealth = 0;
        healthText.text = PlayerHealth.ToString();
        healthBar.value = PlayerHealth; // Update health bar
        damageText.text = "Damage: " + PlayerDamage.ToString();
        speedText.text = "Speed: " + PlayerSpeed.ToString();
    }

    void loadStats()
    {
        PlayerHealth = PlayerPrefs.GetInt("PlayerHealth", STARTING_HEALTH); // Default to 100 if not set
        PlayerDamage = PlayerPrefs.GetInt("PlayerDamage", STARTING_DAMAGE); // Default to 10 if not set
        PlayerSpeed = PlayerPrefs.GetInt("PlayerSpeed", STARTING_SPEED); // Default to 5 if not set
        healthBar.value = PlayerHealth;

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
        PlayerPrefs.SetInt("HighestHealth", STARTING_HEALTH);
        PlayerPrefs.SetInt("PlayerDamage", STARTING_DAMAGE);
        PlayerPrefs.SetInt("PlayerSpeed", STARTING_SPEED);
    }

    public int GetPlayerDamage()
    {
        return PlayerDamage;
    }

    public int getPlayerSpeed()
    {
        return PlayerSpeed;
    }

    public int GetPlayerHealth()
    {
        return PlayerHealth;
    }

    public bool CheckPlayerDeath()
    {
        if (PlayerHealth <= 0)
        {
            roundManager.saveEnemiesKilled(); // Save the number of enemies killed before player death
            return true; // Player is dead
        }
        return false; // Player is alive
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!isHit)
            {
                isHit = true;
                StartCoroutine(SwitchColor());
            }
            int RandomSound = Random.Range(0, damageSounds.Length);
            damageSounds[RandomSound].Play(); // Play random damage sound
            PlayerHealth -= enemy.EnemyDoesDamage(); // Reduce player health by enemy damage
            UpdateUI(); // Update the UI after taking damage
        }
    }

    IEnumerator SwitchColor()
    {
        sr.color = new Color(1f, 0.7f, 0.7f);
        yield return new WaitForSeconds(timeToColor);
        sr.color = defaultColor;
        isHit = false;
    }
}
