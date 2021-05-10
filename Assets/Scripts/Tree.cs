using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    /// <summary>
    /// Structure de données utilisé pour le scénario.
    /// Arbre souple.
    /// </summary>
    public class Tree
    {
        public TreeNode node = new TreeNode("Cliquer pour commencer"); // point d'entrée

        public Tree()
        {
            // lecture du fichier importé sous format txt (google docs)
            StreamReader stream = new StreamReader("Assets/Scenario/scenario.txt");
            List<string> tmp = new List<string>();
            while (!stream.EndOfStream)
            {
                string line = stream.ReadLine();
                if (!line.StartsWith("--") && line.Length > 0)
                {
                    // rajoute les lignes seulement pleines et sans les lignes "---------------"
                    tmp.Add(line);
                }
            }
            // pour chaque ligne
            for (int i = 0; i < tmp.Count; i++)
            {
                if (i < tmp.Count - 1 && tmp[i + 1].StartsWith("CHOIX")) // question, réponses (suivi de texte)
                {
                    if (tmp[i + 4].StartsWith("ROUTE")) // 3 réponses
                    {
                        node.AddChild(new TreeNode(tmp[i], tmp[i + 2], tmp[i + 3], tmp[i + 4]));
                        i += 4;
                    }
                    else // 2 réponses
                    {
                        node.AddChild(new TreeNode(tmp[i], tmp[i + 2], tmp[i + 3]));
                        i += 3;
                    }
                }
                else if (i > 0 && i < tmp.Count-1 && tmp[i-1].StartsWith("ROUTE")) // après un choix (q, r)
                {
                    TreeNode treeNode = node;
                    string path = Regex.Split(tmp[i-1], " ")[1];
                    while (path.Length > 1) // parcours de l'arbre pour ajouter 
                    {
                        if (path.StartsWith("A"))
                        {
                            treeNode = treeNode.children[0];
                        }
                        else if (path.StartsWith("B"))
                        {
                            treeNode = treeNode.children[1];
                        }
                        else
                        {
                            treeNode = treeNode.children[2];
                        }
                        path = path.Substring(2, path.Length);
                    }
                    if (tmp[i].StartsWith("//")) // changement de scène
                    {
                        if (tmp[i].Contains("couloir"))
                        {
                            treeNode.AddChild(new TreeNode(tmp[i + 1], "Corridor_AA"));
                        }
                        if (tmp[i].Contains("repos"))
                        {
                            treeNode.AddChild(new TreeNode(tmp[i + 1], "Hangar_AA"));
                        }
                        if (tmp[i].Contains("sortie"))
                        {
                            treeNode.AddChild(new TreeNode(tmp[i + 1], "Ending"));
                        }
                    }
                    else
                    {
                        treeNode.AddChild(new TreeNode(tmp[i]));
                    }
                }
                else // texte classique
                {
                    node.AddChild(new TreeNode(tmp[i]));
                }
            }
        }
    }
}
