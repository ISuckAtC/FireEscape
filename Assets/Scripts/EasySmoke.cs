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

    // declare the amount of smoke the player can breathe without dying
    public float maxBreath = 10.0f;

    // declare a private field to store the current amount of air the player has, and make it visible in the inspector
    [SerializeField]
    private float currentBreath = 0.0f;

    // declare a private field to store whether or not the player is currently in the smoke
    private bool inSmoke = false;

    // declare a private field to set the speed of the smoke
    private float speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // set the current breath to the max breath
        currentBreath = maxBreath;

        // enable the renderer of the smoke
        GetComponent<Renderer>().enabled = true;

        // set the speed of the smoke to the distance divided by the total time
        speed = distance / totalTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if the player is in the smoke, decrease the current breath by the time
        if (inSmoke)
        {
            currentBreath -= Time.deltaTime;
            // if the current breath is less than 0, the player is dead
            if (currentBreath <= 0.0f)
            {
                // disable the renderer of the smoke
                GetComponent<Renderer>().enabled = false;
                // disable the script
                enabled = false;


                UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScene");
            }
        }
        else
        {
            // if the player is not in the smoke, increase the current breath by the time
            currentBreath += Time.deltaTime;
        }

        // move the smoke downwards at the speed calculated
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // if the smoke hits the player
        if (other.gameObject.tag == "Player")
        {
            // set the inSmoke field to true
            inSmoke = true;

            // Log that the player has entered the smoke
            Debug.Log("Entered the smoke");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // if the smoke leaves the player
        if (other.gameObject.tag == "Player")
        {
            // set the inSmoke field to false
            inSmoke = false;

            // log that the player has left the smoke
            Debug.Log("Left smoke");
        }
    }
}
