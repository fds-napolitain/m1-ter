using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Simon : MonoBehaviour
{

    private static List<int> ordre = new List<int>();
    private static List<Simon> listSprite = new List<Simon>();
    private static List<string> ordreBouton = new List<string>();
    private static int cp = 0;
    private static int nbreCouleur = 4;
    private static bool flag = false;
    private static bool flag2 = false;
    
    private static int n = 0;
    public Sprite couleur, black, error;
    public SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!flag)
        {

            flag = true;
            n = 0;
        }
        listSprite.Add(this);
        n++;
        if (n == 10)
        {
            System.Random aleatoire = new System.Random();
            for (int i = 0; i < 6; i++)
            {
                ordre.Add(aleatoire.Next(1, 11));
                Debug.Log(ordre[i] + "=" + listSprite[ordre[i]-1].name);
                ordreBouton.Add(listSprite[ordre[ordre.Count - 1] - 1].name);
            }
            StartCoroutine(AfficheOrdre(4));
        }
    }

    private IEnumerator AfficheOrdre(int n)
    {
        flag2 = true;
        yield return new WaitForSeconds(1);
        //dans une boucle remplacer les sprites correspondant par un sprite couleur puis les remettre noirs
        for (int i = 0; i < n; i++)
        {
            listSprite[ordre[i]-1].spriteRenderer.sprite = couleur;
            yield return new WaitForSeconds(1);
            listSprite[ordre[i]-1].spriteRenderer.sprite = black;
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(1);
        flag2 = false;
    }

    private IEnumerator AfficheCouleur()
    {
        spriteRenderer.sprite = couleur;
        yield return new WaitForSeconds(1);
        spriteRenderer.sprite = black;
    }

    private IEnumerator AfficheErreur()
    {
        spriteRenderer.sprite = error;
        yield return new WaitForSeconds(1);
        spriteRenderer.sprite = black;
    }

    /// <summary>
    ///  Appelé sur chaque gameobject avec le script ET boxcollider
    /// </summary>
    private void OnMouseDown() 
    {
        Debug.Log(name + " " + ordreBouton[cp]);
        if (!flag2)
        {
            if (ordreBouton[cp] == name) // c'est bon
            {
                StartCoroutine(AfficheCouleur());
                cp++;
                if (cp == nbreCouleur) // victoire partielle
                {
                    if (nbreCouleur == 6) // victoire
                    {
                        SceneManager.LoadScene("Repos_AAA");
                    }
                    nbreCouleur++;
                    cp = 0;
                    StartCoroutine(AfficheOrdre(nbreCouleur));
                }
            }
            else // erreur
            {
                StartCoroutine(AfficheErreur());
                SceneManager.LoadScene("CouloirAAB");
            }
        }
    }

    private void Update()
    {
        // a faire avec time.time
    }
}

