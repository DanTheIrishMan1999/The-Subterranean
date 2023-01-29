using System.Collections;
using System.Collections.Generic;
//using My.MoveSettings.Namespace;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; // creates instance variable for playercontroller to be referenced in any other script

    //[SerializeField] private MoveSettings _settings = null;
    
    public float moveSpeed; // float variable for movement speed
    public float jumpForce; // float variable for jumping
    public float gravityScale = 5f; // float variable for gravity on player
    
    //private float groundRayDistance = 1;
    //private RaycastHit slopeHit;
    
    private Vector3 moveDirection; // used for movement of the player
    
    public CharacterController charController; // charactercontroller for the player character

    private Camera theCam; // creates space for camera to be linked to the player in inspector

    public GameObject playerModel; // space in inspector for player model to be added to and linked in for script

    public float rotateSpeed; // controls rotation speed of player and camera

    public Animator anim; // gives space in inspector to input and link animator for character

    public bool isKnocking; // bool to recognise when player is being knocked back
    public float knockBackLength = .5f; // length of how long player is knocked back for
    private float knockbackCounter; // counter that keeps track of how long player is knocked back for
    public Vector2 knockbackPower; // determines how far the player is knocked back

    public GameObject[] playerPieces; // array for pieces of player

    public bool stopMove; // bool to stop movement

    private void Awake() // instantiates this script as soon as the scene starts
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main; // theCam linked to player will act as the main camera
    }

    // Update is called once per frame
    void Update()
    {
        if(!isKnocking && !stopMove) /* if player is not being knocked back and unable to move, they are able to jump and move around*/
        {
            float yStore = moveDirection.y;
            //moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
            moveDirection.Normalize();
            moveDirection = moveDirection * moveSpeed; // move direction multiplied by movespeed
            moveDirection.y = yStore;

            if(charController.isGrounded) // player can jump so long as they're grounded
            {
                moveDirection.y = 0f;
                //moveDirection.y = -_settings.antiBump;

                if(Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
        }
        

        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale; // applies gravity to player character over time

        //transform.position = transform.position + (moveDirection * Time.deltaTime * moveSpeed);

        charController.Move(moveDirection * Time.deltaTime); // Player can move with the parameters of moveDirection over time

        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) // allows player to freely move in a different direction while jumping
        {
            transform.rotation = Quaternion.Euler(0f, theCam.transform.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            //playerModel.transform.rotation = newRotation;

            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
        }

        /*if(OnSteepSlope())
        {
            SteepSlopeMovement();
        }*/

        if(isKnocking) // stops the player from being able to move as they are launched back, and cannot move until the counter hits zero
        {
            knockbackCounter -= Time.deltaTime;

            float yStore = moveDirection.y;
            moveDirection = playerModel.transform.forward * -knockbackPower.x;
            moveDirection.y = yStore;

            if(charController.isGrounded)
            {
                moveDirection.y = 0f;
            }

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            charController.Move(moveDirection * Time.deltaTime);

            if(knockbackCounter <= 0)
            {
                isKnocking = false;
            }
        }

        if(stopMove) // halts the players movement
        {
            moveDirection = Vector3.zero;
            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
            charController.Move(moveDirection);
        }

        anim.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z)); // float to recognise when character is moving around on ground for animation
        anim.SetBool("Grounded", charController.isGrounded); // boolean to recognise when player is grounded for animation
    }

    public void Knockback() // causes player to be knocked back upon taking damage
    {
        isKnocking = true;
        knockbackCounter = knockBackLength;
        Debug.Log("knocked back");
        moveDirection.y = knockbackPower.y;
        charController.Move(moveDirection * Time.deltaTime);
    }

    /*private bool OnSteepSlope()
    {
        if(!charController.isGrounded) return false;

        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, (charController.height / 2) + groundRayDistance))
        {
            float slopeAngle = Vector3.Angle(slopeHit.normal, Vector3.up);
            if(slopeAngle > charController.slopeLimit) return true;
        }
        return false;
    }

    private void SteepSlopeMovement()
    {
        Vector3 slopeDirection = Vector3.up - slopeHit.normal * Vector3.Dot(Vector3.up, slopeHit.normal);
        float slideSpeed = _settings.speed + _settings.slopeSlideSpeed + Time.deltaTime;

        moveDirection = slopeDirection * -slideSpeed;
        moveDirection.y = moveDirection.y - slopeHit.point.y;
    }*/
}
