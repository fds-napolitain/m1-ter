using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarACAABB : MonoBehaviour
{
    public Text scenarioText;


    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("Le message “porte verrouillée” s’affiche devant vos yeux et vous paniquez. Vous commencez à être surpassé par le nombre, et des renforts armés arrivent !");
        scenario.Add("Vous regardez donc autour de vous désespérés et quelque chose saute dans votre cerveau. Vous dégainez alors votre sabre et vous prenez pour une espèce de grosse brute, héros d’un film d’action, avant de vous jeter dans le tas en criant.");
        scenario.Add("Une seconde plus tard, un rayon plasmique vous fait exploser !");
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
                SceneManager.LoadScene("Fin14");
            Debug.Log("Clic.");
        }
    }
}
