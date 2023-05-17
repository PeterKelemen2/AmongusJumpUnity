using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class HoverController : MonoBehaviour
{
    // public GameObject redModel;
    // public GameObject goldModel;
    // public GameObject greenModel;
    public GameObject redLight;
    public GameObject goldLight;
    public GameObject greenLight;
    public Button red;
    public Button gold;
    public Button green;

    public UnityEvent OnHover = new UnityEvent();

    private float timeCount = 0;
    private float executeTime = 1.5f;
    private bool startTimeCount = false;

    void Start()
    {
        //OnHover.AddListener();
        
    }

    public void OnMouseEnter()
    {
        redHover();
    }

    public void OnMouseExit() {
        lightsOff();
    }

    void Update()
    {
        
    }

    public void lightsOff()
    {
        redLight.SetActive(false);
        goldLight.SetActive(false);
        greenLight.SetActive(false);
    }

    public void redHover()
    {
        redLight.SetActive(true);
    }

    public void goldHover()
    {
        goldLight.SetActive(true);
    }

    public void greenHover()
    {
        greenLight.SetActive(true);
    }


}
