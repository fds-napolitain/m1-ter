using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin6 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Avec ce que vous venez de faire, vous avez bousillé votre karma. Vous serez sûrement réincarné en limace de mer dans une prochaine vie.";
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