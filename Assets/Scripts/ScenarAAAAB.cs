using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarAAAA : MonoBehaviour
{
    public Text scenarioText;


    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("La chance semble vous avoir quitté, ou le talent, toujours est-il que vous faites griller la commande interne. Vous n’avez donc plus aucun moyen d’ouvrir cette porte. L’avantage c’est que votre ennemi ne peut pas l’ouvrir nous plus. Tout du moins, c’est ce que vous croyez.");
        scenario.Add("Environ 12h plus tard, votre ennemi force l’ouverture de la porte avec l’aide d’un de ses “camarades”.");
        scenario.Add("Terrifié, vous reculez et tentez de lui échapper par tous les moyens, mais il vous assomme avant de vous traîner à travers le vaisseau. Vous êtes conscient, mais pour une raison qui vous échappe, vous ne pouvez plus bouger.");
        scenario.Add("Il vous installe alors sur une table, attrape un gigantesque couteau, et l’instant d’après votre tête roule loin de votre corps.");
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
                SceneManager.LoadScene("Fin3");
            Debug.Log("Clic.");
        }
    }
}

