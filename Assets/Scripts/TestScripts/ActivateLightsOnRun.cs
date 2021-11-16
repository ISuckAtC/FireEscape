using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLightsOnRun : MonoBehaviour
{
    public GameObject[] LightsToActivate;

    void update()
    {
        for (int i = 0; i < LightsToActivate.Length; i++)
        {
            LightsToActivate[i].SetActive(true);
        }
    }
}
