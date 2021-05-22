using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin14 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Je crois que vous avez regardez trop de films d’action… Vous pensiez sérieusement pouvoir devenir Rambo ?";
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