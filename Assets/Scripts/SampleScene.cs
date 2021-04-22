using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Scenario;

public class SampleScene : MonoBehaviour
{
    public Text scenarioText;

    void Start()
    {
        Phrase? phrase = Next();
        if (phrase.HasValue)
        {
            if (phrase.Value.type == Texte.Interrogatif)
            {

            }
            Debug.Log(phrase.Value.contenu);
            scenarioText.text = phrase.Value.contenu;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
        {
            Phrase? phrase = Next();
            if (phrase.HasValue)
            {
                if (phrase.Value.type == Texte.Interrogatif)
                {

                }
                Debug.Log(phrase.Value.contenu);
                scenarioText.text = phrase.Value.contenu;
            }
        }
    }

    /// <summary>
    /// Retourne la prochaine phrase du scénario.
    /// </summary>
    /// <returns></returns>
    public static Phrase? Next()
    {
        if (GameStateManager.i < GameStateManager.scenario.Count)
        {
            if (GameStateManager.scenario[GameStateManager.i].Length == 1)
            {
                return new Phrase(Texte.Declaratif, GameStateManager.scenario[GameStateManager.i][0]);
            }
            else
            {
                for (int j = 0; j < GameStateManager.scenario[GameStateManager.i].Length; j++)
                {
                    if (j == 0)
                    {
                        return new Phrase(Texte.Interrogatif, GameStateManager.scenario[GameStateManager.i][0]);
                    }
                    else
                    {
                        return new Phrase(Texte.Reponse, GameStateManager.scenario[GameStateManager.i][j]);
                    }
                }
            }
            GameStateManager.i++;
        }
        return null;
    }

}
