using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This file was written with mostly copilot

public class EasySmoke : MonoBehaviour
{
    // declare the total time needed for the smoke to reach the ground
    public float totalTime = 1.0f;

    // declare the amount of distance the smoke will travel
    public float distance = 1.0f;

    // declare a private field to set the speed of the smoke
    private float speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // enable the renderer of the smoke
        GetComponent<Renderer>().enabled = true;

        // set the speed of the smoke to the distance divided by the total time
        speed = distance / totalTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // move the smoke downwards at the speed calculated
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // if the smoke hits the player
        if (other.gameObject.tag == "Player")
        {
            // destroy the player then pause the game
            Destroy(other.gameObject);
            Time.timeScale = 0;
        }
    }
}
