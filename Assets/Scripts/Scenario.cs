using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Test
/// </summary>
public class Scenario : MonoBehaviour
{

    /// <summary>
    /// Type du texte
    /// - Phrase déclarative (centre)
    /// - Phrase interrogative (un peu au dessus)
    /// - Suivi de réponses (un peu au dessous)
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
        public readonly int index;

        public Phrase(Texte type, string contenu, int index = 1)
        {
            this.type = type;
            this.contenu = contenu;
            this.index = index;
        }
    }

}
