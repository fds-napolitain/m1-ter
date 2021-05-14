using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin17 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Savez vous que les Welwitschia Mirabilis peuvent vivre entre 1000 et 2000 ans ? Vous avez devant vous une longue vie de plante qui s’annonce.";
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