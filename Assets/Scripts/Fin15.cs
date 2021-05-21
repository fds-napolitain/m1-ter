using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin15 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Vous avez fait BOUM. C’était une salle d’armes, vous auriez pu vous douter que ce serait dangereux de laisser un singe et un pilote, un peu crétin par moment, entrer dans la pièce.";
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