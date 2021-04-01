using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    //public bool isFinished;

    public string introScene;
    public string gameScene;
    public string corridorScene;
    public string hangarScene;
    public string endingScene;

    public string memoryScene;
    public string simonScene;
    public string hanoiScene;
    public string quizScene;

    private string currentScene;

    public float lastUpdate;

    //private string projectPath;

    // Start is called before the first frame update
    void Start()
    {

        //isFinished = false;
        DontDestroyOnLoad(this.gameObject);
        //projectPath = Application.dataPath;
        currentScene = introScene;
        SceneManager.sceneLoaded += OnSceneLoaded;

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

        //Entrée
        else if (currentScene == gameScene)
        {

            if (Input.GetKey(KeyCode.Return) || Input.touchCount > 0)
            {

                LoadMemory();
            }
        }

        else if (currentScene == corridorScene)
        {

            if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
            {

                LoadSimon();
            }
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

    //Classic scenes loaders

    public void LoadIntro()
    {

        LoadScene(introScene);
    }

    public void LoadGame()
    {

        LoadScene(gameScene);
    }

    public void LoadCorridor()
    {

        LoadScene(corridorScene);
    }

    public void LoadHangar()
    {

        LoadScene(hangarScene);
    }

    public void LoadEnding()
    {

        LoadScene(endingScene);
    }

    //Mini games scenes loaders

    public void LoadMemory()
    {

        LoadScene(memoryScene);
    }

    public void LoadSimon()
    {

        LoadScene(simonScene);
    }

    public void LoadHanoi()
    {

        LoadScene(hanoiScene);
    }

    public void LoadQuiz()
    {

        LoadScene(quizScene);
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