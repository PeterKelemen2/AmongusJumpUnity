using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class InfoGetter : MonoBehaviour
{
    public int shownCoins;
    public TextMeshProUGUI allCoinsText;

    void Start()
    {
        readAllCoinsFromFile();
        allCoinsText.SetText(shownCoins + " Coins");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static readonly string saveFile = @"Assets\CoinsSave.txt";
    private void readAllCoinsFromFile()
    {
        if (File.Exists(saveFile))
        {
            //Debug.Log("File Found!");
            string amount = File.ReadLines(saveFile).Last();
            shownCoins = Int32.Parse(amount);
            //Debug.Log(shownCoins + " Coins");
        }
    }
}
