using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BasicSpreadingFire : MonoBehaviour
{
    public bool KillThem;
    private float FireSpread = 5;
    private GameObject childFire;
    // Start is called before the first frame update
    void Start()
    {
        childFire = gameObject.transform.GetChild(0).gameObject;
        if (childFire != null)
        {
            childFire.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        FireSpread -= Time.deltaTime;
        if(FireSpread <= 0 &&childFire != null)
        {
            childFire.SetActive(true);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && KillThem == true)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}
