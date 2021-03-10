using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{

    Sprite carte;
    Sprite carte_dos;

    public static string carte_prec;

    private int cp = 0;

    private int nbCarte = 0;

    public string carte_Name;

    private int erreur = 2; //maximum 2

    private bool isUpsideDown = false;

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        carte_dos = spriteRenderer.sprite;

    }

    public string Carte_Name
    {
        get
        {
            return carte_Name;
        }
        set
        {
            carte_Name = value;
        }
    }


    private void OnMouseDown() //This function is called each time player clicks on GameObject
    {
        if (!isUpsideDown && cp < erreur)
        {
            ChangeSide();
            nbCarte++;
            if(nbCarte == 2)
            {
                if(carte.Carte_Name == carte_prec)
                {
                    cp++;
                    //retourner les cartes
                }
                nbCarte = 0;
            }
            if(nbCarte == 1)
            {
                carte_prec = carte.Carte_Name;
            }
        }
    }

    void ChangeSide()
    {
        if (!isUpsideDown)
        {
            spriteRenderer.sprite = carte;
            isUpsideDown = true;
        }
        else
        {
            spriteRenderer.sprite =carte_dos;
            isUpsideDown = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
