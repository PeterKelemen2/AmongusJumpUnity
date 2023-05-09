using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
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

    public int modelChosen = 0;

    public string menuScene;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void redClicked()
    {
        modelChosen = 0;
        writeModelChosenToFile();
        Debug.Log("Red chosen");
    }

    public void goldClicked()
    {
        modelChosen = 1;
        writeModelChosenToFile();
        Debug.Log("Gold chosen");
    }

    public void greenClicked()
    {
        modelChosen = 2;
        writeModelChosenToFile();
        Debug.Log("Green chosen");
    }

    public int getModelChosen()
    {
        return modelChosen;
    }

    public void writeModelChosenToFile()
    {
        string path = "Model.txt";
        string modelNumberString;

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
