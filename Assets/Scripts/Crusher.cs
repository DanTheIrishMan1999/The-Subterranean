using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Audio;

public class Crusher : MonoBehaviour
{

    public Vector3[] points; // the collection of points the wall will move between
    public int point_number = 0; // represents which point is being currently looked at
    private Vector3 current_target; // the current target of the wall
    public float tolerance; // float controlling how easily the wall snaps to its final destination
    public float speed; // float that controls speed of the wall
    public float delay_time; // float that controls the delay time of the wall each time it reaches one of its designated points, before moving on to the next.

    private float delay_start; // private variable used to help the delay_time variable work as intended

    public bool automatic; // controls whether the platform moves automatically or not
    public int soundToPlay; // controls sound effect for wall collision 


    // Start is called before the first frame update
    void Start()
    {
        if (points.Length > 0)
        {
            current_target = points[0]; // initializes the target to its first destination
        }
        tolerance = speed * Time.deltaTime; // tolerance is dependant on the speed of the wall multipied by the time it takes to move

        //audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position != current_target)
        {
            MoveWall(); // wall keeps moving until it reaches its target
        }
        else
        {
            UpdateTarget(); // updates to its next target upon reaching the latest one
        }
    }

    void MoveWall() // The function allows the wall to move once parameters have been set
    {
        Vector3 heading = current_target - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if(heading.magnitude < tolerance)
        {
            transform.position = current_target; // helps the moving wall snap on to its target
            delay_start = Time.time; // ensures a time delay, if parameter is set, for when the wall has reached its destination and is moving to another
        }
    }
    void UpdateTarget() // once paramaters have been set, allows for the wall's target to be updated after reaching the latest one, and after a delay, moving to that one
    {
        if (automatic)
        {
            if(Time.time - delay_start > delay_time)
            {
                NextMovement();
            }
        }
    }
    public void NextMovement() // wall begins moving along the next point length following the previous
    {
        point_number++;
        if(point_number >= points.Length)
        {
            point_number = 0;
        }
        current_target = points[point_number];
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlaySFX(soundToPlay); // allows the audio clip to play once
    }
}
