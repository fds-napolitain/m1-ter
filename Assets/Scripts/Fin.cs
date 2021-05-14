using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Bravo, vous avez survécu à un piège mortel ! Vous êtes traumatisé à vie et vous ne repartirez jamais en mission, mais vous êtes vivant ! A votre retour de mission, vous avez demandé une mutation aux archives du bureau des naissances, juste pour être sûr.";
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

