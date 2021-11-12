using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScenarioController))]
public class PowerOutage : MonoBehaviour
{
    public GameObject[] lightsSources;
    public AudioSource PlayerAudioSource;

    [SerializeField] AudioClip ElectricSparkSFX;

    public void StartPowerOutage()
    {
        StartCoroutine(PowerOutageSequence());
    }

    IEnumerator PowerOutageSequence()
    {
        yield return new WaitForSeconds(2f);

        if (!PlayerAudioSource.isPlaying)
        {
            PlayerAudioSource.PlayOneShot(ElectricSparkSFX, 0.5f);
        }

        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < lightsSources.Length; i++)
        {
            // Removing lights
            Destroy(lightsSources[i]);
        }

        yield return new WaitForSeconds(2f);

        Debug.Log("Text");
    }
}
