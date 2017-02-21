using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilt : MonoBehaviour {

    private Vector3 currentRot;
    private float mult = 0.25f;
    public Rigidbody[] platforms;
    public GameObject wallPF;
    public GameObject pickupPF;

    // Use this for initialization
    void Start () {
        Vector3 platformLoc = this.GetComponent<Renderer>().bounds.min;
        platformLoc.y += .6f;
        
        float width = (this.GetComponent<Renderer>().bounds.max.x - this.GetComponent<Renderer>().bounds.min.x) / 10;
        float height = (this.GetComponent<Renderer>().bounds.max.z - this.GetComponent<Renderer>().bounds.min.z) / 10;


        // initialized to all false's by Microsoft's MSDN docs
        bool[,] pickups = new bool[10, 10];

        int count = 0;

        // Create pickups
        for (int i = 0; i < 6; i++)
        {
            int x, z;
            do
            {
                x = Random.Range(0, 10);
                z = Random.Range(0, 10);
            } while (((x == 9) && (z == 9)) || ((x == 5) && (z == 5)) || pickups[x,z] == true);

            pickups[x, z] = true;

            Vector3 pickupLoc = new Vector3(platformLoc.x + width * 0.5f, platformLoc.y - 0.4f, platformLoc.z + height * 0.5f);
            pickupLoc.x += width * x;
            pickupLoc.z += height * z;
            GameObject pickup = Instantiate(pickupPF, pickupLoc, Quaternion.identity);
            pickup.transform.parent = transform;
   
        }
        platformLoc.x += width * 1.0f;
        platformLoc.z += height * 1.0f;

        // Create walls
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (i == 4 && j == 4)
                    continue;
                if (((i + j) % 2) == 0)
                {
                    // place wall
                    Vector3 wallLoc = platformLoc;
                    wallLoc.x += width * i;
                    wallLoc.z += height * j;
                    GameObject pref = Instantiate(wallPF, wallLoc, Quaternion.identity * Quaternion.Euler(0, 90 * Random.Range(0, 4), 0));
                    pref.transform.parent = transform;
                    count++;

                }

            }
        }
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
