using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin16 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Cette mission est un échec sur toute la ligne, mais au moins vous avez bénéficié d’une mort rapide...";
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