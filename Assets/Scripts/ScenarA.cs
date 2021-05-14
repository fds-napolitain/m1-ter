using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenarA : MonoBehaviour
{

    public Text scenarioText;
    public Text questionText;
    public Text reponse1Text;
    public Text reponse2Text;
    public Text reponse3Text;

    public List<string> scenario = new List<string>();
    public List<string> scenario1 = new List<string>();
    public List<string> scenario2 = new List<string>();
    public List<string> scenario3 = new List<string>();
    public string question;
    public string reponse1;
    public string reponse2;
    public string reponse3;
    public int i = 0;
    public int branche = 0;

    private void Start()
    {
        scenario.Add("La porte s’ouvre devant vous, dévoilant l’intérieur du vaisseau.");
        scenario.Add("Vous entrez avec précaution. Le capitaine préfère vous envoyer devant, sûrement pour que vous soyez le premier touché par quoi que ce soit qui pourrait se passer.");
        scenario.Add("Les couloirs du vaisseau sont étonnamment grands et vous commencez à vous inquiéter de la taille de ses occupants.");
        scenario.Add("La technologie est assez rustique et vous devez utiliser votre lampe torche pour voir plus clair dans ce dédale de couloirs sombres.");
        scenario.Add("Bientôt, vous arrivez à une intersection. Trois choix s’offrent à vous : tout droit, à droite ou à gauche.");
        scenario.Add("Loulou s’excite en indiquant le couloir d’en face, Innoth affirme que la plupart des gens vont à gauche dans un cas comme celui-là et que nous devrions donc peut-être essayer la direction opposée, et Sekip insiste pour aller à gauche disant qu’il a un bon pressentiment à ce propos.");
        scenario.Add("Le choix vous revient donc. Vous choisissez d’aller :");
        scenarioText.text = scenario[i];
        i++;

        scenario1.Add("Vous avez visiblement plus confiance en Loulou qu’en les autres membres de votre équipage. C’est un choix étonnant.");
        scenario1.Add("Vous avancez donc dans le couloir d’en face lorsque Loulou saute par terre et s’élance dans le couloir sans vous attendre. Vous vous mettez alors tous à courir pour le rattraper.");
        scenario1.Add("Vous arrivez à une nouvelle intersection et évidemment, vous l’avez perdu. Vous choisissez donc de vous séparer. Vous et le capitaine irez en face, Innoth à droite et Sekip à gauche.");
        scenario1.Add("Si vous aviez réfléchi un peu plus, vous auriez réalisé que cela ressemblait en tout point au début d’un film d’horreur…");
        scenario1.Add("Vous progressez en appelant désespérément le nom du petit singe, lorsque que vous entendez un long hurlement. C’était la voix de Innoth.");
        scenario1.Add("Vous faites alors demi-tour en courant et prenez le chemin qu’elle a suivi. Malheureusement, la seule chose que vous trouvez c’est du sang formant un chemin jusqu’à une porte close.");
        scenario1.Add("“Encore une memory !”");
        scenario1.Add("“Euh non, cette fois je crois que c’est un jeu de couleurs à retenir et à reproduire !”");
        scenario1.Add("“Mais qu’est-ce qu’ils ont avec les mini-jeux dans ce vaisseau ? Allez Spat, tu sais ce qu’il te reste à faire!”");

        scenario2.Add("Pour une raison étonnante, vous décidez de suivre le choix de Sekip même s’il vous déteste.");
        scenario2.Add("Vous avancez dans ce couloir et arrivez dans une impasse avec une simple porte. Cette porte s’ouvre à l’aide d’un jeu de couleurs à retenir sur un petit boîtier numérique.");
        scenario2.Add("Vous échangez un regard avec vos camarades et tentez d’ouvrir cette porte en réussissant le mini-jeu.");

        scenario3.Add("Vous choisissez la logique et suivez ce que vous dit Innoth.");
        scenario3.Add("Vous avancez dans ce long couloir en faisant attention au moindre bruit et finissez par tomber sur ce qui ressemblait à une porte blindée doublement renforcée.");
        scenario3.Add("Un petit boîtier tactile, semblable à celui de la porte d’embarquement, permet de déverrouiller la porte. Contrairement à précédemment, ce n’est pas memory, mais un simon qu’il faut réussir.");
        scenario3.Add("Encore une fois, la tâche vous incombe de vous en occuper.");

        questionText.text = "";
        reponse1Text.text = "";
        reponse2Text.text = "";
        reponse3Text.text = "";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            if(i == scenario.Count - 1 && branche == 0)
            {
                scenarioText.text = "";
                questionText.text = scenario[i];
                reponse1Text.text = "En face";
                reponse2Text.text = "A gauche";
                reponse3Text.text = "A droite";
            }
            else
            {
                if (i != scenario.Count)
                {
                    scenarioText.text = scenario[i];
                    i++;
                }
                else
                {
                    if (branche == 1)
                    {
                        SceneManager.LoadScene("Simon");
                    }
                    else if (branche == 2)
                    {
                        SceneManager.LoadScene("Simon2");
                    }
                    else
                    {
                        SceneManager.LoadScene("Simon3");
                    }
                }
                Debug.Log("Clic.");
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (reponse1Text.text.Length != 0)
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.gameObject.name == "Reponse1")
                    {
                        scenario = scenario1;
                        branche = 1;
                        questionText.text = "";
                        reponse1Text.text = "";
                        reponse2Text.text = "";
                        reponse3Text.text = "";
                        i = 0;
                        scenarioText.text = scenario[i];
                        i++;
                    }
                    else if (hit.collider.gameObject.name == "Reponse2")
                    {
                        scenario = scenario2;
                        branche = 2;
                        questionText.text = "";
                        reponse1Text.text = "";
                        reponse2Text.text = "";
                        reponse3Text.text = "";
                        i = 0;
                        scenarioText.text = scenario[i];
                        i++;
                    }
                    else if (hit.collider.gameObject.name == "Reponse3")
                    {
                        scenario = scenario3;
                        branche = 3;
                        questionText.text = "";
                        reponse1Text.text = "";
                        reponse2Text.text = "";
                        reponse3Text.text = "";
                        i = 0;
                        scenarioText.text = scenario[i];
                        i++;
                    }
                    i = 0;
                }
            }
        }
    }
}
