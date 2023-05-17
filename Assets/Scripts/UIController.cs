using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject player;
    public GameObject HighScoreObj;
    public TextMeshProUGUI points;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI endPointsText;
    public TextMeshProUGUI coinsGot;
    public TextMeshProUGUI allCoinsText;
    public TextMeshProUGUI highScoreText;

    public Button menuButton;
    public Button restartButton;
    public Button quitButton;
    public Button quitButtonIngame;

    private int coins;
    private int highscore;
    

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        endPointsText.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        highScoreText.SetText("Highscore: Not played yet");
        showHighScore(); 
    }

    void Update()
    {
        calculatePlayerPoints();
        calculateCoinsGot();
    }

    public void calculatePlayerPoints()
    {
        points.SetText("Points: " + gameManager.calculatePlayerPoints());
    }

    public void calculateCoinsGot()
    {
        coinsGot.SetText("Coins: " + player.GetComponent<CoinCollector>().getSessionCoins());
        allCoinsText.SetText("All coins: " + player.GetComponent<CoinCollector>().getAllCoins());
    }

    public void setUpGameOverText()
    {
        gameOverText.gameObject.SetActive(true);
        endPointsText.gameObject.SetActive(true);
        points.gameObject.SetActive(false);

        gameOverText.SetText("Game Over!");
        endPointsText.SetText("Your points: " + gameManager.calculatePlayerPoints());

        menuButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);

        quitButtonIngame.gameObject.SetActive(false);
    }

    public void showHighScore()
    {
        highscore = HighScoreObj.GetComponent<HighscoreController>().readFromFile();

        if(highscore > 0)
        {
            highScoreText.SetText("Highscore: " + highscore);
        }
        else
        {
            highScoreText.SetText("Highscore: " + 
                HighScoreObj.GetComponent<HighscoreController>().notPlayedMessage());
        }   
    }
}
