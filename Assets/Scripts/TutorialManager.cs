using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject player, jumpAround, doorRemove, secondStage, thirdStage, checkpoint, boltPickup, pickupNow, pickupNow2;

    public string welcomeText, hint1, hint2, hint3, hint4, hint5, hint6, hint7, hint8, hint9, hint10, hint11, hint12, hint13, hint14, endText;

    public TMP_Text UIText;

    public int soundToPlay, soundToPlay1, soundToPlay2, soundToPlay3, soundToPlay4, soundToPlay5, soundToPlay6, soundToPlay7, soundToPlay8, soundToPlay9, soundToPlay10, soundToPlay11, soundToPlay12, soundToPlay13, soundToPlay14, soundToPlay15;

    public int sfxToPlay, sfxToPlay2;
    
    private enum LevelStages
    {
        START, WELCOME, HINT1, HINT2, HINT3, HINT4, HINT5, HINT6, HINT7, HINT8, HINT9, HINT10, HINT11, HINT12, HINT13, HINT14, END
    }

    private LevelStages currentStage = LevelStages.START;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        switch(currentStage)
        {
            case LevelStages.START:

                timer += Time.deltaTime;

                if(timer > 1f)
                {
                    timer = 0f;
                    currentStage = LevelStages.WELCOME;
                    AudioManager.instance.PlayVoice(soundToPlay);
                }

                //AudioManager.instance.PlayVoice(soundToPlay);

                break;

            case LevelStages.WELCOME:

                timer += Time.deltaTime;
                
                if(timer > 10f)
                {
                    timer = 0f;
                    //lookAround.SetActive(true);
                    currentStage = LevelStages.HINT1;
                    AudioManager.instance.PlayVoice(soundToPlay1);
                }

                UIText.text = welcomeText;

                break;    

            case LevelStages.HINT1:

                timer += Time.deltaTime;

                if(timer > 6f)
                {
                    timer = 0f;
                    //lookAround.SetActive(false);
                    //moveAround.SetActive(true);
                    currentStage = LevelStages.HINT2;
                    AudioManager.instance.PlayVoice(soundToPlay2);
                }
                UIText.text = hint1;

                break;

            case LevelStages.HINT2:

                timer += Time.deltaTime;

                if(timer > 20f)
                {
                    timer = 0f;
                    //moveAround.SetActive(true);
                    //jumpAround.SetActive(true);
                    currentStage = LevelStages.HINT3;
                    AudioManager.instance.PlayVoice(soundToPlay3);
                }
                UIText.text = hint2;

                break;

            case LevelStages.HINT3:

                timer += Time.deltaTime;

                if(timer > 7f)
                {
                    timer = 0f;
                    //moveAround.SetActive(true);
                    //jumpAround.SetActive(true);
                    currentStage = LevelStages.HINT4;
                    AudioManager.instance.PlayVoice(soundToPlay4);
                }
                UIText.text = hint3;

                break;    

            case LevelStages.HINT4:

                timer += Time.deltaTime;

                if(timer > 19f)
                {
                    timer = 0f;
                    //jumpAround.SetActive(false);
                    //pickupNow.SetActive(true);
                    currentStage = LevelStages.HINT5;
                    AudioManager.instance.PlayVoice(soundToPlay5);
                }
                UIText.text = hint4;

                break;

            case LevelStages.HINT5:

                timer += Time.deltaTime;

                if(timer > 11f)
                {
                    timer = 0f;
                    jumpAround.SetActive(true);
                    //doorSwitch.SetActive(false);
                    //pickupNow.SetActive(true);
                    currentStage = LevelStages.HINT6;
                    AudioManager.instance.PlayVoice(soundToPlay6);
                }
                UIText.text = hint5;

                break;

            case LevelStages.HINT6:

                if(Vector3.Distance(player.transform.position, jumpAround.transform.position) < 1f)
                {
                    jumpAround.SetActive(false);
                    doorRemove.SetActive(false);
                    secondStage.SetActive(true);
                    currentStage = LevelStages.HINT7;
                    AudioManager.instance.PlaySFX(sfxToPlay);
                    AudioManager.instance.StopVoice(soundToPlay6);
                    AudioManager.instance.PlayVoice(soundToPlay7);
                }
                UIText.text = hint6;

                break;

            case LevelStages.HINT7:

                timer += Time.deltaTime;

                if(timer > 9f)
                {
                    timer = 0f;
                    currentStage = LevelStages.HINT8;
                    AudioManager.instance.PlayVoice(soundToPlay8);
                }
                UIText.text = hint7;

                break; 

            case LevelStages.HINT8:

                if(Vector3.Distance(player.transform.position, secondStage.transform.position) < 2f)
                {
                    secondStage.SetActive(false);
                    thirdStage.SetActive(true);
                    currentStage = LevelStages.HINT9;
                    AudioManager.instance.StopVoice(soundToPlay8);
                    AudioManager.instance.PlayVoice(soundToPlay9);
                    AudioManager.instance.PlaySFX(sfxToPlay);
                }
                UIText.text = hint8;

                break;                   

            case LevelStages.HINT9:

                if(Vector3.Distance(player.transform.position, checkpoint.transform.position) < 1f)
                {
                    //thirdStage.SetActive(false);
                    //boltPickup.SetActive(true);
                    currentStage = LevelStages.HINT10;
                    AudioManager.instance.StopVoice(soundToPlay9);
                    AudioManager.instance.PlayVoice(soundToPlay10);
                }
                UIText.text = hint9;

                break; 

            case LevelStages.HINT10:

                if(Vector3.Distance(player.transform.position, thirdStage.transform.position) < 1f)
                {
                    thirdStage.SetActive(false);
                    boltPickup.SetActive(true);
                    //boltPickup.SetActive(false);
                    //pickupNow.SetActive(true);
                    //pickupNow2.SetActive(true);
                    currentStage = LevelStages.HINT11;
                    AudioManager.instance.StopVoice(soundToPlay10);
                    AudioManager.instance.PlayVoice(soundToPlay11);
                    AudioManager.instance.PlaySFX(sfxToPlay);
                }
                UIText.text = hint10;

                break;

            case LevelStages.HINT11:

                timer += Time.deltaTime;

                if(timer > 12f)
                {
                    timer = 0f;
                    currentStage = LevelStages.HINT12;
                    AudioManager.instance.PlayVoice(soundToPlay12);
                }

                if(Vector3.Distance(player.transform.position, boltPickup.transform.position) < 1f)
                {
                    //boltPickup.SetActive(false);
                    pickupNow.SetActive(true);
                    //pickupNow2.SetActive(true);
                    currentStage = LevelStages.HINT13;
                    AudioManager.instance.StopVoice(soundToPlay11);
                    AudioManager.instance.PlayVoice(soundToPlay13);
                }  
                UIText.text = hint11;

                break;

            case LevelStages.HINT12:

                if(Vector3.Distance(player.transform.position, boltPickup.transform.position) < 1f)
                {
                    //boltPickup.SetActive(false);
                    pickupNow.SetActive(true);
                    //pickupNow2.SetActive(true);
                    currentStage = LevelStages.HINT13;
                    AudioManager.instance.StopVoice(soundToPlay12);
                    AudioManager.instance.PlayVoice(soundToPlay13);
                }    
                UIText.text = hint12;

                break;

            case LevelStages.HINT13:

                if(Vector3.Distance(player.transform.position, pickupNow.transform.position) < 1f)
                {
                    pickupNow2.SetActive(true);
                    currentStage = LevelStages.HINT14;
                    AudioManager.instance.StopVoice(soundToPlay13);
                    AudioManager.instance.PlayVoice(soundToPlay14);
                    AudioManager.instance.PlaySFX(sfxToPlay2);
                }
                UIText.text = hint13;

                break;       

            case LevelStages.HINT14:

                if(Vector3.Distance(player.transform.position, pickupNow2.transform.position) < 1f)
                {
                    currentStage = LevelStages.END;
                    AudioManager.instance.StopVoice(soundToPlay14);
                    AudioManager.instance.PlayVoice(soundToPlay15);
                }
                UIText.text = hint14;

                break;             

            case LevelStages.END:

                UIText.text = endText;
                
                break;

            default:
                print("No level stage code. Check code for errors!");
                break;       
        }
    }
}

