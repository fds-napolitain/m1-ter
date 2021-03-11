using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    //public bool isFinished;

    public string intro;
    public string game;
    public string corridor;
    public string hangar;
    public string ending;

    public string memory;
    public string simon;

    private string currentScene;

    public float lastUpdate;

    //private string projectPath;

    // Start is called before the first frame update
    void Start()
    {

        //isFinished = false;
        DontDestroyOnLoad(this.gameObject);
        //projectPath = Application.dataPath;
        currentScene = intro;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    // Update is called once per frame
    void Update()
    {

        if (currentScene == intro)
        {

            if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
            {

                LoadGame();
            }
        }

        else if (currentScene == game)
        {

            if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
            {

                LoadEnding();
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

    public void LoadCorridor()
    {

        LoadScene(corridor);
    }

    public void LoadHangar()
    {

        LoadScene(hangar);
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