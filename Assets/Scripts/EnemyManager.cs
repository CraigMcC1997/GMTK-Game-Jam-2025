using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    int enemyHealth = 25; // Example value, can be adjusted
    int enemyHealthModifier = 2; // Example value, can be adjusted
    int enemyDamage = 10;  

    public Slider healthBar;

    PlayerManager player;
    RoundManager roundManager;

    AudioSource wooshAwaySound;

    void Start()
    {
        player = FindFirstObjectByType<PlayerManager>().GetComponent<PlayerManager>();
        roundManager = FindFirstObjectByType<RoundManager>().GetComponent<RoundManager>();

        wooshAwaySound = GetComponent<AudioSource>();

        if (roundManager.GetCurrentRound() > 1)
            enemyHealth += roundManager.GetCurrentRound() * enemyHealthModifier; // Increase health based on the current round
        healthBar.maxValue = enemyHealth;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.value = enemyHealth;
    }

    public int EnemyDoesDamage()
    {
        return enemyDamage;
    }

    public void EnemyTakesDamage(int damage)
    {
        enemyHealth -= damage;
        UpdateHealthBar();
        checkForDeath();
    }
    
    void checkForDeath()
    {
        if (enemyHealth <= 0)
        {
            roundManager.EnemyKilled(); 
            Destroy(gameObject); // Destroy the enemy object
        }
    }

    public void moveEnemyAway()
    {
        wooshAwaySound.Play(); // Play the sound effect when the enemy gets thrown away
        Vector2 newPosition = new Vector2(Random.Range(-10.0f, 10.0f), 7.0f);
        transform.position = newPosition; // Move the enemy to a random position within bounds

        // when the enemy collides with the player, it will deal damage to itself
        EnemyTakesDamage(enemyDamage); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyTakesDamage(player.GetPlayerDamage());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            moveEnemyAway();
        }
    }
}
