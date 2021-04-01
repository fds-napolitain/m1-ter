using System;
using UnityEngine;

public class SnakeHead : SnakeBody
{
    private float[] oldHeadDirection = new float[] { 0, 0 };

    /// <summary>
    /// Inputs de rotation pour la tête.
    /// </summary>
    void Update()
    {
        // inputs 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Snake bouge vers la droite.");
            ChangeDirections(1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Snake bouge vers la gauche.");
            ChangeDirections(-1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Snake bouge vers le bas.");
            ChangeDirections(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Snake bouge vers le haut.");
            ChangeDirections(0, 1);
        }

        MoveHead();
        MoveBody();
    }

    /// <summary>
    /// Change la direction de SnakeHead.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    private void ChangeDirections(float x, float y)
    {
        oldHeadDirection[0] = snakeDirection[0];
        oldHeadDirection[1] = snakeDirection[1];
        snakeDirection[0] = x;
        snakeDirection[1] = y;
    }

    /// <summary>
    /// Bouge la SnakeHead.
    /// </summary>
    private void MoveHead()
    {
        // rotations
        float rotation = Math.Max(
            Math.Abs(oldHeadDirection[0] - snakeDirection[0]),
            Math.Abs(oldHeadDirection[1] - snakeDirection[1])
        );
        // translations
        transform.Rotate(0, 0, rotation * 90, Space.Self);
        transform.Translate(new Vector2(
            snakeDirection[0] * SNAKE_SPEED * Time.deltaTime,
            snakeDirection[1] * SNAKE_SPEED * Time.deltaTime
        ));
    }

    /// <summary>
    /// Bouge tous les SnakeBody.
    /// </summary>
    private void MoveBody()
    {
        SnakeBody body = this.next;
        while (body != null)
        {
            // rotations
            if (body.previous != null)
            {
                if (body.previous is SnakeHead)
                {

                }
                else
                {

                }
            }
            // translations
            body.transform.Translate(new Vector2(
                body.snakeDirection[0] * SNAKE_SPEED * Time.deltaTime,
                body.snakeDirection[1] * SNAKE_SPEED * Time.deltaTime
            ));
            body = body.next;
        } ;
    }

    /// <summary>
    /// Collision entre SnakeHead et les autres objets
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
            }
            else // TODO: à verifier la condition pour que snake collide avec snake
            {
                Debug.Log("Snake se mord la queue !");
            }
        }
    }
}
