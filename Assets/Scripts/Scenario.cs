using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Charge un scénario au format tsv (csv avec tab) écrit dans Google Sheets.
/// Texte,,
/// Texte,,
/// Question,Reponse,Reponse,,
/// </summary>
public class Scenario : MonoBehaviour
{
    public static List<string[]> scenario = new List<string[]>();
    public static int i = 0;

    /// <summary>
    /// Type du texte
    /// - Phrase déclarative
    /// - Phrase interrogative
    /// - Suivi de réponses
    /// </summary>
    public enum Texte
    {
        Declaratif,
        Interrogatif,
        Reponse,
    }

    /// <summary>
    /// Structure de données représentant une phrase et son type.
    /// </summary>
    public struct Phrase
    {
        public readonly Texte type;
        public readonly string contenu;

        public Phrase(Texte type, string contenu)
        {
            this.type = type;
            this.contenu = contenu;
        }
    }

    private void Start()
    {
        StreamReader stream = new StreamReader("Assets/Scenario/scenario.tsv");
        while (!stream.EndOfStream)
        {
            scenario.Add(stream.ReadLine().Replace("\t\t", "").Split('\t'));
        }
        stream.Close();
        DebugScenario();
    }

    /// <summary>
    /// Retourne la prochaine phrase du scénario.
    /// </summary>
    /// <returns></returns>
    public Phrase? Next()
    {
        if (i < scenario.Count)
        {
            if (scenario[i].Length == 1)
            {
                return new Phrase(Texte.Declaratif, scenario[i][0]);
            }
            else
            {
                for (int j = 0; j < scenario[i].Length; j++)
                {
                    if (j == 0)
                    {
                        return new Phrase(Texte.Interrogatif, scenario[i][0]);
                    }
                    else
                    {
                        return new Phrase(Texte.Reponse, scenario[i][j]);
                    }
                }
            }
            i++;
        }
        return null;
    }

    /// <summary>
    /// Affiche le scénario chargé.
    /// </summary>
    private void DebugScenario()
    {
        for (int i = 0; i < scenario.Count; i++)
        {
            if (scenario[i].Length == 1)
            {
                Debug.Log("Texte: " + scenario[i][0]);
            }
            else
            {
                for (int j = 0; j < scenario[i].Length; j++)
                {
                    if (j == 0)
                    {
                        Debug.Log("Question: " + scenario[i][0]);
                    }
                    else
                    {
                        Debug.Log("Réponse: " + scenario[i][j]);
                    }
                }
            }
        }
    }
}
