using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public GameObject levelLoader;

    LevelLoader levelLoaderScript;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        levelLoaderScript = levelLoader.GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Resume();
        levelLoaderScript.LoadTitleScene();
    }

    public void Restart()
    {
        resetAllStats();
        Resume();
        levelLoaderScript.LoadGame();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    void resetAllStats()
    {
        PlayerPrefs.SetInt("PlayerHealth", 100);
        PlayerPrefs.SetInt("PlayerDamage", 10);
        PlayerPrefs.SetInt("PlayerSpeed", 5);
        PlayerPrefs.SetInt("HighestHealth", 100);
        PlayerPrefs.SetInt("HighestDamage", 10);
        PlayerPrefs.SetInt("HighestSpeed", 5);
        PlayerPrefs.SetInt("HighestRound", 1);
        PlayerPrefs.SetInt("CurrentRound", 0);
        PlayerPrefs.Save(); // Ensure all changes are saved
    }
}
