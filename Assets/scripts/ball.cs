using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    bool floating = false;
    bool isPlaying = false;
    float speed = 8f;
    Vector3 floatDest = Vector3.up * 2000f;
    new AudioSource audio;
    public AudioClip bounce;


    int pickups = 2;
    public string leftLabelStr = "Pickups remaining: 2";
    public string rightLabelStr = " ";

    public string label;

    float jumpForce = 300.0f;

    Rigidbody rb;
    
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 250, 20), leftLabelStr);
        GUI.Label(new Rect(Screen.width - 200, 10, 200, 20), rightLabelStr);
    }

    void Start () {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (floating)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, floatDest, step);
        } else
        {
            if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 1) {
                rb.AddForce(Vector3.up * jumpForce);
            }

            if (transform.position.y < -10f)
            {
                rightLabelStr = ("You lost! (press R to play again)");
            }
         }
		
	}

    /*
    private void setLabelText(string text)
    {
        GameObject platform = GameObject.Find("Platform");
        platform.GetComponent<tilt>().labelStr = text;

    }
    */

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.name == "goal" && !floating && pickups == 0)
        {
            floating = true;
            rb.isKinematic = true;
            rightLabelStr = ("You won! (press R to play again)");
        }

        if (other.name == "pickup(Clone)")
        {
            Destroy(other.gameObject);
            if (pickups > 0)
            {
                pickups -= 1;
                leftLabelStr = "Pickups remaining: " + pickups;
            }
            if (pickups == 0)
            {
                leftLabelStr = "Done! Go to the goal!";
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!audio.isPlaying && (collision.gameObject.name == "wall" || collision.gameObject.name == "wall_c" || collision.gameObject.name == "Platform"))
        {
            audio.PlayOneShot(bounce, collision.relativeVelocity.magnitude/2.8F);
        }
    }
}