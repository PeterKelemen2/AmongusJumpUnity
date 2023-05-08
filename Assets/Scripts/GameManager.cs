using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
// using UnityEditor.UIElements;
using UnityEngine;

using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public GameObject tile;
    private GameObject[] getCount;
    public GameObject camera;
    public GameObject player;
    public GameObject uiController;
    public bool isDead = false;
    private bool movable = false;


    //background.GetComponent<RepeatBackground>().enabled= false;



    //private float speed = 2 * Time.deltaTime; // camera moving speed
    float currentPosX = 0;
    float currentPosY = 0;
    float currentPosZ = 0;

    public float currentHeight = 0;
    public float secondaryHeight = 0;
    public float maxHeight = 0;
    private float toMove;

    public Transform target;
    public Vector3 offset;
    public float cameraY;

    public GameObject tileCombination;

    void Start()
    {

        // getCount = GameObject.FindGameObjectsWithTag("tile");
        // Debug.Log("Number of tiles: " + getCount.Length);

        currentHeight = player.transform.position.y;
        secondaryHeight = currentHeight;

        /*
         Instantiate(tileCombination, 
            new Vector3(-7.6f, -0.4f, 56f),
            tileCombination.transform.rotation);
        */

        /*
         Instantiate(animals[idx], 
            new Vector3(Random.Range(-17f,17f), 0, 20), 
            animals[idx].transform.rotation);*/

    }

    void Update()
    {
        currentHeight = player.transform.position.y;
        cameraY = camera.transform.position.y;

        getMaxHeight();
        checkIfCameraMovable();

        checkIfDead();
        //Debug.Log("\nCurrent Height: " + currentHeight + "\n" + "Secondary Height: " + secondaryHeight);
        
    }

    public int calculatePlayerPoints()
    {
        
        int points = Convert.ToInt32(maxHeight);
        // Debug.Log("Points: " + points);
        return points;

    }

    public void checkIfCameraMovable()
    {
        if(currentHeight - secondaryHeight > 3.6f)
        {
            Debug.Log("Camera is movable!!");
            movable = true;

            StartCoroutine(MoveCamera());

            secondaryHeight = currentHeight;
            
        }
        movable = false;
    }

    void followPlayer()
    {
        camera.gameObject.transform.position = target.position + offset;
    }

    public void getMaxHeight() // Calculates the maximum height the player has reached
    {
        if (currentHeight > maxHeight)
        {
            maxHeight = currentHeight;    
        }

    }

    IEnumerator MoveCamera()
    {
        currentPosX = camera.transform.position.x;
        currentPosY = camera.transform.position.y;
        currentPosZ = camera.transform.position.z;

        /*
         * Camera's default Y is 3.25
         * If the player's maximum differs by 3 from camera Y,
         * Then the camera should move more
         */

        if (maxHeight - currentPosY > 3f)
        {
            toMove = (currentHeight - secondaryHeight);
        }
        else
        {
            toMove = (currentHeight - secondaryHeight) * 0.85f;
        }
          
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

    public void checkIfDead()
    {
        if (camera.transform.position.y - player.transform.position.y > 5f)
        {
            uiController.GetComponent<UIController>().setUpGameOverText();
            isDead = true;
            Debug.Log("Dead: " + isDead);
            player.GetComponent<PlayerController>().enabled = false;
            player.SetActive(false);
            
        }
        isDead = false;
    }

    public void setUpGameOverText()
    {

    }

    
}

    