using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameManager gameManager;
    //public GameObject player;
    public GameObject[] playerArray;

    public GameObject HighScoreObj;
    public TextMeshProUGUI points;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI endPointsText;
    public TextMeshProUGUI coinsGot;
    public TextMeshProUGUI allCoinsText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI pauseText;

    public Button menuButton;
    public Button restartButton;
    public Button quitButton;
    public Button quitButtonIngame;
    public Button pausedMenu;
    public Button pausedExit;

    private int coins;
    private int highscore;

    private bool isDead;
    

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        endPointsText.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        pausedMenu.gameObject.SetActive(false);
        pausedExit.gameObject.SetActive(false);
        highScoreText.SetText("Highscore: Not played yet");
        showHighScore(); 
    }

    void Update()
    {
        calculatePlayerPoints();
        calculateCoinsGot();
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            pauseMenu();
        }

        isDead = playerArray[gameManager.getModelChosen()].GetComponent<PlayerController>().getDeathStatus();
    }

    public void calculatePlayerPoints()
    {
        points.SetText("Points: " + gameManager.calculatePlayerPoints());
    }

    public void calculateCoinsGot()
    {
        coinsGot.SetText("Coins: " + 
            playerArray[gameManager.getModelChosen()].GetComponent<CoinCollector>().getSessionCoins());
        allCoinsText.SetText("All coins: " + 
            playerArray[gameManager.getModelChosen()].GetComponent<CoinCollector>().getAllCoins());
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
    
    private bool isPaused = false;
    public void pauseMenu()
    {
        if(!isPaused && !isDead)
        {
            enablePauseMenu();
            isPaused = true;
        }
        else 
        {
            disablePauseMenu();
            isPaused = false;
        }
    }

    private void enablePauseMenu()
    {
        pausedMenu.gameObject.SetActive(true);
        pausedExit.gameObject.SetActive(true);
        pauseText.gameObject.SetActive(true);
        quitButtonIngame.gameObject .SetActive(false);
        Time.timeScale = 0;
    }

    private void disablePauseMenu()
    {
        pausedMenu.gameObject.SetActive(false);
        pausedExit.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        quitButtonIngame.gameObject.SetActive(true);
        if (!isDead)
        {
            Time.timeScale = 1f;
        }
        
    }
}
