using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarAAB : MonoBehaviour
{
    public Text scenarioText;


    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("Vous jetez un coup d’oeil sur le côté pour vérifier que le capitaine ne vous a pas vu échoué avant d’affirmer sans vergogne :");
        scenario.Add("“La porte est bloquée ! Résoudre le jeu ne marche pas ! Nous devons trouver une autre entrée.”");
        scenario.Add("Vous prenez alors à droite, seul chemin possible, dans l’espoir de contourner la pièce et qui peut-être trouver une autre porte.");
        scenario.Add("Vous avancez donc en longeant le mur et tombez sur Sekip qui vient dans l’autre sens.");
        scenario.Add("“Capitaine ! Le bleu ! Vous allez bien ? Vous avez trouvé Loulou ? Vous avez vu Innoth ? Je l’ai entendu hurler !”");
        scenario.Add("Vous échangez un regard avec le capitaine, il se décide à lui répondre en allant à l'essentiel.");
        scenario.Add("“Loulou est toujours perdu et nous savons où est Innoth, mais la porte d’accès est bloquée. Nous cherchons donc un autre accès dans cette direction.”");
        scenario.Add("“Dans ce cas, je suis passé à côté d’une porte il y a environ deux mètres.”");
        scenario.Add("“Nous n’avons rien à perdre à essayer.”");
        scenario.Add("Vous le suivez donc jusqu’à la fameuse porte. Cette fois-ci, c’est un... on dirait un snake ou quelque chose dans le genre pour l’ouvrir. Décidément les goûts des passagers du vaisseau sont étonnants. ");
        scenario.Add("Vous vous écartez dans l’espoir de laisser la place à quelqu’un d’autre cette fois-ci, mais les deux autres membres d’équipage vous fixent attendant que vous vous en occupiez.");
        scenario.Add("Vous réalisez alors qu’on vous laisse vous en chargé au cas où il s’agirait d’un piège. Mais vous n’avez pas le choix alors vous faîtes ce qu’on vous demande.");
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
                SceneManager.LoadScene("Collect2");
            Debug.Log("Clic.");
        }
    }
}

