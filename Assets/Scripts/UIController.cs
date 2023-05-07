using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI points;

    void Start()
    {
        
    }

    void Update()
    {
        calculatePlayerPoints();
    }

    public void calculatePlayerPoints()
    {
        points.SetText("Points: " + gameManager.calculatePlayerPoints());
    }
}
