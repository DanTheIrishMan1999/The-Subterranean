using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{

    public Vector3[] points; // the collection of points the platform will move between
    public int point_number = 0; // represents which point is being currently looked at
    private Vector3 current_target; // the current target of the platform
    public float tolerance; // float controlling how easily the platform snaps to its final destination
    public float speed; // float that controls speed of the platform
    public float delay_time; // float that controls the delay time of the platform each time it reaches one of its designated points, before moving on to the next.

    private float delay_start; // private variable used to help the delay_time variable work as intended

    public bool automatic; // controls whether the platform moves automatically or not

    // Start is called before the first frame update
    void Start()
    {
        if (points.Length > 0)
        {
            current_target = points[0]; // initializes the target to its first destination
        }
        tolerance = speed * Time.fixedDeltaTime; // tolerance is dependant on the speed of the platform multipied by the time it takes to move
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position != current_target)
        {
            MovePlatform(); // platform keeps moving until it reaches its target
        }
        else
        {
            UpdateTarget(); // updates to its next target upon reaching the latest one
        }
    }

    void MovePlatform() // The function allows the platform to move once parameters have been set
    {
        Vector3 heading = current_target - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if(heading.magnitude < tolerance)
        {
            transform.position = current_target; // helps the moving platform snap on to its target
            delay_start = Time.time; // ensures a time delay, if parameter is set, for when the platform has reached its destination and is moving to another
        }
    }
    void UpdateTarget() // once paramaters have been set, allows for the platform's target to be updated after reaching the latest one, and after a delay, moving to that one
    {
        if (automatic)
        {
            if(Time.time - delay_start > delay_time)
            {
                NextPlatform();
            }
        }
    }
    public void NextPlatform() // platform begins moving along the next point length following the previous
    {
        point_number++;
        if(point_number >= points.Length)
        {
            point_number = 0;
        }
        current_target = points[point_number];
    }

    private void OnTriggerEnter(Collider other) // when entering the platform, the platform becomes a parent to the player object
    {
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other) // when exiting the platform, the player is no longer a child of the platform
    {
        other.transform.parent = null;
    }
}
