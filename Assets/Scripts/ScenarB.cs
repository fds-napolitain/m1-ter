using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarB : MonoBehaviour
{
    public Text scenarioText;


    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("“Tu as vraiment perdu le bleu ! Ah bah bravo ! Et maintenant, que fait-on, Capitaine ?”");
        scenario.Add("Comme vous pouvez le voir, Sekip est un grand fan de vous.");
        scenario.Add("“Bon essayons de passer par le hangar. En étudiant le vaisseau rapidement tout à l’heure pendant que je tentais une communication, j’ai remarqué que le hangar était assez facile d’accès.”");
        scenario.Add("Innoth est véritablement la “tête” du groupe, et encore une fois ça se sentait.");
        scenario.Add("“Vu que Spat a échoué, nous n’avons pas vraiment le choix. Va pour le hangar.”");
        scenario.Add("C’est ainsi que vous décidez de passer par le hangar pour rentrer dans vaisseau.");
        scenario.Add("Vous enfilez vos combinaisons pour sortir et rejoignez la porte extérieure du vaisseau inconnu.");
        scenario.Add("Vous appuyez sur un petit bouton noir et une porte donnant sur un sas, s’ouvre. Vous y pénétrez tous en vous serrant un peu et la porte se referme derrière vous pour pressuriser le sas. Une fois la pression régulée, vous enlevez vos casques et sortez.");
        scenario.Add("Devant vous se trouve un gigantesque hangar avec de vieux mini-vaisseaux de combat et tout un tas de bric-à-brac.");
        scenario.Add("Vous l’explorez avec curiosité quand Loulou se met à crier en sautillant sur place.");
        scenario.Add("Tout l’équipage se tourne vers lui et vous réalisez qu’il vous indique l’emplacement d’une porte.");
        scenario.Add("“Bon, voici une nouvelle chance d’entrer ! Cette fois-ci, ne te foire pas, le bleu !”");       
        scenario.Add("Face à vous, sur le boîtier tactile, un plateau avec des obstacles ressemblant à un snake… Voici le seul moyen de déverrouiller la porte.");
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
                SceneManager.LoadScene("Collect4");
            Debug.Log("Clic.");
        }
    }
}