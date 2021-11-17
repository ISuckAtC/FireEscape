using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Simpleburn : MonoBehaviour
{
    public float deathTimer, maxTime ;
    // Start is called before the first frame update
    void Start()
    {
        deathTimer = 0;
        maxTime = 4;
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }
   
    private void OnTriggerStay(Collider other)
    {
        this.deathTimer += Time.deltaTime;
        if (other.tag == "Player" && deathTimer > maxTime)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            deathTimer = 0;
        }
        
    }
}
