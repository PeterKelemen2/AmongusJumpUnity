using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject player;
    public TextMeshProUGUI points;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI endPointsText;
    public TextMeshProUGUI coinsGot;
    public TextMeshProUGUI allCoinsText;

    public Button menuButton;
    public Button restartButton;

    private int coins;
    

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        endPointsText.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

       
        //coins = gameObject.GetComponent<PlayerController>().allCoinsGotGiver();
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
        // uiController.GetComponent<UIController>().setUpGameOverText()
        coins = player.GetComponent<PlayerController>().getCoinsCollected();

        coinsGot.SetText("Coins: " + player.GetComponent<PlayerController>().getCoinsCollected());
        allCoinsText.SetText("All coins: " + player.GetComponent<PlayerController>().allCoinsGotGiver());
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
    }
}
