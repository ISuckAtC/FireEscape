using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text ScoreText;
    public GameController GC;
    public GoldFinderForUI GFFUI;
    public int actualGoldLength;
    public bool DoOnce;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = gameObject.GetComponent<Text>();
        GC = GameObject.Find("GameController").GetComponent<GameController>();
        GFFUI = GameObject.Find("GameController").GetComponent<GoldFinderForUI>();
        actualGoldLength = GFFUI.pickables.Length;
        Debug.Log(actualGoldLength);
        Debug.Log("GFFUI gold length " + GFFUI.pickables.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if(actualGoldLength == 0 )
        {
            actualGoldLength = GFFUI.pickables.Length;
            
        }
        GC.maxValuablesForPreviousLevel = actualGoldLength;
        ScoreText.text = "You've found " + GC.Valuables + "  out of " + actualGoldLength  + " valuables!";
    }
}
