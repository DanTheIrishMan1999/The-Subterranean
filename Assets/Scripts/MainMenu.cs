using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public int playerLives;

    public void PlayGame() // Function called to play the game, sending user to the allocated scene.
    {
        SceneManager.LoadScene("Level 1");

        PlayerPrefs.SetInt("PlayerLives", playerLives);
    }

    public void TutorialLevel() // Function called to play the game's tutorial level, sending user to the allocated scene.
    {
        SceneManager.LoadScene("Tutorial Level");
    }

    public void QuitGame() // Function called to quit the game.
    {
        Debug.Log("Quiting.");
        Application.Quit();
    }
    
}
//SceneManager.GetActiveScene().buildIndex + 1