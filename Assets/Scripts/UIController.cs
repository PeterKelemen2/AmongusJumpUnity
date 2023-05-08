using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI points;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI endPointsText;

    public Button menuButton;
    public Button restartButton;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        endPointsText.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    void Update()
    {
        calculatePlayerPoints();
        if (gameManager.isDead)
        {

        }
    }

    public void calculatePlayerPoints()
    {
        points.SetText("Points: " + gameManager.calculatePlayerPoints());
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
