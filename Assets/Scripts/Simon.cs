using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Simon : MonoBehaviour
{

    static List<int> ordre = new List<int>();

    static List<Simon> list_sprite = new List<Simon>();
    static List<string> ordreBouton = new List<string>();

    private static int cp = 0;
    private static int nbreCouleur = 4;
    private static bool flag = false;
    private SpriteRenderer spriteRenderer;
    int n;
    private Sprite couleur, black, error;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!flag)
        {
            System.Random aleatoire = new System.Random();
            for (int i = 0; i < 6; i++)
            {
                ordre.Add(aleatoire.Next(1, 10));
                ordreBouton.Add("bouton" + ordre[ordre.Count -1]);
            }
            flag = true;
            n = 0;
        }
        list_sprite.Add(this);
        n++;
        if (n == 9)
            AfficheOrdre(4);
    }

    

    // Update is called once per frame
    void Update()
    {

    }



    void AfficheOrdre(int n) { 
        //dans une boucle remplacer les sprites correspondant par un sprite couleur puis les remettre noirs
        for(int i = 0; i < n; i++)
        {
            list_sprite[ordre[i]].spriteRender.sprite = couleur;
            yield return new WaitForSeconds(1);
            list_sprite[ordre[i]].spriteRender.sprite = black;
            yield return null;
        }
    }


    private void OnMouseDown() //This function is called each time player clicks on GameObject
    {
        if (ordreBouton[cp] == name)
        {
            yield return new WaitForSeconds(1);
            spriteRenderer.sprite = couleur;
            cp++;
            yield return null;
            if (cp == nbreCouleur)
            {
                if(nbreCouleur == 6)
                {
                    SceneManager.LoadScene("Corridor_AA");
                }
                nbreCouleur++;
                cp = 0;
                AfficheOrdre(nbreCouleur);
            }
            spriteRenderer.sprite = black;
        }
        yield return new WaitForSeconds(1);
        spriteRenderer.sprite = error;
        yield return null;
        SceneManager.LoadScene("Hangar_AB");
    }

}

