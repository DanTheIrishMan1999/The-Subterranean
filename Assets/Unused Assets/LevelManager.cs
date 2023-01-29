using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{

    public UnityEvent endOfGame;

    public void LoadNextScene()
    {
        if(SceneManager.GetActiveScene().buildIndex - 1 < SceneManager.sceneCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            endOfGame.Invoke();
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}

