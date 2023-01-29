using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance; // Creates the camera controller instance variable that can be referenced in other scripts

    public CinemachineBrain theCMBrain; // space for the Cinemachine object to be placed in the inspector

    private void Awake() // instantiates this script as soon as the game is the scene is booted up
    {
        instance = this;
    } 

    void Start()
    {

    }
}
