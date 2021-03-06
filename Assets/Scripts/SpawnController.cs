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
    private void Awake()
    {
        RandomSpawn = Random.Range(0, Spawns.Length);
        Debug.Log("You spawned on spawnpoint " + RandomSpawn);
        if (RandomSpawn <= Spawns.Length / 2)
        {
            ExitSouth.SetActive(false);
        }
        if (RandomSpawn > Spawns.Length / 2)
        {
            ExitNorth.SetActive(false);
        }
    }
    void Start()
    {
        BS = GameObject.Find("GameController").GetComponent<BooleanScene>();
        Player.GetComponent<FirstPersonMovement>().enabled = false;
        
        
       
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
            spawn.transform.GetChild(0).gameObject.SetActive(false);
        }
        Spawns[RandomSpawn].transform.GetChild(0).gameObject.SetActive(true);
       // Spawns[RandomSpawn].GetComponentInChildren<BasicSpreadingFire>().KillThem = true;
       
        GameController.instance.startTime = System.DateTimeOffset.Now;
    }

    // Update is called once per frame
    void Update()
    {



        if (RandomSpawn <= Spawns.Length/2 && OneTimeRule == false)
        {
            if(RandomBonusExit.Length == 0)
            {
                goto noRando;
            }
            RandomBonusExit[RandomExit].SetActive(false);
        noRando:;
            Player.transform.position = Spawns[RandomSpawn].transform.position;
            Player.transform.rotation = Spawns[RandomSpawn].transform.rotation;
            
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
            
            OneTimeRule = true;
           
            
        }
    }
}
