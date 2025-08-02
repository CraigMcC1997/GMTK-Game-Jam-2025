using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    AudioSource gameOverAudio;

    void Start()
    {
        gameOverAudio = GetComponent<AudioSource>();
    }

    public void LoadTitleScene()
    {
        StartCoroutine(LoadScene("Title Screen"));
    }

    public void LoadGame()
    {
        StartCoroutine(LoadScene("Game"));
    }

    public void LoadInstructions()
    {
        StartCoroutine(LoadScene("Instructions"));
    }

    public void LoadControls()
    {
        StartCoroutine(LoadScene("Controls"));
    }

    public void LoadUpgradesScene()
    {
        StartCoroutine(LoadScene("UpgradesScreen", 1.0f));
    }

    public void LoadGameOver()
    {
        if (gameOverAudio != null)
        {
            gameOverAudio.Play();
        }
        else
        {
            Debug.LogWarning("Game Over audio source not found!");
        }
        StartCoroutine(LoadScene("Game Over", 1.0f));
    }

    IEnumerator LoadScene(string sceneName, float delay = 0.75f)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
