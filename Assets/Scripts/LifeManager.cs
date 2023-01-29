using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;

    //public int startingLives;
    private int lifeCounter;

    private Text theText;

    public GameObject gameOverScreen;

    public PlayerController player;

    public string mainMenu;

    public float waitAfterGameOver;
    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<Text>();

        lifeCounter = PlayerPrefs.GetInt("PlayerLives");

        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       if(lifeCounter < 0)
       {
           gameOverScreen.SetActive(true);
           player.gameObject.SetActive(false);
       }
       
       theText.text = " " + lifeCounter;

       if(gameOverScreen.activeSelf)
       {
           waitAfterGameOver -= Time.deltaTime;
       }

       if(waitAfterGameOver < 0)
       {
           Cursor.visible = true;
           Cursor.lockState = CursorLockMode.None;
           Application.LoadLevel(mainMenu);
       }
    }

    public void GiveLife()
    {
        lifeCounter++;
        PlayerPrefs.SetInt("PlayerLives", lifeCounter);
    }

    public void TakeLife()
    {
        lifeCounter--;
        PlayerPrefs.SetInt("PlayerLives", lifeCounter);
    }
}
