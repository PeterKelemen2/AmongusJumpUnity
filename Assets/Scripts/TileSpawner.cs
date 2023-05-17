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

    private int MaxAmountOfObjects = 5;
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
            playerPosAux = playerPosY - 0.1f;
            selectTilesBetween(1, 4);
        }
        destroyIfLowEnough();
    }

    void spawnTileCombination(GameObject gameObject)
    {
        if (firstSpawn)
        {    

            GameObject spawnTile = Instantiate(gameObject,
                new Vector3(0f, 7f, 0f),
                Quaternion.identity);

            SpawnedObjects.Add(spawnTile.gameObject);

            firstSpawn = false;
            
        }
        else
        {
            GameObject spawnTile = Instantiate(gameObject,
                new Vector3(0f, 7f + spawnOffset, 0f),
                Quaternion.identity);

            SpawnedObjects.Add(spawnTile.gameObject);

            spawnOffset += 8f;

            //destroyFirstInstance();
            destroyIfLowEnough();
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


    public void destroyIfLowEnough()
    {
        if(camera.transform.position.y - SpawnedObjects[0].transform.position.y > 20f)
        {
            Destroy(SpawnedObjects[0].gameObject);
            SpawnedObjects.RemoveAt(0);
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
