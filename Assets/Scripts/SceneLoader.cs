using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Prototype1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Prototype2()
    {
        SceneManager.LoadScene("Level1_HoldGold");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
