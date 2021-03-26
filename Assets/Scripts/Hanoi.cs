using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hanoi : MonoBehaviour
{
    private static int cp = 0;
    private static int CP_MAX = 10;
    private static bool flag = false;
    private static List<Stack<int>> tours = new List<Stack<int>>();
    private static Hanoi pointeurFil;
    private int indice; // indice (par rapport aux tours)
    private int value; // valeurs du fil
    private float[] coords = { 0f, 0f }; // coordonées a bouger
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (!flag)
        {
            tours.Add(new Stack<int>());
            tours.Add(new Stack<int>());
            tours.Add(new Stack<int>());
            flag = true;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    // Update is called once per frame
    void Update()
    {
        if (pointeurFil != null)
        {
            // move x
            if (pointeurFil.coords[0] > 0.1 || pointeurFil.coords[0] < -0.1)
            {
                Debug.Log(pointeurFil.coords[0]);
                Vector2 value = pointeurFil.coords[0] * Vector2.right * Time.deltaTime;
                pointeurFil.transform.Translate(value, Space.Self);
                pointeurFil.coords[0] -= value[0];
            }
            else
            {
                if (pointeurFil.coords[0] != 0)
                {
                    pointeurFil.GetComponent<Rigidbody2D>().gravityScale = 1f;
                    pointeurFil.coords[0] = 0;
                } 
            }
            // move y
            if (pointeurFil.coords[1] > 0)
            {
                Vector2 value = pointeurFil.coords[1] * Vector2.up * Time.deltaTime;
                pointeurFil.transform.Translate(value, Space.Self);
                pointeurFil.coords[1] -= value[1];
            }
            else
            {
                pointeurFil.coords[1] = 0f;
            }
        }
    }

    private void OnMouseDown()
    {
        if (name.StartsWith("fil"))
        {
            Debug.Log(tours[indice].Peek() + " " + value);
            if (tours[indice].Peek() == value)
            {
                if (pointeurFil != null && pointeurFil != this) // ancien pointeur
                {
                    pointeurFil.GetComponent<Rigidbody2D>().gravityScale = 1f;
                }
                if (pointeurFil != this) // nouveau pointeur
                {
                    GetComponent<Rigidbody2D>().gravityScale = 0f;
                    coords[1] += 6f;
                    Debug.Log("Sélection fil: " + indice);
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
                    cp++;
                    if (tours[2].Count == 3) // victoire
                    {
                        SceneManager.LoadScene("Corridor_AA");
                    }
                    if (CP_MAX == cp) // défaite
                    {
                        SceneManager.LoadScene("Hangar_AB");
                    }
                }
            }
        }
    }
}
