using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tiles;
    int nrOfTiles = 0;


    // Start is called before the first frame update
    void Start()
    {
        /*
        GameObject tile = Instantiate(tiles, // to spawn one from the start
                new Vector3(0f, -66f, 130f),
                Quaternion.identity);
        */
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnTiles()
    {
        while (nrOfTiles < 4)
        {
            GameObject tile = Instantiate(tiles,
                new Vector3(Random.Range(-106f, 106f), Random.Range(-66f, 73f), 130f),
                Quaternion.identity);
        }
    }

    Vector3 initialPosition = new Vector3(0f, -66f, 130f);
    GameObject prefab = (GameObject)Resources.Load("myPrefabName");

    public bool SpaceAvailable(Vector3 position, Collider col)
    {
        Vector3 colliderSize = new Vector3(col.bounds.extent.x, col.bounds.extent.y, col.bounds.extent.z);
        bool fits = true;

        if (RayCast(initialPosition, new Vector3(1, 0, 0), colliderSize.x))
        { //Not sure about this line
            fits = false;
        }
        if (RayCast(initialPosition, new Vector3(0, 1, 0), colliderSize.y))
        {
            fits = false;
        }
        if (RayCast(initialPosition, new Vector3(0, 0, 1), colliderSize.z))
        {
            fits = false;
        }
        //This will cast a ray from the position into three directions, 
        //you need to do it 3 more times with the negative 1s. if ANY of these is
        //true, fits is false, and you need to either change the initialPosition or 
        //cancel the instanciation.
        return fits;
    }

    public void TryInstanciate(GameObject obj, Vector3 position)
    {
        if (SpaceAvailable(position, obj.collider))
        {
            GameObject tile = Instantiate(tiles,
                new Vector3(Random.Range(-106f, 106f), Random.Range(-66f, 73f), 130f),
                Quaternion.identity);
        }
    }

    
}

    