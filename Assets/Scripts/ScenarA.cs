using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarA : MonoBehaviour
{

    public Text scenarioText;
    public Text questionText;
    public Text reponse1Text;
    public Text reponse2Text;
    public Text reponse3Text;

    public List<string> scenario = new List<string>();
    public string question;
    public string reponse1;
    public string reponse2;
    public string reponse3;
    public int i = 0;

    private void Start()
    {
        scenario.Add("La porte s’ouvre devant vous, dévoilant l’intérieur du vaisseau.");
        scenario.Add("Vous entrez avec précaution. Le capitaine préfère vous envoyer devant, sûrement pour que vous soyez le premier touché par quoi que ce soit qui pourrait se passer.");
        scenario.Add("Les couloirs du vaisseau sont étonnamment grands et vous commencez à vous inquiéter de la taille de ses occupants.");
        scenario.Add("La technologie est assez rustique et vous devez utiliser votre lampe torche pour voir plus clair dans ce dédale de couloirs sombres.");
        scenario.Add("Bientôt, vous arrivez à une intersection.Trois choix s’offrent à vous: tout droit, à droite ou à gauche.");
        scenario.Add("Loulou s’excite en indiquant le couloir d’en face, Innoth affirme que la plupart des gens vont à gauche dans un cas comme celui là et que nous devrions donc peut - être essayer la direction opposée, et Sekip insiste pour aller à gauche disant qu’il a un bon pressentiment à ce propos.");
        scenario.Add("Le choix vous revient donc.Vous choisissez d’aller:");
        scenarioText.text = scenario[i];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (reponse1Text.text.Length != 0)
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.gameObject.name == "Reponse1")
                    {
                        Debug.Log("Réponse 1 cliqué.");
                    }
                    else if (hit.collider.gameObject.name == "Reponse2")
                    {
                        Debug.Log("Réponse 2 cliqué.");
                    }
                    else if (hit.collider.gameObject.name == "Reponse3")
                    {
                        Debug.Log("Réponse 3 cliqué.");
                    }
                }
            }
            Debug.Log("Clic.");
        }
    }
}
