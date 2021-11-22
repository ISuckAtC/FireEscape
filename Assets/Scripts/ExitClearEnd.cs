using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitClearEnd : MonoBehaviour
{ public GameController GC;
    
    public Text ScoreCard;
    public Text GradeText;
    public GameObject goodText, badText, badestText;
    public Text TimerCard;
    public Image StampA, StampB, StampC, StampF;
    public bool Old;
    // Start is called before the first frame update
    void Start()
    {
        GC = GameObject.Find("GameController").GetComponent<GameController>();
        EndCardLoad();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Old) return;
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
        /* if(GC.ManyValuables == true)
         {
             badestText.SetActive(true);
             badText.SetActive(false);
             goodText.SetActive(false);
         }*/
        if (GC.ValueablePickup == true /*&& GC.ManyValuables == false*/)
        {
            goodText.SetActive(false);
            badText.SetActive(true);
            //   badestText.SetActive(false);
        }
        if (GC.ValueablePickup == false)
        {
            goodText.SetActive(true);
            badText.SetActive(false);
            // badestText.SetActive(false);
        }
        if (GC.Valuables == 0)
        {
            ScoreCard.text = "you did what you were supposed to do.";
            goto Winner;
        }
        ScoreCard.text = "You picked up " + GC.Valuables + "  out of " + GC.maxValuablesForPreviousLevel + " valuables in the previous level!";
    Winner:;
    }

    public void EndCardLoad()
    {
        ScoreCard.text = "";
        ScoreCard.text += "These are your results\n\n";

        System.DateTimeOffset endTime = System.DateTimeOffset.Now;
        System.TimeSpan timeSpan = endTime - GC.startTime;
        TimerCard.text = "You took " + (timeSpan.ToString("mm") != "00" ? timeSpan.ToString("mm") + " minutes and " : "") + timeSpan.ToString("ss") + " seconds to get out";

        if (GC.Valuables == 0)
        {
            ScoreCard.text += "You escaped unscathed, congratulations on following good fire safety practices!\n\n";
            StartCoroutine(GradeA());
        }
        else if (GC.Valuables < (GC.maxValuablesForPreviousLevel / 4f))
        {
            ScoreCard.text += "You managed to escape with little damage. The things you brought with you can cover the medical bills. If you manage to convince them they are actually yours, that is\nYou could have been more efficient!\n\n";
            StartCoroutine(GradeB());
        }
        else if (GC.Valuables < (GC.maxValuablesForPreviousLevel * 2f / 4f))
        {
            ScoreCard.text += "You got out, but the effects of the fire and smoke will take some time to recover. Your items arent enough to cover the cost of your medical bills.\nDo better next time!\n\n";
            StartCoroutine(GradeC());
        }
        else
        {
            ScoreCard.text += "You spent too long looking for valuables, and you now have super cancer. You will die in 7 days.\nThis could have been avoided...\n\n";
            StartCoroutine(GradeF());
        }
    }
    public IEnumerator GradeA()
    {
        yield return new WaitForSeconds(2f);
        Vector3 scale = StampA.transform.localScale;
        StampA.transform.localScale = Vector3.zero;
        StampA.enabled = true;
        while (scale != StampA.transform.localScale)
        {
            StampA.transform.localScale = Vector3.MoveTowards(StampA.transform.localScale, scale, Time.deltaTime * 2f);
            yield return null;
        }
    }
    public IEnumerator GradeB()
    {
        yield return new WaitForSeconds(2f);
        Vector3 scale = StampB.transform.localScale;
        StampB.transform.localScale = Vector3.zero;
        StampB.enabled = true;
        while (scale != StampB.transform.localScale)
        {
            StampB.transform.localScale = Vector3.MoveTowards(StampB.transform.localScale, scale, Time.deltaTime * 2f);
            yield return null;
        }
    }
    public IEnumerator GradeC()
    {
        yield return new WaitForSeconds(2f);
        Vector3 scale = StampC.transform.localScale;
        StampC.transform.localScale = Vector3.zero;
        StampC.enabled = true;
        while (scale != StampC.transform.localScale)
        {
            StampC.transform.localScale = Vector3.MoveTowards(StampC.transform.localScale, scale, Time.deltaTime * 2f);
            yield return null;
        }
    }
    public IEnumerator GradeF()
    {
        yield return new WaitForSeconds(2f);
        Vector3 scale = StampF.transform.localScale;
        StampF.transform.localScale = Vector3.zero;
        StampF.enabled = true;
        while (scale != StampF.transform.localScale)
        {
            StampF.transform.localScale = Vector3.MoveTowards(StampF.transform.localScale, scale, Time.deltaTime * 2f);
            yield return null;
        }
    }
}
