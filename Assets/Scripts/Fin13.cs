using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin13 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Bravo, vous avez effectué votre mission avec brio. Vous avez protégé vos coéquipiers, obtenu des armes dont vous êtes fan et récupéré un vaisseau qui sera démantelé par une compagnie et vous rapportera une prime généreuse !";
        finText.text = fin;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
