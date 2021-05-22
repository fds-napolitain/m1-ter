using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin7 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Mon ami, c’est ce qu’on appelle le karma ! Souviens-toi : “Ne fais pas aux autres ce que tu n’aimerais pas qu’on nous fasse !”";
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