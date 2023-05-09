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
        // player = new GameObject();
        // getCount = GameObject.FindGameObjectsWithTag("tile");
        // Debug.Log("Number of tiles: " + getCount.Length);

        // player = goldPlayer;

        
        getModelChosen();
        setUpPlayerArray();

        currentHeight = player[getModelChosen()].transform.position.y;
        secondaryHeight = currentHeight;
        // readAllCoinsFromFile();
        

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
        /*
        player[0] = redPlayer;
        player[1] = goldPlayer;
        player[2] = greenPlayer;
        */
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
        /*

        switch (modelChosen)
        {
            case 0:
                // Red
                redPlayer.gameObject.SetActive(true);
                player = redPlayer;
                break;
            case 1:
                // Gold
                goldPlayer.gameObject.SetActive(true);
                player = goldPlayer;
                break;
            case 2:
                // Green
                greenPlayer.gameObject.SetActive(true);
                player = greenPlayer;               
                break;
        }
    */
    }
    public int calculatePlayerPoints()
    {
        
        int points = Convert.ToInt32(maxHeight);
        // Debug.Log("Points: " + points);
        return points;

    }

    //static readonly string rootFolder = @"";
    static readonly string saveFile ="CoinsSave.txt";

    /*
    private void readAllCoinsFromFile()
    {
        if (File.Exists(saveFile))
        {
            Debug.Log("File Found!");
            string[] lines = File.ReadAllLines(saveFile);
            foreach(string line in lines)
            {
                if(line.Equals(lines))
                {
                    allCoins = Int32.Parse(line);
                    Debug.Log(allCoins);
                }
                
            }
        }
    }
    */

    /*
    public void writeAllCoinsToFile()
    {
        string path = "CoinsSave.txt";
        string allCoinsString;

        calculateAllCoins();

        allCoinsString = allCoins.ToString();

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(allCoinsString, true);
        writer.Close();
    }
    */

    /*
    public void calculateAllCoins()
    {
        allCoins = player[modelChosen].GetComponent<PlayerController>().allCoinsGotGiver();
    }
    */

    public void allCoinsGotCalculator()
    {
         
    }
    /*
    public int giveAllCoinsToPlayerController()
    {
        calculateAllCoins();
        return allCoins;
    }
    */
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

    // Got a better solution than this
    /* 
    public void checkIfDead()
    {
        if (!isDead && !wasDead) { 
            if (camera.transform.position.y - player.transform.position.y > 5f)
            {
                writeAllCoinsToFile();
            
                uiController.GetComponent<UIController>().setUpGameOverText();
                isDead = true;
                Debug.Log("Dead: " + isDead);
                player.GetComponent<PlayerController>().enabled = false;
                player.SetActive(false);

                wasDead = true;
            }
            

        }
    }
    */

    public bool wasDead = false;

    public void checkIfDeadAdvanced()
    {
        if (player[modelChosen].GetComponent<PlayerController>().getDeathStatus() && !wasDead) // true if dead
        {
            isDead = true;
            // writeAllCoinsToFile();

            uiController.GetComponent<UIController>().setUpGameOverText();
            
            Debug.Log("Dead: " + isDead);

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

    