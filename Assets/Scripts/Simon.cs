using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon : MonoBehaviour
{

    static List<int> ordre = new List<int>();

    static List<Sprite> list_sprite = new List<Sprite>();
    static List<string> ordreBouton = new List<string>();

    private static int cp = 0;
    private static int nbreCouleur = 4;
    private static bool flag = false;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!flag)
        {
            Random aleatoire = new Random();
            for (int i = 0; i < 6; i++)
            {
                ordre.Add(aleatoire.Next(1, 10));
                ordreBouton.Add("bouton" + ordre[ordre.Count -1]);
            }
            flag = true;
            AfficheOrdre(nbreCouleur);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }



    void AfficheOrdre(int n) { 
        //dans une boucle remplacer les sprites correspondant par un sprite couleur puis les remettre noirs
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

    }
    yield return new WaitForSeconds(1);
    spriteRenderer.sprite = error;
    yield return null;
    SceneManager.LoadScene("Hangar_AB");
}
