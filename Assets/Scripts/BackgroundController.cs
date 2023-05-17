using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // spawning starts from (0,11,10)
    public GameObject galaxyBackground;
    public GameObject gradientBackground;
    public GameObject skyBackground;
    public GameObject camera;

    private GameObject toDelete;

    private float offset = 38f;
    private float offsetVar = 38f;
    [SerializeField] private float firstY;
    [SerializeField] private float secondY;

    [SerializeField] private List<GameObject> SpawnedObjects = new List<GameObject>();
    private int MaxAmountOfObjects = 15;

    private bool hasRun = false;
    private bool bcChanged = false;
    private int untilChange = 3;

    private int i = 0;

    void Start()
    {
        firstY = camera.transform.position.y;
        secondY = firstY;

        // InvokeRepeating("checkIfSpawnable", 0, 1);
        // Instantiate(background, new Vector3(0, 11f, 10f), background.transform.rotation);

        
    }

    // Update is called once per frame
    void Update()
    {
        firstY = camera.transform.position.y;
        //spawnBackground();
        checkIfSpawnable();
    }

    public void checkIfSpawnable()
    {
        if ((firstY - secondY) >= 27f)
        {
            Debug.Log("Background piece spawnable !");
            if(untilChange > 0)
            {
                spawnBackground(skyBackground);
                untilChange--;
            }
            else
            {
                if(untilChange == 0)
                {
                    spawnBackground(gradientBackground);
                    bcChanged = true;
                    untilChange--;
                }
                if (bcChanged)
                {
                    spawnBackground(galaxyBackground);
                }
            }  
        }
    }

    public void spawnBackground(GameObject gameObject)
    {

        Debug.Log("spawnBackground");
        Vector3 desiredDirection = new Vector3(0, 11f + offset, 10f);

        GameObject back = Instantiate(gameObject,
            desiredDirection,
            gameObject.transform.rotation);

        SpawnedObjects.Add(back);

        secondY = firstY;

        offset += offsetVar;

        // destroyFirstInstance(); 
        //destroyIfNotOnScreen();
        destroyIfLowEnough();
    }

    public void destroyFirstInstance()
    {
        if (SpawnedObjects.Count == MaxAmountOfObjects)
        {
            Debug.Log(SpawnedObjects.Count);
            
            Destroy(SpawnedObjects[0].gameObject);
            SpawnedObjects.RemoveAt(0);
        }
    }

    public void destroyIfLowEnough()
    {
        if(camera.transform.position.y - SpawnedObjects[0].transform.position.y > 50f)
        {
            Destroy(SpawnedObjects[0].gameObject);
            SpawnedObjects.RemoveAt(0);
        }
    }

    public void destroyIfNotOnScreen()
    {
        for(int i = 0; i< SpawnedObjects.Count; i++)
        {
            if(firstY - SpawnedObjects[i].transform.position.y > 30f)
            {
                // DestroyImmediate(SpawnedObjects[i]);
            }
        }
    }

}
