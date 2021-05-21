﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin18 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Savez-vous que d'après la NASA, la durée de vie moyenne d’un astronaute dans l’espace, sans combinaison, est d’environ 90s ?";
        finText.text = fin;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
