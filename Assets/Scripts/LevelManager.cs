using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string sceneToLoad;
    public string sceneToUnload;

    public string playScene;
    public string menuScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
        SceneManager.UnloadSceneAsync(sceneToUnload);
    }

    public void loadPlayScene()
    {
        SceneManager.UnloadSceneAsync(playScene);
        SceneManager.LoadScene(playScene);
        
    }

    public void loadMenuScene()
    {
        SceneManager.LoadScene(menuScene);
        SceneManager.UnloadSceneAsync(playScene);
    }
}
