using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // instantiates the gamemanager object

    private Vector3 respawnPosition; // used to input variable in the Start function for the respawn position

    public int currentBolt;

    public int cur_Bolt = 0;

    public GameObject deathEffect; // sets up a place to put in the death effect of the player
    
    public GameObject powerup;

    //public GameObject life1;
    
    public int levelEndMusic = 1; // sets up the music that should be played at the level's completion

    //public string levelToLoad;
    
    //bool gameHasEnded = false; 

    public GameObject completeLevelUI; // gives a slot for the UI game object of the completed level to be put in

    private LifeManager lifeSystem;

    private void Awake()
    {
        instance = this;
    }

    void Start() // cursor is invisible and locked into position. respawn position set to starting/spawn location of player
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        respawnPosition = PlayerController.instance.transform.position;

        //powerup.SetActive(false);

        lifeSystem = FindObjectOfType<LifeManager>();

        AddBolt(0);
        AddPowerupAndLife();
    }

    void Update() // escape key to pause game
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void Respawn() //instantiates the RespawnCo function when player is killed
    {
        StartCoroutine(RespawnCo());

        HealthManager.instance.PlayerKilled();
    }

    public IEnumerator RespawnCo() // function for the respawning
    {
        PlayerController.instance.gameObject.SetActive(false); // playercontroller deactivates while the respawn process is going on

        CameraController.instance.theCMBrain.enabled = false; // camera deactivates during the respawn process

        UIManager.instance.fadeToBlack = true; // allows the screen to fade to black

        Instantiate(deathEffect, PlayerController.instance.transform.position + new Vector3(0f, 1f, 0f), PlayerController.instance.transform.rotation); // instantiates the death of the player over the location where they died
        
        yield return new WaitForSeconds(2f); // the full process of respawning will take 2 seconds

        HealthManager.instance.ResetHealth(); // calls function to reset health to full upon respawn

        UIManager.instance.fadeFromBlack = true; // allows the screen to fade back into view away from the blackscreen
        
        PlayerController.instance.transform.position = respawnPosition; // player will respawn at the position they're set to spawn at in the scene
        
        CameraController.instance.theCMBrain.enabled = true; // camera reactivates upon completion of the respawn
        
        PlayerController.instance.gameObject.SetActive(true); // playercontroller reactivates upon completion of the respawn
    
        //PlatformRespawn();
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint) //  function to allow for new spawn point to be made for a checkpoint
    {
        respawnPosition = newSpawnPoint;
        Debug.Log("Spawn point set");
    }

    /*public void PlatformRespawn()
    {
        //PlatformFracture.instance.gameObject.SetActive(true);

        bridge.SetActive(true);
        
        Instantiate(bridge, transform.position, Quaternion.Euler(180, 0, 0));
    }*/
    
    public void AddBolt(int boltToAdd) // adds collected bolt to your current count, which will be shown on the GUI
    {
        currentBolt += boltToAdd;

        UIManager.instance.boltText.text = " " + currentBolt;
    }

    /*public void AddLife(int lifeToAdd)
    {
        //UIManager.instance.boltText.text;
        currentBolt += lifeToAdd;

        if(currentBolt == 10)
        {
            LifeManager.instance.theText.text = "X " + currentBolt;
        }
    }*/

    public void AddPowerupAndLife() // makes it so that after collecting a certain amount of bolts, a powerup will spawn, and will also grant a life too
    {
        if(cur_Bolt > 0)
        {
            powerup.SetActive(false);
            //life1.SetActive(false);
        }
        else if(cur_Bolt == 0)
        {
            powerup.SetActive(true);
            //life1.SetActive(true);
            //lifeSystem.GiveLife();
        }
        else if(cur_Bolt == -20)
        {
            lifeSystem.GiveLife();
        }
        else if(cur_Bolt == -70)
        {
            lifeSystem.GiveLife();
        }
        else if(cur_Bolt == -120)
        {
            lifeSystem.GiveLife();
        }
        else if(cur_Bolt == -170)
        {
            lifeSystem.GiveLife();
        }
        else if(cur_Bolt == -220)
        {
            lifeSystem.GiveLife();
        }
    }

    public void PauseUnpause()
    {
        if(UIManager.instance.pauseMenu.activeInHierarchy) // when coming out of the pause menu, the cursor will become invisible and be locked in place, whilst when in the pause menu, the opposite occurs.
        {
            UIManager.instance.pauseMenu.SetActive(false);
            Time.timeScale = 1f;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            UIManager.instance.pauseMenu.SetActive(true);
            UIManager.instance.CloseOptions();
            Time.timeScale = 0f;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    /*public void CompleteLevelUI() // Brings up the complete level UI, and also makes the cursor unlocked and visible, while freezing the player in place
    {   
        completeLevelUI.SetActive(true);
        Cursor.visible = true;
        AudioManager.instance.StopMusic();
        Cursor.lockState = CursorLockMode.None;
        PlayerController.instance.stopMove = true;
        //Time.timeScale = 0f;
    }*/

    /*public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("GameOver");
        }  
    }*/

    public IEnumerator LevelEndCo() // plays level end music, stops player from moving, and both brings up the complete level UI as well as unlocks the cursor after 3 seconds
    {
        AudioManager.instance.PlayMusic(levelEndMusic);
        PlayerController.instance.stopMove = true;
        yield return new WaitForSeconds(3f);
        completeLevelUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        Debug.Log("Level Ended.");

        //SceneManager.LoadScene(levelToLoad);
    }

    public void ReloadGame() // Function called to reload game back to main menu
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel() // Function called to send player to next level
    {
        SceneManager.LoadScene(3);
    } 

    public void QuitGame() // Function called to quit the game.
    {
        Debug.Log("Quiting.");
        Application.Quit();
    }
}
