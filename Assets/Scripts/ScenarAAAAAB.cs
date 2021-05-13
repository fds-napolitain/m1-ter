using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarAAAAAB : MonoBehaviour
{
    public Text scenarioText;


    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("Une seule mauvaise réponse et le piège vient de se refermer sur vous. Des pas se font entendre dans le couloir et vous savez que vous êtes perdu. Vous décidez alors que vous préférez choisir votre mort.");
        scenario.Add("Vous frappez sur une des barres du mur jusqu’à ce qu’elle se casse, en espérant en faire une arme pour vous défendre. ");
        scenario.Add("Mais la chance n’est pas avec vous aujourd’hui, et ce que vous aviez pris pour une barre en métal était en fait une conduite de gaz hautement inflammable. Quand elle se casse, une étincelle se produit et vous êtes pulvérisé par l’explosion.");
        scenarioText.text = scenario[0];
        indice++;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            if (indice != scenario.Count)
            {
                scenarioText.text = scenario[indice];
                indice++;
            }
            else
                SceneManager.LoadScene("Fin2");
            Debug.Log("Clic.");
        }
    }
}

