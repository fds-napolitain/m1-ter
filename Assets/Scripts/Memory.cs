using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Memory : MonoBehaviour
{
    private enum CardID
    {
        SUN,
        ASTEROID,
        BANANA,
        SATELLITE,
        MOON,
        ALIENSHIP,
    }

    // game variables
    private static string carte_prec;
    private static int errors = 0;
    private static int nbCarte = 0;
    private static int ERRORS_MAX = 2; //maximum 2
    private static List<CardID> spritesName = new List<CardID>(); 
    // card variables
    private Sprite carte;
    private Sprite carte_dos;
    private SpriteRenderer spriteRenderer;
    private bool isFacingCard = false;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        carte_dos = spriteRenderer.sprite;
        spritesName.Add(CardID.SUN);
        spritesName.Add(CardID.SUN);
        spritesName.Add(CardID.ASTEROID);
        spritesName.Add(CardID.ASTEROID);
        spritesName.Add(CardID.BANANA);
        spritesName.Add(CardID.BANANA);
        spritesName.Add(CardID.SATELLITE);
        spritesName.Add(CardID.SATELLITE);
        spritesName.Add(CardID.MOON);
        spritesName.Add(CardID.MOON);
        spritesName.Add(CardID.ALIENSHIP);
        spritesName.Add(CardID.ALIENSHIP);
        spritesName = spritesName.OrderBy(card => Guid.NewGuid()).ToList(); // aleatoire
        Debug.Log(this.name);
    }

    private void OnMouseDown() //This function is called each time player clicks on GameObject
    {
        if (!isFacingCard) {
            switch (name) {
                case "card1":
                    spriteRenderer.sprite = sprites
                    break;
                case "card2":
                    break;
                case "card3":
                    break;
                case "card4":
                    break;
                case "card5":
                    break;
                case "card6":
                    break;
                case "card7":
                    break;
                case "card8":
                    break;
                case "card9":
                    break;
                case "card10":
                    break;
                case "card11":
                    break;
                case "card12":
                    break;
            }
        } else {

        }
    }

    void ChangeSide()
    {
        
    }
}
