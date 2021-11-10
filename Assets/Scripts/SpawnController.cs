using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public GameObject Player, ExitNorth, ExitSouth,ExitMiddle, Spawn1, Spawn2, Spawn3, Spawn4, Spawn5, Spawn6, Spawn7;
    private int RandomSpawn,RandomExit;
    public BooleanScene BS;
    private bool OneTimeRule;
    // Start is called before the first frame update
    void Start()
    {
        BS = GameObject.FindGameObjectWithTag("GameController").GetComponent<BooleanScene>();
        Player.GetComponent<FirstPersonMovement>().enabled = false;
        if (BS.Level2 == true)
        {
            RandomSpawn = Random.Range(1, 8);
            RandomExit = Random.Range(1, 3);
            goto LevelSkip;
        }
        RandomSpawn = Random.Range(1, 7);
    LevelSkip:;
        Player.GetComponent<FirstPersonMovement>().enabled = false;
        Debug.LogWarning(RandomSpawn);
        Debug.Log(RandomExit);
    }

    // Update is called once per frame
    void Update()
    {

        if(BS.Level2 == true)
        {
            if (RandomSpawn < 4 && OneTimeRule == false)
            {
                if (RandomExit == 1)
                {
                    ExitMiddle.SetActive(false);
                }
                if (RandomExit == 2)
                {
                    ExitSouth.SetActive(false);
                }
                if (RandomSpawn == 1)
                {
                    Player.transform.position = Spawn1.transform.position;
                    Player.transform.localRotation = Spawn1.transform.localRotation;
                }
                if (RandomSpawn == 2)
                {
                    Player.transform.position = Spawn2.transform.position;
                    Player.transform.localRotation = Spawn2.transform.localRotation;
                }
                if (RandomSpawn == 3)
                {
                    Player.transform.position = Spawn3.transform.position;
                    Player.transform.localRotation = Spawn3.transform.localRotation;
                }
                Player.GetComponent<FirstPersonMovement>().enabled = true;
                OneTimeRule = true;
            }
            if (RandomSpawn > 4 && OneTimeRule == false)
            {
                if(RandomExit == 1)
                {
                    ExitMiddle.SetActive(false);
                }
                if (RandomExit == 2)
                {
                    ExitNorth.SetActive(false);
                }
                if (RandomSpawn == 4)
                {
                    Player.transform.position = Spawn4.transform.position;
                    Player.transform.localRotation = Spawn4.transform.localRotation;
                }
                if (RandomSpawn == 5)
                {
                    Player.transform.position = Spawn5.transform.position;
                    Player.transform.localRotation = Spawn5.transform.localRotation;
                }
                if (RandomSpawn == 6)
                {
                    Player.transform.position = Spawn6.transform.position;
                    Player.transform.localRotation = Spawn6.transform.localRotation;
                }
                if (RandomSpawn == 7)
                {
                    Player.transform.position = Spawn7.transform.position;
                    Player.transform.localRotation = Spawn7.transform.localRotation;
                }
                Player.GetComponent<FirstPersonMovement>().enabled = true;
                OneTimeRule = true;
                goto Randomized;
            }
        }


        if(RandomSpawn < 4 && OneTimeRule == false)
        {
            ExitSouth.SetActive(false);
            if(RandomSpawn == 1)
            {
                Player.transform.position = Spawn1.transform.position;
                Player.transform.localRotation = Spawn1.transform.localRotation;
            }
            if (RandomSpawn == 2)
            {
                Player.transform.position = Spawn2.transform.position;
                Player.transform.localRotation = Spawn2.transform.localRotation;
            }
            if (RandomSpawn == 3)
            {
                Player.transform.position = Spawn3.transform.position;
                Player.transform.localRotation = Spawn3.transform.localRotation;
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
                Player.transform.localRotation = Spawn4.transform.localRotation;
            }
            if (RandomSpawn == 5)
            {
                Player.transform.position = Spawn5.transform.position;
                Player.transform.localRotation = Spawn5.transform.localRotation;
            }
            if (RandomSpawn == 6)
            {
                Player.transform.position = Spawn6.transform.position;
                Player.transform.localRotation = Spawn6.transform.localRotation;
            }
            Player.GetComponent<FirstPersonMovement>().enabled = true;
            OneTimeRule = true;
        }
    Randomized:;
    }
}
