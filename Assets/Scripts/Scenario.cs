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
