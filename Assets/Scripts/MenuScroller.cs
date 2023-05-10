using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScroller : MonoBehaviour
{
    [SerializeField] private RawImage background;
    [SerializeField] private float xSpeed, ySpeed;

    private void Start()
    {
        
    }

    void Update()
    {
        scrolling();
    }

    public void scrolling()
    {
        background.uvRect = new Rect(background.uvRect.position +
            new Vector2(xSpeed, ySpeed) *
            Time.deltaTime,
            background.uvRect.size);
    }

}
