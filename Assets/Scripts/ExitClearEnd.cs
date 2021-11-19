using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitClearEnd : MonoBehaviour
{ public GameController GC;
    public GameObject goodText, badText, badestText;
    public Text ScoreCard;
    public SpriteRenderer StampA, StampB, StampC, StampF;
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

    public void EndCardLoad()
    {
        ScoreCard.text = "";
        ScoreCard.text += "These are your results\n\n\n";
        ScoreCard.text += "You found " + GC.Valuables + "  out of " + GC.maxValuablesForPreviousLevel + " valuables\n\n";
        if (GC.Valuables == 0)
        {
            ScoreCard.text += "You escaped unscathed, congratulations on following good fire safety practices!\n\n";
            Invoke(nameof(GradeA), 5f);
        }
        else if (GC.Valuables < (GC.maxValuablesForPreviousLevel / 4f))
        {
            ScoreCard.text += "You managed to escape with little damage.\n\n";
            Invoke(nameof(GradeB), 5f);
        }
        else if (GC.Valuables < (GC.maxValuablesForPreviousLevel * 2f / 4f))
        {
            ScoreCard.text += "You got out, but the effects of the fire and smoke will take some time to recover.\n\n";
            Invoke(nameof(GradeC), 5f);
        }
        else
        {
            ScoreCard.text += "You spent too long looking for valuables, and you now have super cancer. You will die in 7 days.\n\n";
            Invoke(nameof(GradeF), 5f);
        }
    }
    public void GradeA()
    {
        StampA.enabled = true;
    }
    public void GradeB()
    {
        StampB.enabled = true;
    }
    public void GradeC()
    {
        StampC.enabled = true;
    }
    public void GradeF()
    {
        StampF.enabled = true;
    }
}
