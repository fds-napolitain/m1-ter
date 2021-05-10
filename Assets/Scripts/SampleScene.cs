using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SampleScene : MonoBehaviour
{
    public Text scenarioText;
    public Text questionText;
    public Text reponse1Text;
    public Text reponse2Text;
    public Text reponse3Text;

    void Start()
    {
        Next();
        Debug.Log("Next()" + GameStateManager.text_indice);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (reponse1Text.text.Length != 0)
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
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
            Next();
            Debug.Log("Clic.");
        }
    }

    /// <summary>
    /// Retourne la prochaine phrase du scénario.
    /// </summary>
    /// <returns></returns>
    public void Next()
    {/*
        if (GameStateManager.text_indice < GameStateManager.scenario.Count)
        {
            if (GameStateManager.scenario[GameStateManager.text_indice].Length == 1)
            {
                scenarioText.text = GameStateManager.scenario[GameStateManager.text_indice][0];
                questionText.text = "";
                reponse1Text.text = "";
                reponse2Text.text = "";
                reponse3Text.text = "";
            }
            else
            {
                for (int j = 0; j < GameStateManager.scenario[GameStateManager.text_indice].Length; j++)
                {
                    if (j == 0)
                    {
                        scenarioText.text = "";
                        questionText.text = GameStateManager.scenario[GameStateManager.text_indice][0];
                    }
                    else if (j == 1)
                    {
                        reponse1Text.text = GameStateManager.scenario[GameStateManager.text_indice][1];
                    } 
                    else if (j == 2)
                    {
                        reponse2Text.text = GameStateManager.scenario[GameStateManager.text_indice][2];
                    }
                    else if (j == 3)
                    {
                        reponse3Text.text = GameStateManager.scenario[GameStateManager.text_indice][3];
                    }
                }
            }
            GameStateManager.text_indice++;
        }*/
    }

}
