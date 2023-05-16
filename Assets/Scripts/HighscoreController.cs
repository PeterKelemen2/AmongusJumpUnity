using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Rendering;

public class Highscore
{
    string name;
    int value;

    public void sort()
    {

    }
}



public class HighscoreController : MonoBehaviour
{
    
    private string highScoreFile = "Highscore.txt";

    void Start()
    {
        List<Highscore> hsList = new List<Highscore>();
        Highscore hs = new Highscore();
        
        // readTest();
        
    }

    void Update()
    {
        
    }

    private void readFromFile()
    {
        if (File.Exists(highScoreFile))
        {
            Debug.Log("File Found!");
            string amount = File.ReadLines(highScoreFile).Last();
            //highScore = Int32.Parse(amount);
            Debug.Log("Player Controller allCoinsGot = " + highScoreFile);
        }
        else
        {
            File.Create(highScoreFile);
        }
    }
    public void writeToFile(int amountToWrite)
    {
        string path = "CoinsSave.txt";
        string allCoinsString;

        //allCoinsString = allCoinsGot.ToString();

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(path, true);
        writer.Close();
    }

    public void setUpHighScoreArray()
    {

    }
}
