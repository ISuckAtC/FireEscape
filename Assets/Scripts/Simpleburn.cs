using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Simpleburn : MonoBehaviour
{
    public float deathTimer, maxTime ;
    private bool inFire;
    private float currentDamageTime;
    public float damageInterval;
    private bool damageFlashed;
    public float damageLength;
    public float initialFlashTimer;
    public Image fireOverlay;
    public PickupItem Player;
    public AudioSource PlayerAudio;
    public int DamageSoundInterval;
    public AudioClip[] DamageSounds;
    private int currentDamageSoundInterval;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PickupItem>();
        PlayerAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        fireOverlay = GameObject.Find("FireOverlay").GetComponent<Image>();
        deathTimer = 0;
        maxTime = 4;
        
        currentDamageTime = damageInterval - initialFlashTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (inFire)
        {
            if (currentDamageTime < damageInterval)
            {
                if (damageFlashed && currentDamageTime > damageLength)
                {
                    damageFlashed = false;
                    fireOverlay.enabled = false;
                }
                currentDamageTime += Time.deltaTime;
            }
            else
            {
                currentDamageTime = 0;
                fireOverlay.enabled = true;
                damageFlashed = true;
                if (++currentDamageSoundInterval > DamageSoundInterval)
                {
                    currentDamageSoundInterval = 0;
                    if (DamageSounds.Length > 0)
                    {
                        PlayerAudio.PlayOneShot(DamageSounds[Random.Range(0, DamageSounds.Length)]);
                    }
                    else
                    {
                        Debug.LogWarning("There are no damage sounds assigned to SimpleBurn component on " + gameObject.name);
                    }
                }
            }
        }   
    }
   
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") 
        {
            inFire = true;
            Player.FireTime += Time.deltaTime;
            this.deathTimer += Time.deltaTime;
        }
        
        
        if (other.tag == "Player" && deathTimer > maxTime)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            deathTimer = 0;
            inFire = false;
            currentDamageTime = damageInterval - initialFlashTimer;
            currentDamageSoundInterval = DamageSoundInterval - 1;
            fireOverlay.enabled = false;
        }
    }
}
