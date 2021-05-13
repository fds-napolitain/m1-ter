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
