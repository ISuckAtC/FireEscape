using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PowerOutage))]
public class ScenarioController : MonoBehaviour
{
    public float StartScenario;
    public int ScenarioSelection;
    private PowerOutage powerOutage;

    bool playedOnce;

    // Start is called before the first frame update
    void Start()
    {
        powerOutage = GetComponent<PowerOutage>();
        playedOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartScenario -= Time.deltaTime;

        if (StartScenario <= 0 && !playedOnce)
        {
            SelectScenario();
            playedOnce = true;
        }
    }

    void SelectScenario()
    {
        switch (ScenarioSelection)
        {
            case 0:
                // PowerOutage
                powerOutage.StartPowerOutage();
                break;

            default:
                break;
        }
    }
}
