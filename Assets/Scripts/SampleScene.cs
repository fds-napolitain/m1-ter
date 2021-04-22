using UnityEngine;
using UnityEngine.UI;

public class SampleScene : MonoBehaviour
{
    public Text scenarioText;
    public Text questionText;
    public Text reponsesText;

    void Start()
    {
        Next();
        Debug.Log("Next()" + GameStateManager.text_indice);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            Next();
        }
    }

    /// <summary>
    /// Retourne la prochaine phrase du scénario.
    /// </summary>
    /// <returns></returns>
    public void Next()
    {
        if (GameStateManager.text_indice < GameStateManager.scenario.Count)
        {
            if (GameStateManager.scenario[GameStateManager.text_indice].Length == 1)
            {
                scenarioText.text = GameStateManager.scenario[GameStateManager.text_indice][0];
                questionText.text = "";
                reponsesText.text = "";
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
                    else
                    {
                        reponsesText.text += GameStateManager.scenario[GameStateManager.text_indice][j] + "\n";
                    }
                }
            }
            GameStateManager.text_indice++;
        }
    }

}
