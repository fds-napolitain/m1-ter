using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hanoi : MonoBehaviour
{
    // global const
    private static int CP_MAX = 10;
    private static int SPEED = 15;
    // global variables
    private static int cp = 0;
    private static bool flag = false;
    private static List<Stack<int>> tours = new List<Stack<int>>();
    private static Hanoi pointeurFil;
    private static bool locked = false; // true si mouvement en cours qui n'est pas une sélection
    // variables
    private int indice; // indice (par rapport aux tours)
    private int value; // valeurs du fil
    private float[] coords = { 0f, 0f }; // coordonnées a bouger

    /// <summary>
    /// Initialisation pour chaque objet
    /// </summary>
    void Start()
    {
        if (!flag)
        {
            tours.Add(new Stack<int>());
            tours.Add(new Stack<int>());
            tours.Add(new Stack<int>());
            flag = true;
        }
        if (name == "pic1")
        {
            tours[0].Push(3);
            tours[0].Push(2);
            tours[0].Push(1);
        }
        if (name.StartsWith("fil")) // initialisation fil tour 1
        {
            indice = 0;
            switch (name)
            {
                case "fil1":
                    value = 1;
                    break;
                case "fil2":
                    value = 2;
                    break;
                case "fil3":
                    value = 3;
                    break;
            }
        }
    }

    /// <summary>
    /// Logique pour chaque frame, pour chaque objet.
    /// </summary>
    void Update()
    {
        if (coords[0] != 0 || coords[1] != 0)
        {
            // bouge x
            if (coords[0] > 0.1 || coords[0] < -0.1)
            {
                MoveByVector2(Vector2.right * Math.Sign(coords[0]) * SPEED * Time.deltaTime);
            }
            else // arrondi x a la valeur qu'il faut
            {
                if (coords[0] != 0)
                {
                    MoveByVector2(Vector2.right * coords[0], true);
                    GetComponent<Rigidbody2D>().gravityScale = 1f;
                }
            }
            // bouge y
            if (coords[1] > 0.1)
            {
                MoveByVector2(Vector2.up * Math.Sign(coords[1]) * SPEED * Time.deltaTime);
            }
            else // arrondi y a la valeur qu'il faut
            {
                if (coords[1] != 0)
                {
                    MoveByVector2(Vector2.up * coords[1], true);
                    locked = false; // fin mouvement (haut) => déblocage
                }
            }
        }
    }

    /// <summary>
    /// Move by Vector2(x, y) with optional parameter round
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="round"></param>
    private void MoveByVector2(Vector2 vector, bool round = false)
    {
        transform.Translate(vector, Space.Self);
        if (!round)
        {
            coords[0] -= vector[0];
            coords[1] -= vector[1];
        }
        else
        {
            coords[0] = (float)Math.Round(coords[0], 0);
            coords[1] = (float)Math.Round(coords[1], 0);
        }
    }

    /// <summary>
    /// Détection de collision (Rigidbody2D)
    /// Ici, quand l'object tombe sur le sol, reset du pointeurFil (pour avoir à le resélectionner).
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (pointeurFil != null && pointeurFil.GetComponent<Rigidbody2D>().gravityScale == 1f)
        {
            locked = false; // fin mouvement (bas / gravité) => déblocage
            pointeurFil = null;
            if (tours[2].Count == 3) // victoire
            {
                SceneManager.LoadScene("Corridor_AA");
            }
        }
    }

    /// <summary>
    /// Détection de clics (BoxCollider2D)
    /// Grosse partie de la logique...
    /// </summary>
    private void OnMouseDown()
    {
        if (!locked) // blocage si mouvement en cours
        {
            if (name.StartsWith("fil"))
            {
                Debug.Log(tours[indice].Peek() + " " + value);
                if (tours[indice].Peek() == value && pointeurFil != this) // nv pointeur
                {
                    GetComponent<Rigidbody2D>().gravityScale = 0f;
                    coords[1] += 6f;
                    locked = true; // sélection fil => blocage
                    Debug.Log(pointeurFil == null);
                    if (pointeurFil != null) // ancien pointeur
                    {
                        pointeurFil.GetComponent<Rigidbody2D>().gravityScale = 1f;
                    }
                    pointeurFil = this;
                }
            }
            if (name.StartsWith("pic"))
            {
                if (pointeurFil != null)
                {
                    int indiceTour;
                    switch (name)
                    {
                        case "pic1":
                            indiceTour = 0;
                            break;
                        case "pic2":
                            indiceTour = 1;
                            break;
                        case "pic3":
                            indiceTour = 2;
                            break;
                        default:
                            indiceTour = -1;
                            break;
                    }
                    if (pointeurFil.indice != indiceTour && (tours[indiceTour].Count == 0 || tours[indiceTour].Peek() > pointeurFil.value))
                    {
                        tours[indiceTour].Push(pointeurFil.value);
                        tours[pointeurFil.indice].Pop();
                        pointeurFil.coords[0] += (indiceTour - pointeurFil.indice) * 6f; // mouvement
                        pointeurFil.indice = indiceTour;
                        locked = true; // sélection tour => blocage
                        cp++;
                        if (CP_MAX == cp) // défaite
                        {
                            SceneManager.LoadScene("Hangar_AB");
                        }
                    }
                }
            }
        }
    }
}
