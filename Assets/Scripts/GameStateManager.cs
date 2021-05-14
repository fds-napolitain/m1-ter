using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class GameStateManager : MonoBehaviour
{

    //public bool isFinished;

    public string introScene;
    public string gameScene;
    public string endingScene;

    /*public string corridorScene;
    public string hangarScene;
    public string memoryScene;
    public string simonScene;
    public string hanoiScene;
    public string snakeScene;
    public string quizScene;*/

    private string currentScene;

    public float lastUpdate;
    public Assets.Scripts.Tree scenario;

    public static int text_indice = 0;
    public static bool flag = false;

    GameObject start_button_v3;
    GameObject start_button_v4;

    // Start is called before the first frame update
    void Start()
    {
        if (!flag)
        {
            Debug.Log("Loading GameManager");
            //isFinished = false;
            //DontDestroyOnLoad(this.gameObject);
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

        //Espace
        if (currentScene == introScene)
        {

            if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
            {

                LoadGame();
            }
        }

        if (currentScene == endingScene)
        {
            if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
            {

                LoadIntro();
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        /*if (currentScene == game) {

            if (Input.GetKey(KeyCode.Space)) {

                LoadMemory();
            }
        }*/

        //Modification 08/03

        /*
            // Scene change on click (space/touch)
        // https://docs.unity3d.com/ScriptReference/Input.GetKey.html
        if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
        {
            // https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html
            // https://gamedevbeginner.com/how-to-load-a-new-scene-in-unity-with-a-loading-screen/
            // ici on incrémente betement pour tester les jeux, a changer une fois l'arbre fait
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/

    }

    private void OnMouseDown()
    {

        if(name == "start_button_v3" || name == "start_button_v4")
        {
            LoadGame();
            Destroy(this.gameObject);
        }
    }

    //Classic scenes loaders

    public void LoadIntro()
    {

        LoadScene(introScene);
    }

    public void LoadGame()
    {

        LoadScene(gameScene);
    }

    public void LoadEnding()
    {

        LoadScene(endingScene);
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
}