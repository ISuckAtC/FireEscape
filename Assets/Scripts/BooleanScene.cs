using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BooleanScene : MonoBehaviour
{
    public static BooleanScene instance;
    [Header("True to hold, false to vacuum")]
    public bool HoldorVacuum;
        public bool Level2;
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
        if(SceneManager.GetActiveScene().name == "Level2")
        {
            Level2 = true;
        }
        else
        {

        }
    }
}
