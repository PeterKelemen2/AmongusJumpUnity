using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tile;
    //int nrOfTiles = 0;
    

    // Start is called before the first frame update
    void Start()
    {

        /*
        GameObject tiles = Instantiate(tile, new Vector3(0,0,0),
                Quaternion.identity); // Spawning one in the center
        spawnTiles();
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnTiles()
    {
        for(int i=1; i<= 7; i++)
        {
            GameObject tiles = Instantiate(tile, new Vector3(Random.Range(-4,4),Random.Range(0,7),0),
                Quaternion.identity);
        }

    }

}

    