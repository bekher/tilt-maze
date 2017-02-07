using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    private bool floating = false;
    private bool isPlaying = false;
    private float speed = 8f;
    private Vector3 floatDest = Vector3.up * 2000f;
    private AudioSource audio;
    public AudioClip bounce;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (floating)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, floatDest, step);
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "goal" && !floating)
        {
            floating = true;
            GetComponent<Rigidbody>().isKinematic = true;
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!audio.isPlaying && (collision.gameObject.name == "wall" || collision.gameObject.name == "Platform"))
        {
            audio.PlayOneShot(bounce, collision.relativeVelocity.magnitude/2.8F);
        }
    }
}
