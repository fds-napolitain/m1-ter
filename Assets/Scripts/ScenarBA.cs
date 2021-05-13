using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarBA : MonoBehaviour
{
    public Text scenarioText;


    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("La porte s’ouvre devant vous, et vous soupirez de soulagement. Cette fois au moins vous avez réussi.");
        scenario.Add("Le capitaine passe devant avec Loulou, et vous vous retrouvez en queue de ploton.");
        scenario.Add("Vous progressez dans le vaisseau, vous étonnant devant sa rusticité et observant chaque détail de ces couloirs sous la lumière faible des lieux.");
        scenario.Add("Plus vous progressez et plus vous avez le sentiment que vous ne sortirez jamais vivant de ces lieux, mais vous vous convainquez que c’est parce que c’est votre première mission.");
        scenario.Add("Une porte ouverte attire votre attention à une intersection.");
        scenario.Add("“Capitaine ! Il y a une porte ouverte là-bas !” vous exclamez vous.");
        scenario.Add("Vos compagnons s’arrêtent alors et le capitaine vient vous rejoindre à l’intersection où vous vous êtes arrêté pour constater les faits.");
        scenario.Add("Finalement, il vous fait signe de le suivre avec vos camarades, et c’est ainsi que vous pénétrez dans ce qui ressemble à un vieux laboratoire de scientifique fou.");
        scenario.Add("Vous faites le tour des lieux curieux, vous demandant à quoi servent la plupart des objets, fioles et trucs étranges en tout genre que vous voyez.");
        scenario.Add("Soudain un cri dans la salle vous fait sursauter. Sekip était en train d’observer un organisme inconnu dans un bocal géant rempli de fluide, quand soudains l’organisme à ouvert les yeux et prononcé faiblement :");
        scenario.Add("“Aidez-moi”");
        scenario.Add("Il n’en fallut pas plus pour qu’il comprenne que cette chose difforme était humaine avant. Il avait donc lâché un cri (celui qui vous avait fait sursauter) et avait reculé précipitamment.");
        scenario.Add("Dans sa précipitation, vous le voyez bousculer Innoth qui déséquilibré s’entrave dans la chaise à côté d’elle et frappe le bord d’une planche en bois en équilibre avec sa main en tombant.");
        scenario.Add("Le bécher sur la planche en bois s'envole, libérant son contenu qui atterrit dans les yeux du capitaine. Ce dernier hurle de douleur et avance à l’aveugle dans la pièce.");
        scenario.Add("Il marche alors sur la queue de Loulou qui crie et jette la petite fiole qu’il tenait dans votre direction. Vous sentez la fiole vous percuter et l’instant d’après, vous voyez le monde de beaucoup plus bas.");
        scenario.Add("Vous cherchez à parler pour demander ce qu’il s’est passé, mais vous en êtes incapable. Vous essayez donc de bouger, de tourner la tête, de faire des signes, mais vous êtes comme paralysé, complètement incapable de bouger.");
        scenario.Add("Le capitaine se débarrasse finalement du liquide qu’il a dans les yeux et commence à engueuler Sekip quand Innoth les interrompt.");
        scenario.Add("“Euh… Capitaine ?”");
        scenario.Add("“Quoi” s’emporte-t-il un peu plus");
        scenario.Add("Elle désigne alors quelque chose plus loin dans la pièce et s’exclame :");
        scenario.Add("“Je… Je crois que c’est Spat”");
        scenario.Add("Tous les regards se tournèrent alors vers vous et vous les voyez s’approcher de vous, vous surplombant de toute leur hauteur.");
        scenario.Add("“Mais qu’est ce que c’est ?”");
        scenario.Add("“Une Welwitschia Mirabilis” répond Innoth.");
        scenario.Add("Les connaissances de cette fille vous étonneront toujours.");
        scenario.Add("“Une quoi ?” demande Sekip");
        scenario.Add("“Une Welwitschia Mirabilis ! Une plante des déserts côtiers de Namibie et d'Angola.”");
        scenario.Add("“Et on va faire quoi de lui maintenant ?”");
        scenario.Add("“Je crois que nous n’avons d’autres choix que de le laisser ici” affirme le Capitaine. “Sauf si l’un de vous sait comment le détransformer…”");
        scenario.Add("Ils échangent un regard puis vous jettent un coup d'œil avant de prendre la direction de la sortie. Vous essayez alors de hurler pour les retenir, mais vous êtes toujours aussi silencieux.");
        scenario.Add("Innoth est la dernière personne à sortir. Elle vous jette un regard coupable et s’excuse une dernière fois avant de partir :");
        scenario.Add("“Désolé Spat”");
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
                SceneManager.LoadScene("Fin17");
            Debug.Log("Clic.");
        }
    }
}