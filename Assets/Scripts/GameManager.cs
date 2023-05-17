using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    public GameObject[] player; // need to set this to an array
    public GameObject mogus;

    public GameObject uiController;
    public bool isDead = false;
    private bool movable = false;
    private bool alreadyChecked = false;

    [SerializeField] private int modelChosen = 0;

    //public int allCoins = 0;

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
        Time.timeScale = 1f;
        
        getModelChosen();
        setUpPlayerArray();

        currentHeight = player[getModelChosen()].transform.position.y;
        secondaryHeight = currentHeight;

    }

    

    void Update()
    {
        currentHeight = player[getModelChosen()].transform.position.y;
        cameraY = camera.transform.position.y;

        getMaxHeight();
        checkIfCameraMovable();

        //checkIfDead();
        checkIfDeadAdvanced();
        //Debug.Log("\nCurrent Height: " + currentHeight + "\n" + "Secondary Height: " + secondaryHeight);
        
    }


    private void setUpPlayerArray()
    {

        player[0].SetActive(false);
        player[1].SetActive(false);
        player[2].SetActive(false);

        player[getModelChosen()].SetActive(true);

    }

    static readonly string modelFile = "Model.txt";
    private int getModelChosen()
    { 
        if (File.Exists(modelFile))
        {
            string modelChosenString = File.ReadLines(modelFile).Last();
            modelChosen = Int32.Parse(modelChosenString);  
        }
        return modelChosen;

    }
    public int calculatePlayerPoints()
    {
        
        int points = Convert.ToInt32(maxHeight);
        // Debug.Log("Points: " + points);
        return points;

    }

    //static readonly string rootFolder = @"";
    static readonly string saveFile ="CoinsSave.txt";

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

    public bool wasDead = false;

    public void checkIfDeadAdvanced()
    {
        if (player[modelChosen].GetComponent<PlayerController>().getDeathStatus() && !wasDead) // true if dead
        {
            isDead = true;
            // writeAllCoinsToFile();

            uiController.GetComponent<UIController>().setUpGameOverText();
            
            Debug.Log("Dead: " + isDead);
            Debug.Log("Points were: " + calculatePlayerPoints());

            // player[modelChosen].GetComponent<PlayerController>().enabled = false;
            // player[modelChosen].SetActive(false);

            wasDead = true;
            Time.timeScale = 0f;
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }


}

    