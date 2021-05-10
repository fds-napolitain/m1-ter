using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

/// <summary>
/// Point d'entrée et tête du snake + logique.
/// </summary>
public class SnakeHead : MonoBehaviour
{
    // [Head, Body1, Body2, ...]
    private static LinkedList<Direction> snakePosition = new LinkedList<Direction>();
    public Sprite snakehead, snakebody;
    public GameObject pomme;
    protected const float SNAKE_SPEED = 0.01f;



    private static List<SnakeHead> snakes = new List<SnakeHead>();
    //public List<GameObject> pommes;
    private double x;
    private double y;
    public static int MAX_X = 8;
    public static int MAX_Y = 8;
    public Direction direction;
    public Direction precDirection;
    public Boolean hasChangedDirection;
    SpriteRenderer spriteRenderer;
    GameObject boutton_up;
    GameObject boutton_down;
    GameObject boutton_right;
    GameObject boutton_left;
    public static int maxPommes = 10;
    public static int nbPommes;
    public static int index;

    public enum Direction
    {
        LEFT,
        UP,
        RIGHT,
        DOWN,
    }

    private void addBodySnake(Vector3 p, int r)
    {
        GameObject body = new GameObject("body", typeof(SnakeHead), typeof(BoxCollider2D));
        SpriteRenderer renderer = body.AddComponent<SpriteRenderer>();
        renderer.sprite = snakebody;
        SnakeHead next = body.GetComponent<SnakeHead>();
        next.transform.Rotate(0, 0, r);
        next.transform.position += p;
        next.transform.localScale *= 0.2f;
        next.direction = snakes[snakes.Count - 1].direction;
        snakes.Add(next);

    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (name == "snake_head")
        {
            snakes.Add(this);
            direction = Direction.RIGHT;
            precDirection = Direction.RIGHT;
            hasChangedDirection = false;
            index = 0;

            Move();
            Thread.Sleep(5);
        }
    }

    private void Move()
    {
        Boolean test;
        for (index = 0; index < snakes.Count; index++)
        {
            SnakeHead body = snakes[index];
            //Debug.Log("body " + body);
            test = false;
            x = 0.0;
            y = 0.0;
            if (hasChangedDirection)
            {
                test = true;
                Debug.Log("Index : " + index + " ->" + body.direction + " ;;;;;; " + body.precDirection);
                int r = 0;
                if (body.precDirection == Direction.RIGHT && body.direction == Direction.UP)
                {
                    r = 90;
                    x += 0.5;
                }
                if (body.precDirection == Direction.RIGHT && body.direction == Direction.DOWN)
                {
                    r = -90;
                    x += 0.5;
                }
                if (body.precDirection == Direction.UP && body.direction == Direction.RIGHT)
                {
                    r = -90;
                    y += 0.5;
                }
                if (body.precDirection == Direction.UP && body.direction == Direction.LEFT)
                {
                    r = 90;
                    y += 0.5;
                }
                if (body.precDirection == Direction.LEFT && body.direction == Direction.UP)
                {
                    r = -90;
                    x -= 0.5;
                }
                if (body.precDirection == Direction.LEFT && body.direction == Direction.DOWN)
                {
                    r = 90;
                    x -= 0.5;
                }
                if (body.precDirection == Direction.DOWN && body.direction == Direction.RIGHT)
                {
                    r = 90;
                    y -= 0.5;
                }
                if (body.precDirection == Direction.DOWN && body.direction == Direction.LEFT)
                {
                    r = -90;
                    y -= 0.5;
                }
                body.transform.Rotate(0, 0, r);
                body.hasChangedDirection = false;
                body.precDirection = body.direction;

            }
            // translation
            switch (body.direction)
            {
                case Direction.LEFT:
                    x -= 1;
                    break;
                case Direction.UP:
                    y += 1;
                    break;
                case Direction.DOWN:
                    y -= 1;
                    break;
                case Direction.RIGHT:
                    x += 1;
                    break;
            }
            body.transform.position += new Vector3(
               (float)x * SNAKE_SPEED,
               (float)y * SNAKE_SPEED,
               0
            );

            if (index != 0 && body.direction != snakes[index - 1].direction)
            {
                Debug.Log("index : " + index);
                Debug.Log("CHANGE DIRECTION SUIVANT");
                body.hasChangedDirection = true;
                body.precDirection = body.direction;
                body.direction = snakes[index - 1].direction;
                Debug.Log(body.direction + ", " + body.precDirection);
            }
        }
    }

    private void Update()
    {
        Thread.Sleep(5);
        Move();
        Thread.Sleep(5);
    }



    private void OnMouseDown()
    {

        switch (this.name)
        {
            case "Button up":
                if (snakes[0].direction != Direction.DOWN)
                    snakes[0].direction = Direction.UP;
                else
                {
                    SceneManager.LoadScene("Hangar_AB");
                }
                break;
            case "Button down":
                if (snakes[0].direction != Direction.UP)
                    snakes[0].direction = Direction.DOWN;
                else
                {
                    SceneManager.LoadScene("Hangar_AB");
                }
                break;
            case "Button left":
                if (snakes[0].direction != Direction.RIGHT)
                    snakes[0].direction = Direction.LEFT;
                else
                {
                    SceneManager.LoadScene("Hangar_AB");
                }
                break;
            case "Button right":
                if (snakes[0].direction != Direction.LEFT)
                    snakes[0].direction = Direction.RIGHT;
                else
                {
                    SceneManager.LoadScene("Hangar_AB");
                }
                break;
        }
        snakes[0].hasChangedDirection = true;
        Debug.Log("change direction");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (name.StartsWith("snake"))
        {
            if (collision.gameObject.name.StartsWith("mur"))
            {
                Debug.Log("Snake se prend un mur !");
                Debug.Log("Défaite");
                SceneManager.LoadScene("Hangar_AB");
            }
            else if (collision.gameObject.name.StartsWith("pomme"))
            {
                nbPommes++;
                if (nbPommes == maxPommes)
                {
                    Debug.Log("Victoire");
                    SceneManager.LoadScene("Corridor_AA");
                }

                Debug.Log("Snake mange une pomme et grandit !");
                // queue
                Vector3 p = new Vector3(0, 0, 0);
                p += this.transform.position;
                int r = 0;
                switch (snakes[snakes.Count - 1].direction)
                {
                    case Direction.RIGHT:
                        p.x -= this.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 0.2f;
                        break;
                    case Direction.UP:
                        p.y -= this.GetComponent<SpriteRenderer>().sprite.bounds.size.y * 0.2f;
                        r = 90;
                        break;
                    case Direction.LEFT:
                        p.x += this.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 0.2f;
                        r = 180;
                        break;
                    case Direction.DOWN:
                        p.y += this.GetComponent<SpriteRenderer>().sprite.bounds.size.y * 0.2f;
                        r = -90;
                        break;
                    default:
                        break;
                }
                addBodySnake(p, r);
                // pomme
                pomme.transform.position = new Vector3(
                    UnityEngine.Random.Range(-3.25f, 3.25f), // -4 => 4
                    UnityEngine.Random.Range(-3.25f, 3.25f),
                    0
                );
            }
            else // TODO: à verifier la condition pour que snake collide avec snake
            {
                Debug.Log("Snake se mord la queue !");
            }
        }
    }

}
