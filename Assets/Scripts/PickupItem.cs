using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private Camera characterCamera;
    [SerializeField]
    private Transform slot, Rotated;
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
    
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        switch( showGold)
        {
            case 1:
                HandHoldGold1.SetActive(true);
                break;
            case 2:
                HandHoldGold2.SetActive(true);
                break;
            case 3:
                HandHoldGold3.SetActive(true);
                break;
            case 4:
                HandHoldGold4.SetActive(true);
                break;
            case 5:
                HandHoldGold5.SetActive(true);
                break;
            case 6:
                HandHoldGold6.SetActive(true);
                break;
            case 7:
                HandHoldGold7.SetActive(true);
                break;
            case 8:
                HandHoldGold8.SetActive(true);
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
                         break;
                    case 3:
                        HandHoldGold3.GetComponent<Rigidbody>().isKinematic = false;
                         break;
                    case 4:
                        HandHoldGold4.GetComponent<Rigidbody>().isKinematic = false;
                       break;
                    case 5:
                        HandHoldGold5.GetComponent<Rigidbody>().isKinematic = false;
                       break;
                    case 6:
                        HandHoldGold6.GetComponent<Rigidbody>().isKinematic = false;
                       break;
                    case 7:
                        HandHoldGold7.GetComponent<Rigidbody>().isKinematic = false;
                         break;
                    case 8:
                        HandHoldGold8.GetComponent<Rigidbody>().isKinematic = false;
                        break;
                }
                goto nograbby;
            }
            DropItem(pickedItem);
        nograbby:;
            showGold--;
            howSlow--;
            
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
