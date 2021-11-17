using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public BooleanScene BS;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        BS = GameObject.FindGameObjectWithTag("GameController").GetComponent<BooleanScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Prototype1()
    {
        BS.HoldorVacuum = false;
        SceneManager.LoadScene("Level1");
    }
    public void Prototype2()
    {
        BS.HoldorVacuum = true;
        SceneManager.LoadScene("Level1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(4);
    }

    public void LightsOutScene()
    {
        SceneManager.LoadScene("level1_LightsOutP");
    }
}
