using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        CARDBACK, // face arriere
    }

    // game variables
    private static int ERRORS_MAX = 5;
    private static List<CardID> carteTirees = new List<CardID>();
    private static int errors = 0;
    private static List<CardID> spritesName = new List<CardID>();
    // card variables
    public Sprite sun, asteroid, banana, satellite, moon, alien_ship_alt, card_back;
    public SpriteRenderer spriteRenderer;
    private bool isFacingCard = false;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
    }

    private void OnMouseDown() //This function is called each time player clicks on GameObject
    {
        if (!isFacingCard) {
            isFacingCard = true;
            switch (name) {
                case "card1":
                    ChangeSide(spritesName[0]);
                    break;
                case "card2":
                    ChangeSide(spritesName[1]);
                    break;
                case "card3":
                    ChangeSide(spritesName[2]);
                    break;
                case "card4":
                    ChangeSide(spritesName[3]);
                    break;
                case "card5":
                    ChangeSide(spritesName[4]);
                    break;
                case "card6":
                    ChangeSide(spritesName[5]);
                    break;
                case "card7":
                    ChangeSide(spritesName[6]);
                    break;
                case "card8":
                    ChangeSide(spritesName[7]);
                    break;
                case "card9":
                    ChangeSide(spritesName[8]);
                    break;
                case "card10":
                    ChangeSide(spritesName[9]);
                    break;
                case "card11":
                    ChangeSide(spritesName[10]);
                    break;
                case "card12":
                    ChangeSide(spritesName[11]);
                    break;
            }
        } else {
            isFacingCard = false;
            ChangeSide(CardID.CARDBACK);
        }
    }

    private void ChangeSide(CardID cardID)
    {
        carteTirees.Add(cardID);
        switch (cardID) {
            case CardID.SUN:
                spriteRenderer.sprite = sun;
                break;
            case CardID.ASTEROID:
                spriteRenderer.sprite = asteroid;
                break;
            case CardID.BANANA:
                spriteRenderer.sprite = banana;
                break;
            case CardID.SATELLITE:
                spriteRenderer.sprite = satellite;
                break;
            case CardID.MOON:
                spriteRenderer.sprite = moon;
                break;
            case CardID.ALIENSHIP:
                spriteRenderer.sprite = alien_ship_alt;
                break;
            case CardID.CARDBACK:
                spriteRenderer.sprite = card_back;
                break;
        }
        if (carteTirees.Count == 2) {
            if (carteTirees[0] == carteTirees[1]) {
                Debug.Log("Victoire");
                SceneManager.LoadScene("Ending");
            } else {
                errors++;
                if (errors == ERRORS_MAX) {
                    Debug.Log("Défaite");
                    SceneManager.LoadScene("Ending");
                }
            }
        }
    }
}
