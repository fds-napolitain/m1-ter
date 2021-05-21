using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin4 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Abandonner votre ami était un choix lâche qui vient de se retourner contre vous. Vous devriez peut-être en tirer une leçon.";
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