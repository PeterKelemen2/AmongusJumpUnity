using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


public class HighscoreController : MonoBehaviour
{
    private string highScoreFile = "Highscore.txt";
    public int highScore;
    public int score;
    public GameManager gameManager;
    //public GameObject player;
    public GameObject[] playerArray;
    private bool isDead = false;

    void Start()
    {
        readFromFile();  
    }

    void Update()
    {
        score = gameManager.calculatePlayerPoints();
        checkIfDead();
    }

    public int readFromFile()
    {
        if (File.Exists(highScoreFile))
        {
            Debug.Log("Highscore File Found!");
            
            string amount = File.ReadLines(highScoreFile).Last();
            Debug.Log("Highscore read from file: " + amount);
            highScore = Int32.Parse(amount);
        }
        else
        {
            File.Create(highScoreFile);
            
            highScore = 0;
        }
        return highScore;
    }

    public string notPlayedMessage()
    {
        string notPlayedSring = "Not played yet";

        return notPlayedSring;
    }

    public void writeToFile(int intToWrite)
    {
        string path = "HighScore.txt";
        string highScoreString;

        highScoreString = intToWrite.ToString();
        Debug.Log("highScoreString: " + highScoreString);

        StreamWriter writer = new StreamWriter(path);
        writer.WriteLine(highScoreString);
        writer.Close();
    }

    private void checkIfDead()
    {
        if (playerArray[gameManager.getModelChosen()].GetComponent<PlayerController>().getDeathStatus() 
            && !isDead)
        {
            isDead = true;
            if (score > highScore)
            {
                writeToFile(score);
                Debug.Log("Score to write: " + score);
            }
        }
    }
}
