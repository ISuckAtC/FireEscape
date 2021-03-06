using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private Camera characterCamera;
    [SerializeField]
    private Transform slot, Rotated, goldPos1, goldPos2, goldPos3, goldPos4, goldPos5, goldPos6, goldPos7, goldPos8;
    public PickableItem pickedItem;
    public GameObject HandHoldGold1, HandHoldGold2, HandHoldGold3, HandHoldGold4, HandHoldGold5, HandHoldGold6, HandHoldGold7, HandHoldGold8;
    public bool PickedUp, isUsingAxe, usedItem, doneOnce, Extinguisher, FailedExtinguisher;
    [Header("how many valuables do you want the player to pickup to be slowed down?")]
    public int HeavyValue;
    [Header("Just keeping track of our gold")]
    public int Gold;
    public int recentGold;
    public int howSlow, showGold;
    public FirstPersonMovement FPM;
    public GameController GC;
    public GameObject FireExtinguisher;
    [Header("Keeping Track of how long we have been in either the Fire or Smoke")]
    public float FireTime, SmokeTime;
    [Header("Just tells us if the FireExtinguisher failed or not, is rolled every pickup")]
    public int RNG;

    public Text PickupHint;
    private bool displayHint;
    private AudioSource playerAudio;
    public AudioClip ExtinguisherPickupSound;
    public AudioClip ExtinguisherDropSound;
    public GameObject FireExtinguisherPrefab;
    private bool droppedLastFrame;


    // Start is called before the first frame update
    void Start()
    {

        GC = GameObject.Find("GameController").GetComponent<GameController>();
        PickupHint = GameObject.FindGameObjectWithTag("PickupText").GetComponent<Text>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (SmokeTime == 0.02f)
        {
            SmokeTime = 0;
        }
        if (Extinguisher == false)
        {
            FireExtinguisher.SetActive(false);
        }
        if (Extinguisher == true)
        {
            FireExtinguisher.SetActive(true);
        }
        /*
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
        }*/
        var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
        RaycastHit hit;
        if (Input.GetKeyUp(KeyCode.E))
        {

            if (pickedItem == null)
            {
                if (Extinguisher)
                {
                    playerAudio.PlayOneShot(ExtinguisherDropSound);
                    Instantiate(FireExtinguisherPrefab, transform.position + (transform.forward * 2f), Quaternion.identity);
                    droppedLastFrame = true;
                }
                Extinguisher = false;
                /*  switch (showGold)
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
                  }*/
                goto nograbby;
            }
            DropItem(pickedItem);
        nograbby:;
            showGold--;
            howSlow--;

        }
        if (FPM.speed < 1)
        {
            FPM.speed = 1;
        }
        if (FPM.runSpeed < 1)
        {
            FPM.runSpeed = 1;
        }

        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.transform.tag == "Extinguisher")
            {
                if (!displayHint)
                {
                    PickupHint.text = "Press E to pick up the Extinguisher";
                    displayHint = true;
                }
            }
            else if (displayHint)
            {
                PickupHint.text = "";
                displayHint = false;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (hit.transform.tag == "Extinguisher")
                {
                    if (!droppedLastFrame)
                    {
                        playerAudio.PlayOneShot(ExtinguisherPickupSound);
                        Extinguisher = true;
                        RNG = Random.Range(1, 100);
                        FireExtinguisher.GetComponent<Extinguisher>().doOnce = false;
                        hit.transform.GetComponent<DummyDisable>().DisableMe = true;
                        goto noPickup;
                    }
                    else droppedLastFrame = false;
                }
                if (hit.transform.GetComponent<GoldPickup>().PickupA == false)
                {
                    // hit.transform.GetComponent<BoxCollider>().enabled = false;
                    //  hit.transform.GetComponent<GoldPickup>().shrinkEm = true;
                    // hit.transform.position = gameObject.transform.position;
                    goto noPickup;
                }
                var pickable = hit.transform.GetComponent<PickableItem>();

                // If object has PickableItem class
                if (pickable && PickedUp == false)
                {
                    // Pick it
                    pickable.ParticleSystemOff = true;
                    PickItem(pickable);
                    PickedUp = true;
                }
            noPickup:;
                GC.ValueablePickup = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            slot.rotation = new Quaternion();
            isUsingAxe = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            slot.rotation = Rotated.rotation;
            isUsingAxe = true;

        }
        if (RNG < 50)
        {
            FailedExtinguisher = true;
        }
        if (RNG > 50)
        {
            FailedExtinguisher = false;
        }
        if (PickedUp == true && doneOnce == false)
        {
            //   FPM.speed = 3 - howSlow;
            //   FPM.runSpeed = 5 -howSlow;
            doneOnce = true;
        }
        if (PickedUp == false && doneOnce == true)
        {
            //    FPM.speed = 5 - howSlow;
            //  FPM.runSpeed = 9 -howSlow;
            doneOnce = false;
        }
        if (recentGold >= HeavyValue)
        {
            //   FPM.speed--;
            //  FPM.runSpeed--;
            // howSlow++;

            recentGold = 0;
        }
        if (Gold >= 5)
        {
            GC.ManyValuables = true;
        }
        if (howSlow < 0)
        {
            howSlow = 0;
        }
        if (showGold < 0)
        {
            showGold = 0;
        }
        // if (slot.GetChild(0).gameObject.activeInHierarchy == false)

        //  DropItem(slot.GetChild(0).gameObject.GetComponent<PickableItem>());


    }
    private void PickItem(PickableItem item)
    {

        // Check tag of item, if fire extinguisher use that

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
