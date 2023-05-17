using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage background;
    [SerializeField] private float xSpeed, ySpeed;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + 
            new Vector2(xSpeed,ySpeed) * 
            Time.deltaTime, 
            background.uvRect.size);
    }
}
