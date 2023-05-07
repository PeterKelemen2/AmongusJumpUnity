using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public GameObject tile;
    int nrOfTiles = 0;
    private GameObject[] getCount;
    public GameObject camera;
    public GameObject player;
    bool movable = false;
    bool firstJumpDone = false;

    //private float speed = 2 * Time.deltaTime; // camera moving speed
    float currentPosX = 0;
    float currentPosY = 0;
    float currentPosZ = 0;

    public float currentHeight = 0;
    public float secondaryHeight = 0;

    public Transform target;
    public Vector3 offset;

    public GameObject tileCombination;

    void Start()
    {

        // getCount = GameObject.FindGameObjectsWithTag("tile");
        // Debug.Log("Number of tiles: " + getCount.Length);

        currentHeight = player.transform.position.y;
        secondaryHeight = currentHeight;

        Instantiate(tileCombination, 
            new Vector3(-7.6f, -0.4f, 56f),
            tileCombination.transform.rotation);

        /*
         Instantiate(animals[idx], 
            new Vector3(Random.Range(-17f,17f), 0, 20), 
            animals[idx].transform.rotation);*/

    }

    void Update()
    {
        currentHeight = player.transform.position.y;
        checkIfCameraMovable();

        // followPlayer();



        //Debug.Log("\nCurrent Height: " + currentHeight + "\n" + "Secondary Height: " + secondaryHeight);
        
    }

    /*
     currentHeight = player.transform.position.y;
        secondaryHeight = currentHeight;
     */

    public void checkIfCameraMovable()
    {
        // movable = false;

        if(currentHeight - secondaryHeight > 3.5f)
        {
            Debug.Log("Camera is movable!!");
            movable = true;

            // moveCamera();
            StartCoroutine(MoveFunction());

            secondaryHeight = currentHeight;
            
        }
        movable = false;
        
    }

    void followPlayer()
    {
        camera.gameObject.transform.position = target.position + offset;
    }

    public void moveCamera()
    {
        // first pos = 3.26f
        // desired second pos = 6.5f
        // = 3.24f movement

        if (movable && !firstJumpDone)
        {
            float step = 1 * Time.deltaTime;
            
            currentPosX = camera.transform.position.x;
            currentPosY = camera.transform.position.y;
            currentPosZ = camera.transform.position.z;

            // Translate oldPos = Vector3(currentPosX, currentPosY, currentPosZ);

            float toMove = currentHeight - secondaryHeight; // 3.4f;


            camera.transform.position = new Vector3(0f, currentPosY + toMove/2, -7f);
        }
        else
        {
            currentPosX = camera.transform.position.x;
            currentPosY = camera.transform.position.y;
            currentPosZ = camera.transform.position.z;

            float toMove = currentHeight - secondaryHeight;

            camera.transform.position = new Vector3(0f, currentPosY + toMove, -7f);
        }


        movable = false;
        
    }

    IEnumerator MoveFunction()
    {
        currentPosX = camera.transform.position.x;
        currentPosY = camera.transform.position.y;
        currentPosZ = camera.transform.position.z;

        // TODO: Ha elmenne a kamera, akkor a secondary height alapján
        // visszamenjen (*0,9f pl)

        float toMove = (currentHeight - secondaryHeight) * 0.7f;

        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            camera.transform.position = Vector3.Lerp(camera.transform.position, 
                new Vector3(0f, currentPosY + toMove, -7f), timeSinceStarted);

            // If the object has arrived, stop the coroutine
            if (camera.transform.position == new Vector3(0f, currentPosY + toMove, -7f))
            {
                StopAllCoroutines();
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }

    public void isDead()
    {
        if (secondaryHeight - currentHeight > 5f)
        {
            Debug.Log("You dead");
        }
    }

    
}

    