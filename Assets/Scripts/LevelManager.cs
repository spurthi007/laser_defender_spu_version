using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delayBeforeLoad = 1f;
    void Awake()
    {
        // scoreKeeper = FindObjectOfType<ScoreKeeper>();
        // Debug.Log("Name: "+scoreKeeper.gameObject.name);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameplay()
    {
        
        //scoreKeeper.ResetScore();
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadEndScreen()
    {
        StartCoroutine(WaitBeforeLoad("EndScreen", delayBeforeLoad));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting!!!");
        Application.Quit();
    }

    IEnumerator WaitBeforeLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
