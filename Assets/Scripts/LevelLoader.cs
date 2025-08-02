using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public void LoadPlayScene()
    {
        StartCoroutine(LoadScene("Play Screen"));
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
        StartCoroutine(LoadScene("UpgradesScreen"));
    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadScene("Game Over"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(sceneName);
    }
}
