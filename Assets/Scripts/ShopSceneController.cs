using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopSceneController : MonoBehaviour
{
    public Button redButton;
    public Button goldButton;
    public Button greenButton;

    public GameObject redModel;
    public GameObject goldModel;
    public GameObject greenModel;

    public GameObject redLight;
    public GameObject goldLight;
    public GameObject greenLight;

    Animator animator;

    public TextMeshProUGUI chosenText;

    public int modelChosen = 0;

    public string menuScene;

    void Start()
    {
        chosenText.enabled = false;
        lightsOff();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lightsOff()
    {
        redLight.SetActive(false);
        goldLight.SetActive(false);
        greenLight.SetActive(false);
    }

    public void redClicked()
    {
        lightsOff();
        //animator.Play("Red");

        modelChosen = 0;
        writeModelChosenToFile();
        Debug.Log("Red chosen");

        chosenText.enabled = true;
        chosenText.SetText("Red Skin chosen");
        redLight.SetActive(true);
    }

    public void goldClicked()
    {
        lightsOff();
        modelChosen = 1;
        writeModelChosenToFile();
        Debug.Log("Gold chosen");

        chosenText.enabled = true;
        chosenText.SetText("Gold Skin chosen");
        goldLight.SetActive(true);
    }

    public void greenClicked()
    {
        lightsOff();
        modelChosen = 2;
        writeModelChosenToFile();
        Debug.Log("Green chosen");

        chosenText.enabled = true;
        chosenText.SetText("Green Skin chosen");
        greenLight.SetActive(true);
    }

    public int getModelChosen()
    {
        return modelChosen;
    }

    public void writeModelChosenToFile()
    {   
        
        string path = "Model.txt";
        string modelNumberString;
        if (!File.Exists(path))
        {
            File.Create(path);
        }

        File.WriteAllText(path, String.Empty);

        modelNumberString = modelChosen.ToString();

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(modelNumberString, true);
        writer.Close();
    }

    public void loadMenuScene()
    {
        SceneManager.LoadScene(menuScene);
    }

}
