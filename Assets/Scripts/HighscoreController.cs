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
    public GameObject player;
    private bool isDead;

    void Start()
    {
        readFromFile();
        
    }

    void Update()
    {
        if (player.GetComponent<PlayerController>().getDeathStatus())
        {
            if(gameManager.calculatePlayerPoints() > highScore)
            {
                writeToFile(gameManager.calculatePlayerPoints());
            }

        }
    }

    private void readFromFile()
    {
        if (File.Exists(highScoreFile))
        {
            Debug.Log("Highscore File Found!");
            
            string amount = File.ReadLines(highScoreFile).Last();
            Debug.Log(amount);
            highScore = Int32.Parse(amount);
        }
        else
        {
            File.Create(highScoreFile);
            highScore = 0;
        }
    }
    public void writeToFile(int amountToWrite)
    {
        string path = "CoinsSave.txt";
        string highScoreString;

        highScoreString = amountToWrite.ToString();

        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(path, true);
        writer.Close();
    }

    
}
