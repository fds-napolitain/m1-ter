using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hanoi2 : MonoBehaviour
{
    // global const
    private static int CP_MAX = 20;
    private static int SPEED = 15;
    // global variables
    private static int cp = 0;
    private static bool flag = false;
    private static List<Stack<int>> tours = new List<Stack<int>>();
    private static Hanoi2 pointeurFil;
    private static bool locked = false; // true si mouvement en cours qui n'est pas une sélection
    public Sprite coup0, coup1, coup2, coup3, coup4, coup5, coup6, coup7, coup8, coup9, coup10, coup11, coup12, coup13, coup14, coup15, coup16, coup17, coup18, coup19;
    public SpriteRenderer spriteRenderer;
    // variables
    private int indice; // indice (par rapport aux tours)
    private int value; // valeurs du fil
    private float[] coords = { 0f, 0f }; // coordonnées a bouger, à 0 plus rien ne bouge

    /// <summary>
    /// Initialisation pour chaque objet
    /// </summary>
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!flag)
        {
            tours.Add(new Stack<int>());
            tours.Add(new Stack<int>());
            tours.Add(new Stack<int>());
            flag = true;
        }
        if (name == "pic1")
        {
            tours[0].Push(4);
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
                case "fil4":
                    value = 4;
                    break;
            }
        }
    }

    /// <summary>
    /// Logique pour chaque frame, pour chaque objet.
    /// </summary>
    void Update()
    {
        if (name.StartsWith("coup"))
        {
            switch (cp)
            {
                case 1:
                    spriteRenderer.sprite = coup19;
                    break;
                case 2:
                    spriteRenderer.sprite = coup18;
                    break;
                case 3:
                    spriteRenderer.sprite = coup17;
                    break;
                case 4:
                    spriteRenderer.sprite = coup16;
                    break;
                case 5:
                    spriteRenderer.sprite = coup15;
                    break;
                case 6:
                    spriteRenderer.sprite = coup14;
                    break;
                case 7:
                    spriteRenderer.sprite = coup13;
                    break;
                case 8:
                    spriteRenderer.sprite = coup12;
                    break;
                case 9:
                    spriteRenderer.sprite = coup11;
                    break;
                case 10:
                    spriteRenderer.sprite = coup0;
                    break;
                case 11:
                    spriteRenderer.sprite = coup1;
                    break;
                case 12:
                    spriteRenderer.sprite = coup2;
                    break;
                case 13:
                    spriteRenderer.sprite = coup3;
                    break;
                case 14:
                    spriteRenderer.sprite = coup4;
                    break;
                case 15:
                    spriteRenderer.sprite = coup5;
                    break;
                case 16:
                    spriteRenderer.sprite = coup6;
                    break;
                case 17:
                    spriteRenderer.sprite = coup7;
                    break;
                case 18:
                    spriteRenderer.sprite = coup8;
                    break;
                case 19:
                    spriteRenderer.sprite = coup9;
                    break;
                case 20:
                    spriteRenderer.sprite = coup10;
                    break;
            }
        }
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
            if (tours[2].Count == 4) // victoire
            {
                SceneManager.LoadScene("BombeACAA");
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
                            SceneManager.LoadScene("BoomACAB");
                        }
                    }
                }
            }
        }
    }
}
