using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject TC1;
    public GameObject TC2;
    public GameObject TC3;
    public GameObject TC4;
    private GameObject currentTiles;
    private float currentTilesPosY;
    private GameObject previousTiles;
    private GameObject previousPreviousTiles;
    private float previousTilesPosY;
    private bool firstSpawn = true;
    private float spawnOffset = 8f;
    private bool thirdSpawn = false;

    public GameObject player;
    public float playerPosY;
    public float playerPosAux;

    public GameObject camera;

    private GameObject[] getCount;

    private int MaxAmountOfObjects = 20;
    private List<GameObject> SpawnedObjects = new List<GameObject>();

    void Start()
    {
        playerPosAux = player.transform.position.y;

        spawnTileCombination(TC1);
        
    }
    void Update()
    {

        playerPosY = player.transform.position.y;
        //currentTilesPosY = currentTiles.transform.position.y;
        //previousTilesPosY = previousTiles.transform.position.y;

        
        if(playerPosY - playerPosAux > 4f) 
        {
            // if the player moved enough so that he wouldn't
            // see it pop in

            playerPosAux = playerPosY - 0.1f;
            selectTilesBetween(0, 4);
            // Debug.Log("SHOULD SPAWN A TILE COMBINATION!!");

        }

    }

    void spawnTileCombination(GameObject gameObject)
    {
        if (firstSpawn)
        {
            //manageTiles(gameObject);

            GameObject spawnTile = Instantiate(gameObject,
                new Vector3(0f, 7f, 0f),
                Quaternion.identity);

            SpawnedObjects.Add(spawnTile.gameObject);

            firstSpawn = false;
            
        }
        else
        {
            //manageTiles(gameObject);

            GameObject spawnTile = Instantiate(gameObject,
                new Vector3(0f, 7f + spawnOffset, 0f),
                Quaternion.identity);

            SpawnedObjects.Add(spawnTile.gameObject);

            spawnOffset += 8f;

            destroyFirstInstance();

        }
        
    }

    public void destroyFirstInstance()
    {
        if (SpawnedObjects.Count == MaxAmountOfObjects)
        {
            //Debug.Log(SpawnedObjects.Count);

            Destroy(SpawnedObjects[0].gameObject);
            SpawnedObjects.RemoveAt(0);
        }
    }


    public void manageTiles(GameObject gameObject)
    {
        getCount = GameObject.FindGameObjectsWithTag("TileComb");
        int count = getCount.Length;


        if (count >= 3)
        {
            previousPreviousTiles = previousTiles;
            previousTiles = currentTiles;
            currentTiles = gameObject;

            DestroyImmediate(previousPreviousTiles, true);
        }
        else
        {
            previousTiles = currentTiles;
            currentTiles = gameObject;
        }


    }

    public void selectTilesBetween(int min, int max)
    {
        int next = Random.Range(min, max);

        switch (next)
        {
            case 1:
                spawnTileCombination(TC1);
                break;
            case 2:
                spawnTileCombination(TC2);
                break;
            case 3:
                spawnTileCombination(TC3);
                break;
            case 4:
                spawnTileCombination(TC4);
                break;
        }
    }
}
