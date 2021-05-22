using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    //public bool isFinished;

    public string introScene;
    public string gameScene;
    public string endingScene;

    private string currentScene;

    public float lastUpdate;

    public static int text_indice = 0;
    public static bool flag = false;

    public AudioSource _audioSource;

    GameObject start_button_v3;

    // Start is called before the first frame update
    void Start()
    {
        if (!flag)
        {
            Debug.Log("Loading GameManager");
            DontDestroyOnLoad(this.gameObject);
            //projectPath = Application.dataPath;
            currentScene = introScene;
            SceneManager.sceneLoaded += OnSceneLoaded;

            /*// scenario load
            scenario = new Assets.Scripts.Tree();
            TreeNode tree = scenario.node;
            tree.Print();*/

            flag = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape")) // sur mobile on quitte tout simplement l'appli
        {
            Application.Quit();
        }
    }



    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        currentScene = scene.name;
    }
}