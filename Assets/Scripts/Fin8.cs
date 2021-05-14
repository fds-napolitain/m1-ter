using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin8 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Vous mourrez empli de haine et de ressentiment. Si Sekip survit, vous reviendrez probablement le hanter jusqu’à la fin de ses jours.";
        finText.text = fin;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            SceneManager.LoadScene("Intro");
        }
    }
}