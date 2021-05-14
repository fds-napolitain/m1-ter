using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin2 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Quand le destin vous en veut, vous ne pouvez rien faire pour y échapper. Ce n’était décidément pas votre jour. La mort vous attendait.";
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

