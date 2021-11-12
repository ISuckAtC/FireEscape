using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private Camera characterCamera;
    [SerializeField]
    private Transform slot, Rotated, goldPos1, goldPos2, goldPos3, goldPos4, goldPos5, goldPos6, goldPos7, goldPos8;
    private PickableItem pickedItem;
    public GameObject HandHoldGold1, HandHoldGold2, HandHoldGold3, HandHoldGold4, HandHoldGold5, HandHoldGold6, HandHoldGold7, HandHoldGold8;
    public bool PickedUp, isUsingAxe, usedItem, doneOnce;
    [Header("how many valuables do you want the player to pickup to be slowed down?")]
    public int HeavyValue;
    [Header("Just keeping track of our gold")]
    public int Gold;
    public int recentGold;
    public int howSlow, showGold;
    public FirstPersonMovement FPM;
    public GameController GC;
    // Start is called before the first frame update
    void Start()
    {

        GC = GameObject.Find("GameController").GetComponent<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        switch( showGold)
        {
            case 1:
                HandHoldGold1.SetActive(true);
                HandHoldGold1.transform.position = goldPos1.position;
                HandHoldGold1.transform.rotation = goldPos1.rotation;
                HandHoldGold1.GetComponent<Rigidbody>().isKinematic = true;
                break;
            case 2:
                HandHoldGold2.SetActive(true);
                HandHoldGold2.transform.position = goldPos2.position;
                HandHoldGold2.transform.rotation = goldPos2.rotation;
                HandHoldGold2.GetComponent<Rigidbody>().isKinematic = true;
                break;
            case 3:
                HandHoldGold3.SetActive(true);
                HandHoldGold3.transform.position = goldPos3.position;
                HandHoldGold3.transform.rotation = goldPos3.rotation;
                HandHoldGold3.GetComponent<Rigidbody>().isKinematic = true;
                break;
            case 4:
                HandHoldGold4.SetActive(true);
                HandHoldGold4.transform.position = goldPos4.position;
                HandHoldGold4.transform.rotation = goldPos4.rotation;
                HandHoldGold4.GetComponent<Rigidbody>().isKinematic = true;
                break;
            case 5:
                HandHoldGold5.SetActive(true);
                HandHoldGold5.transform.position = goldPos5.position;
                HandHoldGold5.transform.rotation = goldPos5.rotation;
                HandHoldGold5.GetComponent<Rigidbody>().isKinematic = true;
                break;
            case 6:
                HandHoldGold6.SetActive(true);
                HandHoldGold6.transform.position = goldPos6.position;
                HandHoldGold6.transform.rotation = goldPos6.rotation;
                HandHoldGold6.GetComponent<Rigidbody>().isKinematic = true;
                break;
            case 7:
                HandHoldGold7.SetActive(true);
                HandHoldGold7.transform.position = goldPos7.position;
                HandHoldGold7.transform.rotation = goldPos7.rotation;
                HandHoldGold7.GetComponent<Rigidbody>().isKinematic = true;
                break;
            case 8:
                HandHoldGold8.SetActive(true);
                HandHoldGold8.transform.position = goldPos8.position;
                HandHoldGold8.transform.rotation = goldPos8.rotation;
                HandHoldGold8.GetComponent<Rigidbody>().isKinematic = true;
                break;
        }
        var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
        RaycastHit hit;
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            
            if(pickedItem == null)
            {
                switch (showGold)
                {
                    case 1:
                        HandHoldGold1.GetComponent<Rigidbody>().isKinematic = false;
                           break;
                    case 2:
                        HandHoldGold2.GetComponent<Rigidbody>().isKinematic = false;
                        FPM.speed++;
                        FPM.runSpeed++;
                        break;
                    case 3:
                        HandHoldGold3.GetComponent<Rigidbody>().isKinematic = false;
                         break;
                    case 4:
                        HandHoldGold4.GetComponent<Rigidbody>().isKinematic = false;
                        FPM.speed++;
                        FPM.runSpeed++;
                        break;
                    case 5:
                        HandHoldGold5.GetComponent<Rigidbody>().isKinematic = false;
                       break;
                    case 6:
                        HandHoldGold6.GetComponent<Rigidbody>().isKinematic = false;
                        FPM.speed++;
                        FPM.runSpeed++;
                        break;
                    case 7:
                        HandHoldGold7.GetComponent<Rigidbody>().isKinematic = false;
                         break;
                    case 8:
                        HandHoldGold8.GetComponent<Rigidbody>().isKinematic = false;
                        FPM.speed++;
                        FPM.runSpeed++;
                        break;
                }
                goto nograbby;
            }
            DropItem(pickedItem);
        nograbby:;
            showGold--;
            howSlow--;
            
        }
        if (FPM.speed < 0)
        {
            FPM.speed = 0;
        }
        if(FPM.runSpeed < 0)
        {
            FPM.runSpeed = 0;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hit, 5f))
            {
                var pickable = hit.transform.GetComponent<PickableItem>();
               
                // If object has PickableItem class
                if (pickable && PickedUp == false)
                {
                    // Pick it
                    pickable.ParticleSystemOff = true;
                    PickItem(pickable);
                    PickedUp = true;
                }
                GC.ValueablePickup = true;
            }
            slot.rotation = new Quaternion();
            isUsingAxe = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            slot.rotation = Rotated.rotation;
            isUsingAxe = true;

        }
        if( PickedUp == true && doneOnce == false)
        {
            FPM.speed = 3 - howSlow;
            FPM.runSpeed = 5 -howSlow;
            doneOnce = true;
        }
        if( PickedUp == false && doneOnce == true)
        {
            FPM.speed = 5 - howSlow;
            FPM.runSpeed = 9 -howSlow;
            doneOnce = false;
        }
        if( recentGold >= HeavyValue)
        {
            FPM.speed--;
            FPM.runSpeed--;
            howSlow++;
            
            recentGold = 0;
        }
        if(howSlow < 0)
        {
            howSlow = 0;
        }
        if(showGold < 0)
        {
            showGold = 0;
        }
       // if (slot.GetChild(0).gameObject.activeInHierarchy == false)
        
          //  DropItem(slot.GetChild(0).gameObject.GetComponent<PickableItem>());
        
       
    }
    private void PickItem(PickableItem item)
    {
        // Assign reference
        pickedItem = item;
        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;
        // Set Slot as a parent
        item.transform.SetParent(slot);
        item.transform.localPosition = Vector3.zero;
        Physics.IgnoreCollision(item.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        item.transform.localEulerAngles = Vector3.zero;
        //  item.transform.localScale = handscale; 

    }
    private void DropItem(PickableItem item)
    {



        // Remove reference
        pickedItem = null;
        // Remove parent

        item.transform.SetParent(null);
        // Enable rigidbody
        item.Rb.isKinematic = false;
        // Add force to throw item a little bit


        item.Rb.AddForce(item.transform.forward * 4, ForceMode.VelocityChange);

        PickedUp = false;

        Physics.IgnoreCollision(item.GetComponent<Collider>(), GetComponent<Collider>(), false);

    }
}
