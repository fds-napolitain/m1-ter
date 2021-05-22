using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin12 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "La drogue, c’est dangereux...";
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