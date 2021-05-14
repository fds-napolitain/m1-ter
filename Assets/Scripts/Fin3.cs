using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin3 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Une seule petite erreur peut vous coûter la vie… Souvenez-vous en.";
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