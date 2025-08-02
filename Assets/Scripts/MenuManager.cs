using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Button healthButton;
    public Button damageButton;
    public Button speedButton;
    public Button confirmButton;

    int HealthModifier = 10;
    int DamageModifier = 5;
    int SpeedModifier = 3;

    enum Choice
    {
        HEALTH,
        DAMAGE,
        SPEED
    }

    int healthUpgrade;
    int damageUpgrade;
    int speedUpgrade;
    int confirm_choice;

    bool confirmed = false;

    AudioSource healAudio;
    AudioSource damageAudio;
    AudioSource speedAudio;
    AudioSource confirmAudio;

    public GameObject levelLoader;
    LevelLoader levelLoaderScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthButton.onClick.AddListener(UpdateHealth);
        damageButton.onClick.AddListener(Updatedamage);
        speedButton.onClick.AddListener(UpdateSpeed);
        confirmButton.onClick.AddListener(Confirm);

        AudioSource[] audioSources = GetComponents<AudioSource>();

        healAudio = audioSources[0]; // Assuming healAudio is the first AudioSource
        damageAudio = audioSources[1]; // Assuming damageAudio is the second AudioSource
        speedAudio = audioSources[2]; // Assuming speedAudio is the third AudioSource
        confirmAudio = audioSources[3]; // Assuming confirmAudio is the fourth AudioSource

        levelLoaderScript = levelLoader.GetComponent<LevelLoader>();
    }

    public void UpdateHealth()
    {
        healAudio.Play();
        confirmed = true;
        choice(Choice.HEALTH);
    }

    public void Updatedamage()
    {
        damageAudio.Play();
        confirmed = true;
        choice(Choice.DAMAGE);
    }

    public void UpdateSpeed()
    {
        speedAudio.Play();
        confirmed = true;
        choice(Choice.SPEED);
    }

    void choice(Choice choice)
    {
        switch (choice)
        {
            case Choice.HEALTH:
                {
                    healthUpgrade = PlayerPrefs.GetInt("PlayerHealth", 100); // Default to 100 if not set
                    healthUpgrade += HealthModifier;
                    confirm_choice = (int)Choice.HEALTH; // Store the choice for later confirmation
                }
                break;
            case Choice.DAMAGE:
                {
                    damageUpgrade = PlayerPrefs.GetInt("PlayerDamage", 10); // Default to 10 if not set
                    damageUpgrade += DamageModifier;
                    confirm_choice = (int)Choice.DAMAGE; // Store the choice for later confirmation
                }
                break;
            case Choice.SPEED:
                {
                    speedUpgrade = PlayerPrefs.GetInt("PlayerSpeed", 5); // Default to 5 if not set
                    speedUpgrade += SpeedModifier;
                    confirm_choice = (int)Choice.SPEED; // Store the choice for later confirmation
                }
                break;
            default:
                Debug.LogError("Invalid choice made in MenuManager");
                break;
        }
    }

    public void Confirm()
    {
        if (!confirmed)
        {
            Debug.LogWarning("Upgrade not chosen. Please select an upgrade before confirming.");
            return;
        }

        switch (confirm_choice)
        {
            case (int)Choice.HEALTH:
                {
                    PlayerPrefs.SetInt("PlayerHealth", healthUpgrade); // Save the updated health

                    if (healthUpgrade > PlayerPrefs.GetInt("HighestHealth", 100))
                    {
                        PlayerPrefs.SetInt("HighestHealth", healthUpgrade); // Update highest health if current is greater
                    }
                }
                break;
            case (int)Choice.DAMAGE:
                PlayerPrefs.SetInt("PlayerDamage", damageUpgrade);
                break;
            case (int)Choice.SPEED:
                PlayerPrefs.SetInt("PlayerSpeed", speedUpgrade);
                break;
            default:
                Debug.LogError("Invalid choice made in Confirm method of MenuManager");
                break;
        }

        if (confirmed)
        {
            confirmAudio.Play();
            levelLoaderScript.LoadGame();
        }
    }
}
