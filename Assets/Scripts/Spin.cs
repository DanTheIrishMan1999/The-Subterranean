using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float spinValue = 90;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * spinValue * Time.deltaTime);
    }

    public void FlipSin()
    {
        spinValue = -spinValue;
    }
}
