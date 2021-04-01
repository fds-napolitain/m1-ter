using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakeBody
{
    /// <summary>
    /// Inputs de rotation pour la tête.
    /// </summary>
    void Update()
    {
        // inputs
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Snake move right.");
            snakeDirection[0] = 1;
            snakeDirection[1] = 0;
        }      
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Snake move left.");
            snakeDirection[0] = -1;
            snakeDirection[1] = 0;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Snake move down.");
            snakeDirection[0] = 0;
            snakeDirection[1] = -1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Snake move up.");
            snakeDirection[0] = 0;
            snakeDirection[1] = 1;
        }

        // transformations de mouvements
        SnakeBody body = this;
        do
        {
            // translations
            body.transform.Translate(new Vector2(
                body.snakeDirection[0] * SNAKE_SPEED * Time.deltaTime,
                body.snakeDirection[1] * SNAKE_SPEED * Time.deltaTime
            ));
            // rotations
            if (body.previous != null)
            {

            }
            body = body.next;
        } while (body != null);
    }

    /// <summary>
    /// Collision entre snake et les autres objets
    /// TODO: améliorer la détection en suivant les bonnes pratiques
    /// https://gamedev.stackexchange.com/questions/154901/dynamic-vs-kinematic-do-either-of-these-cause-a-collision-before-oncollisionent
    /// (difference entre statique, dynamique et kinématique)
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (name.StartsWith("snake"))
        {
            if (collision.gameObject.name.StartsWith("mur"))
            {
                Debug.Log("Snake se prend un mur !");
                snakeDirection[0] = 0;
                snakeDirection[1] = 0;
            }
            else if (collision.gameObject.name.StartsWith("pomme"))
            {
                Debug.Log("Snake mange une pomme et grandit !");
                SnakeBody body = this;
                while (body.next != null)
                {
                    body = body.next;
                }
                body.next = new SnakeBody();
            }
            else // TODO: à verifier la condition pour que snake collide avec snake
            {
                Debug.Log("Snake se mord la queue !");
            }
        }
    }
}
