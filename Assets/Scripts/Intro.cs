using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public string gameScene;

    /// <summary>
    /// Normalement OnMouseDown détecte également Touch
    /// </summary>
    private void OnMouseDown()
    {
        if (name == "start_button_v3")
        {
            SceneManager.LoadScene(gameScene);
        }
    }
}
