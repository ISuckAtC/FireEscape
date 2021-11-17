using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitClearEnd : MonoBehaviour
{ public GameController GC;
    public GameObject goodText, badText, badestText;
    public Text ScoreCard;
    // Start is called before the first frame update
    void Start()
    {
        GC= GameObject.Find("GameController").GetComponent<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if(GC.ManyValuables == true)
        {
            badestText.SetActive(true);
            badText.SetActive(false);
            goodText.SetActive(false);
        }*/
        if(GC.ValueablePickup == true /*&& GC.ManyValuables == false*/)
        {
            goodText.SetActive(false);
            badText.SetActive(true);
         //   badestText.SetActive(false);
        }
        if(GC.ValueablePickup == false)
        {
            goodText.SetActive(true);
            badText.SetActive(false);
           // badestText.SetActive(false);
        }
        if(GC.Valuables == 0)
        {
            ScoreCard.text = "you did what you were supposed to do.";
            goto Winner;
        }
        ScoreCard.text = "You found " + GC.Valuables + "  out of " + GC.maxValuablesForPreviousLevel + " valuables in the previous level!";
    Winner:;
    }
}
