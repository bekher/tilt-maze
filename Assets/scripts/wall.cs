using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour {
    bool shouldRotate = false;
    Quaternion target;
    float rotCount = 0;
    int direction = 1;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.Range(0, 1000) == 5)
        {
            shouldRotate = true;

            // set clockwise vs counterclockwise direction
            if (Random.Range(0,2) == 1)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
            
        }
        if (shouldRotate)
        {
           
            transform.Rotate(new Vector3(0, direction, 0));
            rotCount++;
            if (rotCount == 90)
            {
                shouldRotate = false;
                rotCount = 0;
            }
        }
    }
}
