﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    //public bool isFinished;

    public string intro;
    public string game;
    public string ending;

    public string memory;
    public string simon;

    private string currentScene;

    public float lastUpdate;

    // Start is called before the first frame update
    void Start()
    {

        //isFinished = false;
        DontDestroyOnLoad(this.gameObject);
        currentScene = intro;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    // Update is called once per frame
    void Update()
    {

        if (currentScene == intro) {

            if (Input.GetKey(KeyCode.Space)) {

                LoadMemory();
                //LoadGame();
            }
        }

        /*if (currentScene == game) {

            if (Input.GetKey(KeyCode.Space)) {

                LoadMemory();
            }
        }*/

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

        LoadScene(intro);
    }

    public void LoadGame()
    {

        LoadScene(game);
    }

    public void LoadEnding()
    {

        LoadScene(ending);
    }

    //Mini games scenes loaders

    public void LoadMemory()
    {

        LoadScene(memory);
    }

    public void LoadSimon()
    {

        LoadScene(simon);
    }
}
