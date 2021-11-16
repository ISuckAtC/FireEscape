using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
   
    public GameObject Player, ExitNorth, ExitSouth;
    private int RandomSpawn,RandomExit;
    public BooleanScene BS;
    private bool OneTimeRule;
    public GameObject[] Spawns,RandomBonusExit;
    // Start is called before the first frame update
    void Start()
    {
        BS = GameObject.Find("GameController").GetComponent<BooleanScene>();
        Player.GetComponent<FirstPersonMovement>().enabled = false;
        
        RandomSpawn = Random.Range(0, Spawns.Length);
       
        if(RandomBonusExit.Length == 0)
        {
            Debug.Log("BonusExitLength " + RandomBonusExit.Length);
        }
        RandomExit = Random.Range(0, RandomBonusExit.Length);
        
        Player.GetComponent<FirstPersonMovement>().enabled = false;
        Debug.LogWarning(RandomSpawn);
        Debug.Log("Half the amount of spawns " + Spawns.Length / 2);
        foreach (GameObject spawn in Spawns)
        {
            
        }
        Spawns[RandomSpawn].GetComponent<BasicSpreadingFire>().KillThem = true;
    }

    // Update is called once per frame
    void Update()
    {



        if (RandomSpawn < 4 && OneTimeRule == false)
        {
            if(RandomBonusExit.Length == 0)
            {
                goto noRando;
            }
            RandomBonusExit[RandomExit].SetActive(false);
        noRando:;
            Player.transform.position = Spawns[RandomSpawn].transform.position;
            Player.transform.rotation = Spawns[RandomSpawn].transform.rotation;
            ExitSouth.SetActive(false);
            Player.GetComponent<FirstPersonMovement>().enabled = true;
            OneTimeRule = true;
        }
        if (RandomSpawn > Spawns.Length/2 && OneTimeRule == false)
        {
            if (RandomBonusExit.Length == 0)
            {
                goto noRando;
            }
            RandomBonusExit[RandomExit].SetActive(false);
        noRando:;
            Player.transform.position = Spawns[RandomSpawn].transform.position;
            Player.transform.rotation = Spawns[RandomSpawn].transform.rotation;
            Player.GetComponent<FirstPersonMovement>().enabled = true;
            ExitNorth.SetActive(false);
            OneTimeRule = true;
           
            
        }
    }
}
