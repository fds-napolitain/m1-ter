using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakeBody
{
    // [(nextPosition), Head, Body1, Body2, ..., (oldPosition)]
    private static LinkedList<float[]> snakePosition = new LinkedList<float[]>();

    /// <summary>
    /// Inputs de rotation pour la tête.
    /// </summary>
    private void Update()
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
        MoveSnake();
    }

    /// <summary>
    /// Change la direction de SnakeHead.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    private void ChangeDirections(float x, float y)
    {
        snakePosition.AddFirst(new float[] { x, y });
    }

    /// <summary>
    /// Bouge snake (1 frame).
    /// </summary>
    private void MoveSnake()
    {
        SnakeBody body = this;
        while (body != null)
        {
            // rotation
            float rotation = Math.Max(
                Math.Abs(snakePosition.First.Next.Value[0] - snakePosition.First.Value[0]),
                Math.Abs(snakePosition.First.Next.Value[1] - snakePosition.First.Value[1])
            );
            transform.Rotate(0, 0, rotation * 90, Space.Self);
            // translation
            transform.Translate(new Vector2(
                snakePosition.First.Value[0] * SNAKE_SPEED * Time.deltaTime,
                snakePosition.First.Value[0] * SNAKE_SPEED * Time.deltaTime
            ));
        }
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
