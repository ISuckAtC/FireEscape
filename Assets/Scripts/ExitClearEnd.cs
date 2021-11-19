using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitClearEnd : MonoBehaviour
{ public GameController GC;
    
    public Text ScoreCard;
    public Text GradeText;
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
        if(GC.Valuables >0 )
        {
            GradeText.text = "You Survived! but you also have burns that need" + "MoneyValue, replace later" + "To cover oops, guess you cant pay your bill!";
        }
        if(GC.Valuables == 0)
        {
            GradeText.text = "You Survived!";
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
