using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance; // Creates instance variable of HealthManager for other scripts to reference

    public float currentHealth, maxHealth; // float variables for current and max health

    public float invincibleLength = 1f; // float variable judging how long invincibility after taking damage lasts
    private float invincCounter; // Counter that keeps track of how long invincibility lasts for each time

    public Sprite[] healthBarImages; // array for health bar image sprites to be put into within the inspector

    private LifeManager lifeSystem;
    
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();

        lifeSystem = FindObjectOfType<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;

            for(int i = 0; i < PlayerController.instance.playerPieces.Length; i++)
            {
                if(Mathf.Floor(invincCounter * 5f) % 2 == 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }
                else
                {
                    PlayerController.instance.playerPieces[i].SetActive(false);
                }

                if(invincCounter <= 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }
            }
        }
    }

    public void Hurt() /* Player takes damage, provided the time for invincibility has run out. When currenthealth reaches zero, calls the respawn function. Otherwise, calls the knockback function when not hitting zero health, updating the UI as it does so.*/
    {
        if(invincCounter <= 0)
        {
            currentHealth--;

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                GameManager.instance.Respawn();
                //lifeSystem.TakeLife();
            } 
            else
            {
                PlayerController.instance.Knockback();
                invincCounter = invincibleLength;
            }

            UpdateUI();
        }
    }

    public void ResetHealth() // resets health after respawn to what the normal max health is, and updates the UI to show it
    {
        currentHealth = maxHealth;

        UIManager.instance.healthImage.enabled = true;

        UpdateUI();
    }

    public void UpdateUI() // Updates the UI each time player takes damage, from max current health all the way down to none, upon which, the health image will briefly disappear before respawn
    {
        UIManager.instance.healthText.text = currentHealth.ToString();

        switch(currentHealth)
        {
            case 5:
                UIManager.instance.healthImage.sprite = healthBarImages[4];
                break;

            case 4:
                UIManager.instance.healthImage.sprite = healthBarImages[3];
                break;

            case 3:
                UIManager.instance.healthImage.sprite = healthBarImages[2];
                break;

            case 2:
                UIManager.instance.healthImage.sprite = healthBarImages[1];
                break;

            case 1:
                UIManager.instance.healthImage.sprite = healthBarImages[0];
                break;

            case 0:
                UIManager.instance.healthImage.enabled = false;
                break;
        }
    }

    public void PlayerKilled() // player dies when health hits zero, and UI updates as needed for this
    {
        currentHealth = 0;
        lifeSystem.TakeLife();
        UpdateUI();
    }
}
