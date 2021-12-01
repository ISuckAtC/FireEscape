using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitClearEnd : MonoBehaviour
{ 
    public GameController GC;
    
    public Text ScoreCard;
    public Text GradeText;
    public GameObject goodText, badText, badestText;
    public Text TimerCard;
    public Image firstBill, secondBill, thirdBill, winScreen;
    public bool Old;
    // Start is called before the first frame update
    void Start()
    {
        GC = GameObject.Find("GameController").GetComponent<GameController>();
        firstBill.enabled = false;
        secondBill.enabled = false;
        thirdBill.enabled = false;
        winScreen.enabled = false;
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
           // ScoreCard.text += "You escaped unscathed, congratulations on following good fire safety practices!\n\n";
            winScreen.enabled = true;
        }
        else if (GC.Valuables < (GC.maxValuablesForPreviousLevel / 4f))
        {
           // ScoreCard.text += "You managed to escape, however, you have first degree burn marks all over your body and a few second degree ones, the items you picked can only cover for the drive to the hospital (yeah they charge that).";
            firstBill.enabled = true;
        }
        else if (GC.Valuables < (GC.maxValuablesForPreviousLevel * 2f / 4f))
        {
            //ScoreCard.text += "You got out but have several second degree burns on your body, you will mostly likely need surgical intervention, the items you picked up will cover around 30% of the costs.";
            secondBill.enabled = true;
        }
        else
        {
            //ScoreCard.text += "You barely managed to escape, you have severe burns all over your body, you'll need immediate surgical intervention and might be incapacitated for the rest of your life, the items you picked up cover 15% of the costs, also you got aids unfortunately..";
            thirdBill.enabled = true;
        }
    }
    //public IEnumerator GradeA()
    //{
    //    yield return new WaitForSeconds(2f);
    //    Vector3 scale = StampA.transform.localScale;
    //    StampA.transform.localScale = Vector3.zero;
    //    StampA.enabled = true;
    //    while (scale != StampA.transform.localScale)
    //    {
    //        StampA.transform.localScale = Vector3.MoveTowards(StampA.transform.localScale, scale, Time.deltaTime * 2f);
    //        yield return null;
    //    }
    //}
    //public IEnumerator GradeB()
    //{
    //    yield return new WaitForSeconds(2f);
    //    Vector3 scale = StampB.transform.localScale;
    //    StampB.transform.localScale = Vector3.zero;
    //    StampB.enabled = true;
    //    while (scale != StampB.transform.localScale)
    //    {
    //        StampB.transform.localScale = Vector3.MoveTowards(StampB.transform.localScale, scale, Time.deltaTime * 2f);
    //        yield return null;
    //    }
    //}
    //public IEnumerator GradeC()
    //{
    //    yield return new WaitForSeconds(2f);
    //    Vector3 scale = StampC.transform.localScale;
    //    StampC.transform.localScale = Vector3.zero;
    //    StampC.enabled = true;
    //    while (scale != StampC.transform.localScale)
    //    {
    //        StampC.transform.localScale = Vector3.MoveTowards(StampC.transform.localScale, scale, Time.deltaTime * 2f);
    //        yield return null;
    //    }
    //}
    //public IEnumerator GradeF()
    //{
    //    yield return new WaitForSeconds(2f);
    //    Vector3 scale = StampF.transform.localScale;
    //    StampF.transform.localScale = Vector3.zero;
    //    StampF.enabled = true;
    //    while (scale != StampF.transform.localScale)
    //    {
    //        StampF.transform.localScale = Vector3.MoveTowards(StampF.transform.localScale, scale, Time.deltaTime * 2f);
    //        yield return null;
    //    }
    }

