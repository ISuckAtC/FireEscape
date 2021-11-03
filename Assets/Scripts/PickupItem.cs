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
    public bool PickedUp, isUsingAxe, usedItem;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
        RaycastHit hit;
        if (usedItem == true)
        {
            pickedItem.transform.SetParent(null);
            // Remove reference
            pickedItem.unusable = true;
            pickedItem = null;
            // Remove parent

            
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
        
        
            
        
        if (slot.GetChild(0).gameObject.activeInHierarchy == false)
        {
            DropItem(slot.GetChild(0).gameObject.GetComponent<PickableItem>());
        }
       
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
