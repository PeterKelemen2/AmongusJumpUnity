using System.Collections;
using System.Collections.Generic;
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

    //private float speed = 2 * Time.deltaTime; // camera moving speed
    float currentPosX = 0;
    float currentPosY = 0;
    float currentPosZ = 0;

    private float currentHeight = 0;
    private float secondaryHeight = 0;

    void Start()
    {

        // getCount = GameObject.FindGameObjectsWithTag("tile");
        // Debug.Log("Number of tiles: " + getCount.Length);

        currentHeight = player.transform.position.y;
        secondaryHeight = currentHeight;

    }

    void Update()
    {
        currentHeight = player.transform.position.y;
        checkIfCameraMovable();



        //Debug.Log("\nCurrent Height: " + currentHeight + "\n" + "Secondary Height: " + secondaryHeight);
        
    }

    /*
     currentHeight = player.transform.position.y;
        secondaryHeight = currentHeight;
     */

    public void checkIfCameraMovable()
    {
        movable = false;

        if(currentHeight - secondaryHeight > 3.2f)
        {
            Debug.Log("Camera is movable!!");
            movable=true;
            //moveCamera();
            StartCoroutine(MoveFunction());
            secondaryHeight = currentHeight;
            
        }

        
    }

    public void moveCamera()
    {
        // first pos = 3.26f
        // desired second pos = 6.5f
        // = 3.24f movement

        if (movable)
        {
            float step = 1 * Time.deltaTime;
            
            currentPosX = camera.transform.position.x;
            currentPosY = camera.transform.position.y;
            currentPosZ = camera.transform.position.z;

            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentPosX,currentPosY+3f, currentPosZ), step);
            camera.transform.Translate(
                Vector3.MoveTowards(new Vector3(currentPosX,currentPosY,currentPosZ),
                new Vector3(0f, currentPosY + 3, -7f), 
                1));
        }


        movable = false;
        
    }

    IEnumerator MoveFunction()
    {
        currentPosX = camera.transform.position.x;
        currentPosY = camera.transform.position.y;
        currentPosZ = camera.transform.position.z;

        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            camera.transform.position = Vector3.Lerp(camera.transform.position, 
                new Vector3(0f, currentPosY + 3, -7f), timeSinceStarted);

            // If the object has arrived, stop the coroutine
            if (camera.transform.position == new Vector3(0f, currentPosY + 2.7f, -7f))
            {
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
            //StopAllCoroutines();
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

    