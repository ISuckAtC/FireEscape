using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoomPicker : MonoBehaviour
{
    int RoomChoice;
    public BooleanScene BS;
   public GameObject[] RandoRoom;
    // Start is called before the first frame update
    void Start()
    {
        BS = GameObject.Find("GameController").GetComponent<BooleanScene>(); ;
        RoomChoice = Random.Range(1, RandoRoom.Length);
        Debug.LogError(RoomChoice);
    }

    // Update is called once per frame
    void Update()
    {
       
       foreach(GameObject room in RandoRoom)
        {
            room.SetActive(false);

        }
        RandoRoom[RoomChoice].SetActive(true);
    }
}
