using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Continue : MonoBehaviour
{
    public BooleanScene BS;
    // Start is called before the first frame update
    void Start()
    {
        BS = GameObject.FindGameObjectWithTag("GameController").GetComponent<BooleanScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && BS.Level2 == true)
        {
            SceneManager.LoadScene("Level2");
        }
        if (Input.GetKeyUp(KeyCode.Space) && BS.Level2 == false)
        {
            SceneManager.LoadScene("Level1");
        }
          
    }
}
