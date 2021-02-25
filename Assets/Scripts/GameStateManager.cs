using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    public bool isFinished;

    public string Intro;
    public string SampleScene;
    public string Ending;

    public string Memory;
    public string Simon;

    private string currentScene;

    public float lastUpdate;

    // Start is called before the first frame update
    void Start()
    {

        isFinished = false;
        DontDestroyOnLoad(this.gameObject);
        currentScene = Intro;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    // Update is called once per frame
    void Update()
    {

        if (currentScene == Intro) {

            if (Input.GetKey(KeyCode.Space)) {

                LoadGame();
            }
        }

        if (currentScene == SampleScene) {

            if (Input.GetKey(KeyCode.Space)) {

                LoadMemory();
            }
        }

    }

    //To load a scene:

    private void LoadScene(string scene)
    {

        SceneManager.LoadScene(scene);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        currentScene = scene.name;
    }

    //Classic scenes loaders

    public void LoadIntro()
    {

        LoadScene(Intro);
    }

    public void LoadGame()
    {

        LoadScene(SampleScene);
    }

    public void LoadEnding()
    {

        LoadScene(Ending);
    }

    //Mini games scenes loaders

    public void LoadMemory()
    {

        LoadScene(Memory);
    }   
}
