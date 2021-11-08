using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BooleanScene : MonoBehaviour
{
    public BooleanScene instance;
    [Header("True to hold, false to vacuum")]
    public bool HoldorVacuum;
    void Awake()
 {
      if(instance == null)
      {
           instance = this;
           DontDestroyOnLoad(gameObject);
      }else if(instance != this)
      {
           Destroy(gameObject);
      }
 }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            HoldorVacuum = false;
        }
        if (SceneManager.GetActiveScene().name == "Level1_HoldGold")
        {
            HoldorVacuum = true;
        }
    }
}
