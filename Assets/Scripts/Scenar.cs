using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Scenar : MonoBehaviour
{
    public Text scenarioText;


    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("Galaxie d’Andromède, 2742, USS Unknown");
        scenario.Add("Une simple mission de routine. Une rapide reconnaissance. C’est, en tout cas, ce qui avait été promis à l’équipage du bâtiment.");
        scenario.Add("Un capitaine à peine nommé, Chiver, et le ouistiti de compagnie offert par la Ligue Galactique, Loulou.");
        scenario.Add("Loulou ne quitte presque jamais le capitaine. Et quand il n’est pas sur son épaule, il est sur le pont, scrutant la carte du système à la recherche de la moindre anomalie.");
        scenario.Add("De temps en temps, Sekip, le pilote, tente quelques blagues, très souvent incomprises.");
        scenario.Add("Et vous, Spat, vous êtes au milieu de tout ça, le petit nouveau tout juste sorti de l'académie, qui effectue sa première mission spatiale.");
        scenario.Add("Le capitaine se dirige vers le centre de commandement, au centre du vaisseau. Autour de la station de commande se trouve le second du capitaine, une belle jeune femme nommée Innoth.");
        scenario.Add("“Du nouveau ?”");
        scenario.Add("“Toujours rien, capitaine. Je ne comprends toujours pas, que fait-on ici ?”");
        scenario.Add("“Je suppose que c’est à nous de le découvrir. Après tout, nous sommes une équipe de reconnaissance.”");
        scenario.Add("“Reconnaissance, reconnaissance… Je pense surtout qu’ils nous ont envoyé sur une mission absurde ! Il n’y a rien ici !”");
        scenario.Add("Un long soupir s’échappe de la bouche du capitaine. Bien-sûr qu’Innoth se montre impatiente. Et ce serait mentir que de dire que le capitaine n’était pas lui aussi frustré de ne rien trouver.");
        scenario.Add("Soudain, Loulou crève le silence pesant, en commençant à gesticuler violemment en criant tel un enfant sur les épaules du capitaine.");
        scenario.Add("“Du calme, Loulou ! Qu’est-ce-qu’il te prend ?”");
        scenario.Add("Le petit singe pointe, frénétiquement, le radar de la table de commande. Les yeux du capitaine s'ouvrent en grand à la vue d’un gros point lumineux se déplaçant rapidement sur l'écran.");
        scenario.Add("“Mais, c’est un vaisseau de signature inconnue !”");
        scenario.Add("Innoth sursaute de joie en entendant les mots du capitaine.");
        scenario.Add("“Enfin ! Que comptez-vous faire, Capitaine ?”");
        scenario.Add("“Ouvrez un canal de communication. Essayons d’établir un contact.”");
        scenario.Add("Après un salut militaire à son supérieur, Innoth se rue vers le poste de communication et applique le protocole standard. Sekip, toujours à son poste dans le cockpit, se demande pourquoi tant d'effervescence.");
        scenario.Add("“Attendez, on a enfin quelque chose ?”");
        scenario.Add("“Tout juste, Sekip.”");
        scenario.Add("“Et moi qui commençais à croire qu’on nous avait envoyé ici en espérant qu’on se perde !”");
        scenario.Add("Vous regardez alors Sekip avec un sourire mesquin et affirmez :");
        scenario.Add("“Tu me dois dix dollars !”");
        scenario.Add("“Tu peux toujours rêver, le bleu. C’est pas parce qu’il y a en effet quelque chose, que je n’avais pas raison !”");
        scenario.Add("Vu le caractère de Sekip, vous avez peu de chance de récupérer les dix dollars, qu’il vous doit pour avoir gagné ce pari, mais au moins, vous avez essayé.");
        scenario.Add("“Capitaine, nous n’arrivons pas à rentrer en contact avec le vaisseau, il ouvre son port d'amarrage. Que faisons-nous ?”");
        scenario.Add("“Il semblerait qu’on nous invite… Ce serait malpoli de décliner ! Allons-y !”");
        scenario.Add("C’est ainsi que l’équipe prend le cap pour le vaisseau inconnu.");
        scenario.Add("Quand ils sont enfin accrochés au vaisseau, ils sortent pour tenter de rentrer dans ledit vaisseau inconnu, et tombent face à une porte close. Vous remarquez alors un petit boîtier permettant d’ouvrir la porte.");
        scenario.Add("“Mais attendez, c’est un memory ?”");
        scenario.Add("“On dirait bien… Il va visiblement falloir le résoudre si nous voulons rentrer. Le bleu, à toi l’honneur !”");

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
                SceneManager.LoadScene("Memory");
            Debug.Log("Clic.");
        }
    }
}
