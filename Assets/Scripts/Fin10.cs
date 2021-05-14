using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin10 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Vous êtes tombé dans un liquide de conversion génétique et avez été transformé en alien. Vous vivez désormais une vie d’alien (après avoir dévoré vos camarades) et vous avez un succès fou auprès du sexe opposé.";
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