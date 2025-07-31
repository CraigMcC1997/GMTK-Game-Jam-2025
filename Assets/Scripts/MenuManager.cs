using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    int HealthModifier = 10;
    int DamageModifier = 5;
    int SpeedModifier = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.Find("HEALTH BUTTON").GetComponentInChildren<TMP_Text>().text = " + " + HealthModifier;
        GameObject.Find("DAMAGE BUTTON").GetComponentInChildren<TMP_Text>().text = " + " + DamageModifier;
        GameObject.Find("SPEED BUTTON").GetComponentInChildren<TMP_Text>().text = " + " + SpeedModifier;
    }

    public void ReturnToGame()
    {
        // Load the game scene
        SceneManager.LoadScene("Game");
    }

    public void UpdateHealth()
    {
        
        int health = PlayerPrefs.GetInt("PlayerHealth", 100); // Default to 100 if not set
        health += HealthModifier;
        PlayerPrefs.SetInt("PlayerHealth", health); // Save the updated health

        if (health > PlayerPrefs.GetInt("HighestHealth", 100))
        {
            PlayerPrefs.SetInt("HighestHealth", health); // Update highest health if current is greater
        }
        ReturnToGame();
    }

    public void Updatedamage()
    {
        int damage = PlayerPrefs.GetInt("PlayerDamage", 10); // Default to 10 if not set
        damage += DamageModifier; 
        PlayerPrefs.SetInt("PlayerDamage", damage); // Save the updated damage
        ReturnToGame();
    }
    
    public void UpdateSpeed()
    {
        int speed = PlayerPrefs.GetInt("PlayerSpeed", 5); // Default to 5 if not set
        speed += SpeedModifier;
        PlayerPrefs.SetInt("PlayerSpeed", speed);
        ReturnToGame();
    }
}
