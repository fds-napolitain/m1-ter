using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    /// <summary>
    /// TreeNode utilisé pour Tree (comme LinkedListNode pour LinkedList).
    /// </summary>
    public class TreeNode
    {
        public string phrase; // phrase
        public string question; // phrase
        public string reponse1; // phrase
        public string reponse2; // phrase
        public string reponse3; // phrase
        public string scene; // scene de la phrase
        public List<TreeNode> children = new List<TreeNode>(); // prochains TreeNodes

        /// <summary>
        /// Construit un TreeNode à partir d'une phrase simple.
        /// </summary>
        /// <param name="phrase"></param>
        public TreeNode(string phrase)
        {
            this.phrase = phrase;
        }

        /// <summary>
        /// Construit un TreeNode à partir d'une phrase, et d'une nouvelle scène.
        /// </summary>
        /// <param name="phrase"></param>
        /// <param name="scene"></param>
        public TreeNode(string phrase, string scene)
        {
            this.phrase = phrase;
            this.scene = scene;
        }

        /// <summary>
        /// Construit un TreeNode à partir d'une question et de plusieurs réponses.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="reponse1"></param>
        /// <param name="reponse2"></param>
        /// <param name="reponse3"></param>
        public TreeNode(string question, string reponse1, string reponse2, string reponse3 = "")
        {
            this.question = question;
            this.reponse1 = reponse1;
            this.reponse2 = reponse2;
            this.reponse3 = reponse3;
        }

        /// <summary>
        /// Ajoute un TreeNode (nombre de fils variable).
        /// </summary>
        /// <param name="treeNode"></param>
        public void AddChild(TreeNode treeNode)
        {
            children.Add(treeNode);
        }

        /// <summary>
        /// Renvoit le prochain TreeNode à partir de l'indice i (par défaut = 0).
        /// </summary>
        /// <param name="i"></param>
        public void Next(int i = 0)
        {
            if (children[i].scene.Length > 0)
            {
                SceneManager.LoadScene(children[i].scene);
            }
        }

        /// <summary>
        /// Affiche récursivement le TreeNode depuis lui même vers tous ses fils.
        /// </summary>
        public void Print(int i = 0)
        {
            if (!String.IsNullOrEmpty(phrase))
            {
                Debug.Log(new String('-', i) + " " + phrase);
                if (children.Count > 0)
                    children[0].Print(i + 1);
            }
            else if (!String.IsNullOrEmpty(question))
            {
                Debug.Log(new String('-', i) + " " + question);
                Debug.Log(new String('-', i) + " " + reponse1);
                if(children.Count > 0)
                    children[0].Print(i + 1);
                Debug.Log(new String('-', i) + " " + reponse2);
                if (children.Count > 1)
                    children[1].Print(i + 1);
                if (!String.IsNullOrEmpty(reponse3)) { 
                    Debug.Log(new String('-', i) + " " + reponse3);
                    if (children.Count > 2)
                        children[2].Print(i + 1);
                }
            }
        }
    }
}
