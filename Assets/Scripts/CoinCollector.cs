using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private int allCoinsGot;
    [SerializeField] private int coinsCollected = 0;

    public GameManager gameManager;

    //public GameObject player;
    public GameObject[] playerArray;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        readAllCoinsFromFile();

    }
        
    // Update is called once per frame
    void Update()
    {
        if (playerArray[gameManager.getModelChosen()].GetComponent<PlayerController>().getDeathStatus() 
            && !isDead)
        {
            writeAllCoinsToFile();
            isDead = true;
        }
    }

    static readonly string saveFile = "CoinsSave.txt";
    private void readAllCoinsFromFile()
    {
        if (File.Exists(saveFile))
        {
            Debug.Log("File Found!");
            string amount = File.ReadLines(saveFile).Last();
            allCoinsGot = Int32.Parse(amount);
            Debug.Log("Player Controller allCoinsGot = " + allCoinsGot);
        }
    }
    public void writeAllCoinsToFile()
    {
        string path = "CoinsSave.txt";
        string allCoinsString;

        allCoinsString = allCoinsGot.ToString();

        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(allCoinsString, true);
        writer.Close();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log("Coin aquired");
            other.gameObject.SetActive(false);
            coinsCollected++;
            allCoinsGot++;
        }
    }

    public int getAllCoins()
    {
        return allCoinsGot;
    }

    public int getSessionCoins()
    {
        return coinsCollected;
    }
}
