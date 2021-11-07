using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public GameObject Player, ExitNorth, ExitSouth, Spawn1, Spawn2, Spawn3, Spawn4, Spawn5, Spawn6;
    private int RandomSpawn;
    private bool OneTimeRule;
    // Start is called before the first frame update
    void Start()
    {
        RandomSpawn = Random.Range(1, 7);
        Player.GetComponent<FirstPersonMovement>().enabled = false;
        Debug.LogWarning(RandomSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        if(RandomSpawn < 4 && OneTimeRule == false)
        {
            ExitSouth.SetActive(false);
            if(RandomSpawn == 1)
            {
                Player.transform.position = Spawn1.transform.position;
                Player.transform.rotation = Spawn1.transform.rotation;
            }
            if (RandomSpawn == 2)
            {
                Player.transform.position = Spawn2.transform.position;
                Player.transform.rotation = Spawn2.transform.rotation;
            }
            if (RandomSpawn == 3)
            {
                Player.transform.position = Spawn3.transform.position;
                Player.transform.rotation = Spawn3.transform.rotation;
            }
            Player.GetComponent<FirstPersonMovement>().enabled = true;
            OneTimeRule = true;
        }
        if (RandomSpawn > 3 && OneTimeRule == false)
        {
            ExitNorth.SetActive(false);
            if (RandomSpawn == 4)
            {
                Player.transform.position = Spawn4.transform.position;
                Player.transform.rotation = Spawn4.transform.rotation;
            }
            if (RandomSpawn == 5)
            {
                Player.transform.position = Spawn5.transform.position;
                Player.transform.rotation = Spawn5.transform.rotation;
            }
            if (RandomSpawn == 6)
            {
                Player.transform.position = Spawn6.transform.position;
                Player.transform.rotation = Spawn6.transform.rotation;
            }
            Player.GetComponent<FirstPersonMovement>().enabled = true;
            OneTimeRule = true;
        }
    }
}
