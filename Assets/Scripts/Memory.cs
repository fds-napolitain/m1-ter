using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{

    Sprite carte;
    Sprite carte_dos;

    public int cp = 0;

    public string carte_prec;

    public string carte_Name;

    public int erreur = 2; //maximum 2

    private bool isUpsideDown = false;

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        carte_dos = spriteRenderer.sprite;

    }

    public string cardName
    {
        get
        {
            return card_Name;
        }
        set
        {
            card_Name = value;
        }
    }


    private void OnMouseDown() //This function is called each time player clicks on GameObject
    {
        if (!isUpsideDown && cp < erreur)
        {
            ChangeSide();
            cp ++;
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
