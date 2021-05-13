using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarBB : MonoBehaviour
{
    public Text scenarioText;


    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("Vous avez encore échoué… Alors que vos coéquipiers vous enguirlandent et que Loulou se moque de vous, une secousse sous vos pieds vous déséquilibre. Alors, vous avez un mauvais pressentiment.");
        scenario.Add("Vous vous précipitez vers le côté gauche de la pièce pour tenter de rejoindre le sas de pression pour sortir, mais ce que vous craignez se produit avant que vous puissiez l’atteindre.");
        scenario.Add("Devant vos yeux ébahis, la grande porte extérieure du hangar s'ouvre. L’instant d’après vous vous sentez aspiré vers l’extérieur.");
        scenario.Add("Vous observez bientôt l’espace autour de vous, et vous savez que c’est la fin. Votre première mission vous aura été fatale, et c’est entièrement votre faute.");
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
                SceneManager.LoadScene("Fin18");
            Debug.Log("Clic.");
        }
    }
}