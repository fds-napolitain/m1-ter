using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarACB : MonoBehaviour
{
    public Text scenarioText;


    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("Le message “GAME OVER” s’affiche devant vos yeux et vous palissez. Vous avez comme un mauvais pressentiment cette fois-ci.");
        scenario.Add("Un quart de seconde plus tard, des lasers sortant des parois autour de la porte, vous découpent en fines lamelles.");
        scenario.Add("Cette porte était piégée, et vous venez de payer les conséquences de votre échec.");
        scenarioText.text = scenario[0];
        indice++;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (indice != scenario.Count)
            {
                scenarioText.text = scenario[indice];
                indice++;
            }
            else
                SceneManager.LoadScene("Fin16");
            Debug.Log("Clic.");
        }
    }
}