using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    public int NbAliens
    {
        get { return _nbAlien; }
        set { _nbAlien = value; if (_nbAlien <= 0) { EndGame(); } }
    }

    public bool isFinished;
    public string introScene;
    public string gameScene;
    public string gameOverScene;

    public float lastUpdate;

    private float lastGameTime;
    private int _nbAlien;
    private Text textTime;
    private string currentScene;

    // Use this for initialization
    void Start()
    {
        isFinished = false;
        DontDestroyOnLoad(this.gameObject);
        NbAliens = 55;
        currentScene = introScene;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene == introScene)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                LoadGame();
            }
        }
        else if (currentScene == gameScene)
        {
            if (!isFinished)
            {
                if (GetCurrentTime() > lastUpdate + 0.2)
                {
                    textTime.text = "" + GetCurrentTime();
                    lastUpdate = GetCurrentTime();
                }
            }
        }
        else if (currentScene == gameOverScene)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                LoadGame();
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }

    }

    private float GetCurrentTime()
    {
        return Time.time - lastGameTime;
    }

    public void EndGame()
    {
        lastGameTime = GetCurrentTime();
        LoadGameOver();
    }

    public void LoadIntro()
    {
        LoadScene(introScene);
    }

    public void LoadGame()
    {
        Restart();
        LoadScene(gameScene);
    }

    public void LoadGameOver()
    {
        LoadScene(gameOverScene);
    }

    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Restart()
    {
        NbAliens = 55;
        isFinished = false;
        lastUpdate = 0;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.name;
        if (currentScene == gameScene)
        {
            lastGameTime = Time.time;
            textTime = GameObject.Find("Time").GetComponent<Text>();
        }
    }
}
