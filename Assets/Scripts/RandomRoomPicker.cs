using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoomPicker : MonoBehaviour
{
    int RoomChoice;
   public GameObject RandoRoom1, RandoRoom2, RandoRoom3;
    // Start is called before the first frame update
    void Start()
    {
        RoomChoice = Random.Range(1, 4);
        Debug.LogError(RoomChoice);
    }

    // Update is called once per frame
    void Update()
    {
        if(RoomChoice == 1)
        {
            
            RandoRoom2.SetActive(false);
            RandoRoom3.SetActive(false);
        }
        if(RoomChoice == 2)
        {
            RandoRoom1.SetActive(false);
            RandoRoom3.SetActive(false);
        }
        if (RoomChoice == 3)
        {
            RandoRoom1.SetActive(false);
            RandoRoom2.SetActive(false);
        }
    }
}
