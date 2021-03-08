using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    //public bool isFinished;
    private string projectPath;

    // Start is called before the first frame update
    void Start()
    {
        //isFinished = false;
        DontDestroyOnLoad(this.gameObject);
        projectPath = Application.dataPath;
        SceneManager.LoadScene("Intro");
    }

    // Update is called once per frame
    void Update()
    {
        // Scene change on click (space/touch)
        // https://docs.unity3d.com/ScriptReference/Input.GetKey.html
        if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0) {
            // https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html
            // https://gamedevbeginner.com/how-to-load-a-new-scene-in-unity-with-a-loading-screen/
            // ici on incrémente betement pour tester les jeux, a changer une fois l'arbre fait
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
