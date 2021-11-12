using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRando : MonoBehaviour
{
    public GameObject[] Walls;
    private int howmany;
  
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject wall in Walls)
        {
            wall.SetActive(false);
        }
        while (howmany < 5)
        {
            Walls[Random.Range(0, Walls.Length)].SetActive(true);
            howmany++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
