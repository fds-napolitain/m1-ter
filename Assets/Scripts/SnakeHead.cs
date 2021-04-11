using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakeBody
{
    // [Head, Body1, Body2, ...]
    private static LinkedList<Direction> snakePosition = new LinkedList<Direction>();
    private enum Direction
    {
        LEFT,
        UP,
        RIGHT,
        DOWN,
        STOP,
    }

    /// <summary>
    /// Démarrage
    /// </summary>
    private void Start()
    {
        snakePosition.AddFirst(Direction.STOP);
    }

    /// <summary>
    /// Inputs de rotation pour la tête.
    /// </summary>
    private void Update()
    {
        // inputs 
        if (Input.GetKeyDown(KeyCode.RightArrow)) ChangeDirections(Direction.RIGHT);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) ChangeDirections(Direction.LEFT);
        if (Input.GetKeyDown(KeyCode.DownArrow)) ChangeDirections(Direction.DOWN);
        if (Input.GetKeyDown(KeyCode.UpArrow)) ChangeDirections(Direction.UP);
        DebugSnakePosition();
        MoveSnake();
        if (HasChangedDirection(snakePosition.First))
        {
            snakePosition.RemoveLast();
        }
    }

    /// <summary>
    /// Change la direction de SnakeHead.
    /// </summary>
    /// <param name="direction"></param>
    private void ChangeDirections(Direction direction)
    {
        if (snakePosition.First.Value == Direction.STOP || CanChangeDirection(direction)) {
            snakePosition.AddFirst(direction);
            Debug.Log("Snake move to " + direction.ToString());
        }
        Debug.Log("Snake can't move to " + direction.ToString());
    }

    /// <summary>
    /// Indique si SnakeHead peut rotate.
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    private bool CanChangeDirection(Direction direction)
    {
        return Math.Abs(snakePosition.First.Value - direction) % 2 != 0;
    }

    /// <summary>
    /// Indique par un booléan si snake a rotate.
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    private bool HasChangedDirection(LinkedListNode<Direction> direction)
    {
        if (direction.Next != null && Math.Abs(direction.Next.Value - direction.Value) % 2 != 0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Retourne l'angle de rotation pour changer de direction.
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    private float RotateBy(LinkedListNode<Direction> direction)
    {
        if (direction.Value - direction.Next.Value == 1)
        {
            return 90;
        }
        return -90;
    }

    /// <summary>
    /// Bouge snake (1 frame).
    /// </summary>
    private void MoveSnake()
    {
        SnakeBody body = this;
        LinkedListNode<Direction> direction = snakePosition.First;
        while (body != null)
        {
            // rotation
            if (HasChangedDirection(direction))
            {
                transform.Rotate(0, 0, RotateBy(direction), Space.Self);
            }
            // translation
            float x = 0;
            switch (direction.Value)
            {
                case Direction.LEFT:
                case Direction.UP:
                    x = -1;
                    break;
                case Direction.DOWN:
                case Direction.RIGHT:
                    x = 1;
                    break;
            }
            transform.Translate(new Vector2(
                x * SNAKE_SPEED * Time.deltaTime,
                0
            ));
            // next
            body = next;
            direction = direction.Next;
        }
    }

    /// <summary>
    /// Affiche l'état du snake.
    /// </summary>
    private void DebugSnakePosition()
    {
        LinkedListNode<Direction> snakePos = snakePosition.First;
        string snake = "";
        while (snakePos != null)
        {
            snake += snakePos.Value + " ";
            snakePos = snakePos.Next;
        }
        Debug.Log(snake);
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
                ChangeDirections(Direction.STOP);
            }
            else if (collision.gameObject.name.StartsWith("pomme"))
            {
                Debug.Log("Snake mange une pomme et grandit !");
                snakePosition.AddLast(snakePosition.First.Value);
            }
            else // TODO: à verifier la condition pour que snake collide avec snake
            {
                Debug.Log("Snake se mord la queue !");
                ChangeDirections(Direction.STOP);
            }
        }
    }
}
