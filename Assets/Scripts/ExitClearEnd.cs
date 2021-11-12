using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitClearEnd : MonoBehaviour
{ public GameController GC;
    public GameObject goodText, badText, badestText;
    // Start is called before the first frame update
    void Start()
    {
        GC= GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GC.ManyValuables == true)
        {
            badestText.SetActive(true);
            badText.SetActive(false);
            goodText.SetActive(false);
        }
        if(GC.ValueablePickup == true && GC.ManyValuables == false)
        {
            goodText.SetActive(false);
            badText.SetActive(true);
        }
        if(GC.ValueablePickup == false)
        {
            goodText.SetActive(true);
            badText.SetActive(false);
        }
    }
}
