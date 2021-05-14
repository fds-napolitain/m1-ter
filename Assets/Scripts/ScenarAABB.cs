using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarAABB : MonoBehaviour
{
    public Text scenarioText;


    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("“Mais je t’avais dis que c’était l’autre réponse ! Bon sang mais pourquoi tu ne m’as pas écouté ?”");
        scenario.Add("Sekip est en train de vous enguirlander. Encore une fois, vous avez lamentablement échoué. Vous commencez à vous sentir coupable un peu malgré vous.");
        scenario.Add("Le ton monte alors que Sekip continue à critiquer votre erreur. Cette fois toutefois, vous ne voyez pas le message “porte bloquée” s’afficher sur le boîtier. Au moins vous pouvez réessayer de l’ouvrir.");
        scenario.Add("Vous faites remarquer cette information au capitaine, et Sekip s’exclame alors :");
        scenario.Add("“Pousse toi ! C’est à moi d’essayer cette fois !”");
        scenario.Add("Le pilote s’apprête à recommencer le jeu quand la porte s’ouvre sur un alien gigantesque, vert avec des yeux de mouche, des antennes et quatre bras recouverts de gouttelettes de sang.");
        scenario.Add("Il vous observe tour à tour l’un après l’autre, puis avec trois de ces bras, il vous embroche et vous traîne dans la pièce derrière lui. Quelques minutes plus tard, vous finissez en sushis que l’équipage se fait une joie de déguster.");
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
                SceneManager.LoadScene("Fin9");
            Debug.Log("Clic.");
        }
    }
}

