using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private static float SNAKE_SPEED = 0.2f;
    private static float[] snakeDirection = { 0, 0 }; // x y

    /// <summary>
    /// Fonction d'initialisation avant la première frame
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Update à chaque frame
    /// </summary>
    void Update()
    {
        // inputs
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            snakeDirection[0] = 1;
            snakeDirection[1] = 0;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            snakeDirection[0] = -1;
            snakeDirection[1] = 0;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            snakeDirection[0] = 0;
            snakeDirection[1] = 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            snakeDirection[0] = 0;
            snakeDirection[1] = -1;
        }

        // mouvement direction * vitesse
        transform.Translate(new Vector2(snakeDirection[0] * SNAKE_SPEED, snakeDirection[1] * SNAKE_SPEED));
    }

    /// <summary>
    /// Collision entre snake et les autres objets
    /// TODO: améliorer la détection en suivant les bonnes pratiques https://gamedev.stackexchange.com/questions/154901/dynamic-vs-kinematic-do-either-of-these-cause-a-collision-before-oncollisionent
    ///       difference entre statique, dynamique et kinématique
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (name.StartsWith("snake"))
        {
            if (collision.gameObject.name.StartsWith("mur"))
            {
                Debug.Log("Snake rencontre un mur !");
            }
            else if (collision.gameObject.name.StartsWith("pomme"))
            {
                Debug.Log("Snake rencontre une pomme !");
            }
            else // TODO: à verifier la condition pour que snake collide avec snake
            {
                Debug.Log("Snake se mord la queue !");
            }
        }
    }
}
