using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarABA : MonoBehaviour
{
    public Text scenarioText;


    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("Un bip sonore, suivi d’une lumière verte et la porte s’ouvre. Vous découvrez alors une salle sombre avec pour seule source de lumière : une forme étrange possédant des liserés fluorescents de couleur verte.");
        scenario.Add("Sekip étant une personne peu patiente, il s’engouffre dans la pièce et trouve ce qui semble être un interrupteur. Vous fermez les yeux au moment où votre camarade pose sa main sur l'interrupteur, puis vous êtes surpris de ne pas sentir que vous êtes mort.");
        scenario.Add("Une bonne chose en soi.");
        scenario.Add("En ouvrant les yeux, vos yeux s’écarquillent sous l'incompréhension.");
        scenario.Add("“C’est une blague ?”");
        scenario.Add("Non, non. La faible lumière verdâtre qui sert à éclairer la pièce révèle l’objet visible plus tôt. Cela semble être un berceau.");
        scenario.Add("Sekip se place derrière vous et vous pousse légèrement.");
        scenario.Add("“Va jeter un oeil.”");
        scenario.Add("On dirait que vous n’avez pas le choix. Vous avancez lentement en direction du berceau.");
        scenario.Add("Une ignoble créature, verte, aux yeux globuleux, avec des quatre tentacules verts au lieu des bras, et de grandes dents de requin dans la bouche, gigote dans le berceau.");
        scenario.Add("Horrifié, vous reculez précipitamment pour vous éloigner de ce monstre et vous entravez dans un câble sur le sol. Vous tombez alors dans un bassin derrière vous, rempli d’un liquide vert épais.");
        scenario.Add("Vous luttez pour essayer de remonter en retenant votre respiration, mais vous ne pouvez pas nager dans ce liquide épais et visqueux. Vous êtes donc en train de vous noyer.");
        scenario.Add("A bout de force, vous ouvrez la bouche et vous sentez le liquide vous pénétrer la gorge et les poumons. Vous tentez de cracher mais ne pouvez pas et devez donc supporter sans rien faire l’affreuse sensation de brûlure qui se répand de votre bouche à votre poitrine.");
        scenario.Add("Petit à petit, la sensation prend de l’ampleur, concernant bientôt tout votre corps. Puis, pendant un instant, vous ne ressentez plus rien. Votre esprit se vide et vous restez là une minute avant que les sensations reviennent dans votre corps.");
        scenario.Add("Vous bougez vos membres et remontez à la surface sans problème, empli d’une rage nouvelle.");
        scenario.Add("A la surface, vous apercevez des amuses-gueules étranges, gesticulants et criants, mais particulièrement appétissants et ayant terriblement faim, vous vous jetez dessus et les dévorez avec une grande satisfaction.");
        scenario.Add("Vous avancez ensuite dans la pièce et apercevez votre reflet. Intrigué, vous le regardez et l'admirez avec fierté. Cette peau verte sur laquelle la lumière se reflète, vos yeux d’un noir profond, plutôt charmeur, et ses quatre bras musclés !");
        scenario.Add("Oh oui, vous étiez véritablement un beau spécimen.");
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
                SceneManager.LoadScene("Fin10");
            Debug.Log("Clic.");
        }
    }
}


