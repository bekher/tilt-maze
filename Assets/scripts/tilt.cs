using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilt : MonoBehaviour {

    private Vector3 currentRot;
    private float mult = 0.25f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentRot = GetComponent<Transform>().eulerAngles;

        if ((Input.GetAxis("Horizontal") > .2) && (currentRot.z <= 11 || currentRot.z >= 349))
        {
            transform.Rotate(0, 0, -1 * mult); 
        }
        if ((Input.GetAxis("Horizontal") < -.2) && (currentRot.z >= 348 || currentRot.z <= 10))
        {
            transform.Rotate(0, 0, 1 * mult);
        }
        if ((Input.GetAxis("Vertical") > .2) && (currentRot.x <= 10 || currentRot.x >= 348))
        {
            transform.Rotate(1* mult, 0, 0);
        }
        if ((Input.GetAxis("Vertical") < -.2) && (currentRot.x >= 349 || currentRot.x <= 11))
        {
            transform.Rotate(-1 * mult, 0, 0);
        }

    }
}
