using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text ScoreText;
    public PickupItem PI;
    public GoldFinderForUI GFFUI;
    public int actualGoldLength;
    private bool DoOnce;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = gameObject.GetComponent<Text>();
        PI = GameObject.FindGameObjectWithTag("Player").GetComponent<PickupItem>();
        GFFUI = GameObject.Find("GameController").GetComponent<GoldFinderForUI>();
        
        Debug.Log(actualGoldLength);
    }

    // Update is called once per frame
    void Update()
    {
        if(DoOnce == false)
        {
            actualGoldLength = GFFUI.pickables.Length;
            DoOnce = true;
        }
        
        ScoreText.text = "You've found " + PI.Gold + "  out of " + actualGoldLength  + " valuables!";
    }
}
