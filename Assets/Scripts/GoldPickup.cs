using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public PickupItem Player;
    public BooleanScene BS;
    [Header("PickupA, says if we pick it up with hands or invisibly,  True to hold, false to vacuum")]
    public bool PickupA;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PickupItem>();
        BS = GameObject.FindGameObjectWithTag("GameController").GetComponent<BooleanScene>();
        if(BS.HoldorVacuum == false)
        {
            PickupA = false;
        }
        if(BS.HoldorVacuum == true)
        {
            PickupA = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(PickupA == false)
            {
                Player.Gold++;
                Player.recentGold++;
                Player.showGold++;
                gameObject.SetActive(false);
            }
            

        }
    }
}
