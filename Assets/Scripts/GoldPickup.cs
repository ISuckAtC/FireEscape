using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public PickupItem Player;
    public BooleanScene BS;
    public GameController GC;
    [Header("PickupA, says if we pick it up with hands or invisibly,  True to hold, false to vacuum")]
    public bool PickupA;
    [Header("shrinkEm, literally just controlls the part that makes the object shrink when picked up, after a second the object is turned off and picked up")]
    public bool shrinkEm;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PickupItem>();
        GC = GameObject.Find("GameController").GetComponent<GameController>();
        BS = GameObject.Find("GameController").GetComponent<BooleanScene>();
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
        if(shrinkEm == true)
        {
            gameObject.transform.localScale -= Vector3.one/10;
            if(gameObject.transform.localScale.z < 0.1)
            {
                Player.Gold++;
                GC.Valuables++;
                Player.recentGold++;
                Player.showGold++;
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(PickupA == false)
            {
                GC.ValueablePickup = true;
                shrinkEm = true;
               
            }
            

        }
    }
}
