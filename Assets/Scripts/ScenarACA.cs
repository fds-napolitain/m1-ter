using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarACA : MonoBehaviour
{
    public Text scenarioText;


    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("La porte devant vous s’ouvre sur ce qui semble être une gigantesque armurerie. Vous et le reste de l’équipage êtes comme des enfants un matin de Noël.");
        scenario.Add("Vous vous dispersez dans la pièce pour mieux l’explorer.");
        scenario.Add("Vous restez bientôt figé devant des armes semblables à des pistolets à eau mais avec un réservoir remplit de liquide noir étrange. Vous avez soudainement très envie de les essayer !");
        scenario.Add("Un clic retentit alors derrière vous, suivi d’un bip régulier. Vous avez un mauvais pressentiment. Vous vous retournez lentement en direction du bruit et trouvez Sekip l’air coupable, debout devant une machine désormais activée et produisant ces bips.");
        scenario.Add("“Sekip ! Bon sang, mais qu’est-ce que tu as fait ?!”");
        scenario.Add("“C’est pas moi Capitaine, c’est Loulou !”");
        scenario.Add("Le petit singe proteste alors en sautant sur l’épaule de Sekip pour lui tirer les oreilles.");
        scenario.Add("“C’est pas important pour l’instant ! Nous devons surtout désamorcer cette arme !”");
        scenario.Add("Encore une fois, Innoth est la voix de la raison.");
        scenario.Add("Vous vous approchez donc de l’arme avec elle et découvrez que le boîtier est fermé par quatre anneaux de taille croissante posés sur une barre en métal, à côté de deux autres barres vides.");
        scenario.Add("Pour ouvrir le boîtier, vous devez déplacer les anneaux sur la barre de droite. Toutefois, le nombre de coups pour effectuer cette action est limité car votre temps est limité !");
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
                SceneManager.LoadScene("Hanoi2");
            Debug.Log("Clic.");
        }
    }
}



