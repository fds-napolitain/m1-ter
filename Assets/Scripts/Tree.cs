using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Structure de données utilisé pour le scénario.
    /// Arbre souple.
    /// </summary>
    public class Tree
    {
        public TreeNode node = new TreeNode("Cliquer pour commencer"); // point d'entrée
        private TreeNode current; // utilisé pour le parseur

        public Tree()
        {
            // lecture du fichier importé sous format txt (google docs)
            StreamReader stream = new StreamReader("Assets/Scenario/scenario.txt");
            List<string> tmp = new List<string>();
            while (!stream.EndOfStream)
            {
                string line = stream.ReadLine();
                if (line.Length > 0 && !line.StartsWith("--") && !line.StartsWith("__"))
                {
                    // rajoute les lignes seulement pleines et sans les lignes "---------------"
                    tmp.Add(line);
                }
            }
            // pour chaque ligne
            current = node;
            int i = 0;
            while (i < tmp.Count)
            {
                // question, réponses (suivi de texte)
                if (i < tmp.Count - 1 && tmp[i + 1].Contains("CHOIX")) 
                {
                    // 3 réponses
                    if (!tmp[i + 4].Contains("ROUTE")) 
                    {
                        current.AddChild(new TreeNode(tmp[i], tmp[i + 2], tmp[i + 3], tmp[i + 4]));
                        i += 4;
                    }
                    // 2 réponses
                    else
                    {
                        current.AddChild(new TreeNode(tmp[i], tmp[i + 2], tmp[i + 3]));
                        i += 3;
                    }
                    current = current.children[0];
                    Debug.LogError(current.phrase);
                }
                // après un choix (q, r)
                else if (i > 0 && i < tmp.Count-1 && tmp[i-1].Contains("ROUTE")) 
                {
                    current = node;
                    string path = Regex.Split(tmp[i-1], " ")[1];
                    // parcours de l'arbre pour ajouter
                    while (path.Length >= 3)  
                    {
                        if (path.StartsWith("A"))
                        {
                            current = current.children[0];
                        }
                        else if (path.StartsWith("B"))
                        {
                            current = current.children[1];
                        }
                        else
                        {
                            current = current.children[2];
                        }
                        path = path.Substring(2, path.Length-2);
                    }
                    // changement de scène
                    if (tmp[i].Contains("//")) 
                    {
                        if (tmp[i].Contains("couloir"))
                        {
                            current.AddChild(new TreeNode(tmp[i + 1], "Corridor_AA"));
                        }
                        if (tmp[i].Contains("repos"))
                        {
                            current.AddChild(new TreeNode(tmp[i + 1], "Hangar_AA"));
                        }
                        if (tmp[i].Contains("sortie"))
                        {
                            current.AddChild(new TreeNode(tmp[i + 1], "Ending"));
                        }
                        else
                        {
                            current.AddChild(new TreeNode(tmp[i]));
                        }
                    }
                    else
                    {
                        current.AddChild(new TreeNode(tmp[i]));
                    }
                    current = current.children[0];
                }
                // texte classique
                else
                {
                    current.AddChild(new TreeNode(tmp[i]));
                    current = current.children[0];
                }
                i++;
            }
        }
    }
}
