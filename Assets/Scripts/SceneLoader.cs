using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public BooleanScene BS;
    public GameController GC;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        BS = GameObject.FindGameObjectWithTag("GameController").GetComponent<BooleanScene>();
        GC = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Prototype1()
    {
        BS.HoldorVacuum = false;
        GC.Valuables = 0;
        SceneManager.LoadScene("Level1");
    }
    public void Prototype2()
    {
        BS.HoldorVacuum = true;
        GC.Valuables = 0;
        SceneManager.LoadScene("Level1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GC.Valuables = 0;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(4);
    }

    public void LightsOutScene()
    {
        SceneManager.LoadScene("level1_LightsOutP");
        GC.Valuables = 0;
    }
}
