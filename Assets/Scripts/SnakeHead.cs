using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Point d'entrée et tête du snake + logique.
/// </summary>
public class SnakeHead : MonoBehaviour
{
    // [Head, Body1, Body2, ...]
    private static LinkedList<Direction> snakePosition = new LinkedList<Direction>();
    public Sprite snakehead, snakebody;
    public GameObject pomme;
    protected const float SNAKE_SPEED = 0.25f;



    private static List<SnakeHead> snakes = new List<SnakeHead>();
    public List<GameObject> pommes;
    private float x;
    private float y;
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
        next.transform.position += p;
        next.transform.Rotate(0, 0, r);
        next.transform.localScale *= 0.2f;
        snakes.Add(next);

    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (name =="snake_head")
        {
            snakes.Add(this);
            direction = Direction.RIGHT;
            precDirection = Direction.RIGHT;
            hasChangedDirection = false;
            
            Move();
        }
    }

    private void Move()
    {
        for ( int index = 0; index < snakes.Count; index ++ )
        {
            SnakeHead body = snakes[index];
            Debug.Log("body " + body);
            Boolean test = false;
            if (hasChangedDirection)
            {
                int r = -1 ;
                /**
                 * a finir !!
                 * */
                Debug.Log("nombre " + Enum.ToObject(body.direction.GetType(), body.direction));
                if (body.direction - body.precDirection == 1|| body.direction - body.precDirection == -3)
                {
                    Debug.Log("blabla");
                    r = -90;
                }
                if (body.direction == Direction.DOWN)
                {

                }
                else
                {
                    r = 90;
                }
                body.transform.Rotate(0, 0, r);
                hasChangedDirection = false;
                precDirection = direction;
                test = true;
            }
            x = 0;
            y = 0;
            // translation
            switch (body.direction)
            {
                case Direction.LEFT:
                    x = -1;
                    break;
                case Direction.UP:
                    y = 1;
                    break;
                case Direction.DOWN:
                    y = -1;
                    break;
                case Direction.RIGHT:
                    x = 1;
                    break;
            }
            body.transform.position += new Vector3(
                x * SNAKE_SPEED * Time.deltaTime,
                y * SNAKE_SPEED * Time.deltaTime,
                0
            );
           // Move(index++);
            if(index < snakes.Count - 1 && test)
            {
                snakes[index].hasChangedDirection = true;
                snakes[index].direction = snakes[index - 1].direction;
            }
        }
    }

    private void Update()
    {
        Move();
    }

    private void OnMouseDown()
    {
        
            switch (this.name)
            {
                case "Button up":
                    snakes[0].direction = Direction.UP;
             
                    break;
                case "Button down":
                    snakes[0].direction = Direction.DOWN;
                    break;
                case "Button left":
                    snakes[0].direction = Direction.LEFT;
                    break;
                case "Button right":
                    snakes[0].direction = Direction.RIGHT;
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
                Debug.Log("Snake mange une pomme et grandit !");
                // queue
                Vector3 p = new Vector3(0, 0, 0);
                p += this.transform.position;
                int r = 0;
                switch (precDirection)
                {
                    case Direction.LEFT:
                        p.x += this.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 0.2f;
                        break;
                    case Direction.UP:
                        p.y -= this.GetComponent<SpriteRenderer>().sprite.bounds.size.y * 0.2f;
                        r = 90;
                        break;
                    case Direction.RIGHT:
                        p.x -= this.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 0.2f;
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
                System.Random ra = new System.Random();
                pomme.transform.position += new Vector3(
                    (float)ra.NextDouble() * 8 - 4, // -4 => 4
                    (float)ra.NextDouble() * 8 - 4,
                    0
                );
            }
            else // TODO: à verifier la condition pour que snake collide avec snake
            {
                Debug.Log("Snake se mord la queue !");
            }
        }
    }
        /*
        /// <summary>
        /// Démarrage du mini jeu.
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
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) ChangeDirections(Direction.LEFT);
            else if (Input.GetKeyDown(KeyCode.DownArrow)) ChangeDirections(Direction.DOWN);
            else if (Input.GetKeyDown(KeyCode.UpArrow)) ChangeDirections(Direction.UP);
            else ChangeDirections(snakePosition.First.Value);
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
        /// Indique par un booléen si snake a rotate.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private bool HasChangedDirection(LinkedListNode<Direction> direction)
        {
            if (direction.Next != null && (Math.Abs(direction.Next.Value - direction.Value) % 2 != 0 || direction.Next.Value == Direction.STOP))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retourne l'angle de rotation pour changer de direction.
        /// Appelé si HasChangedDirection est vrai.
        /// Direction.STOP => 0
        /// 1 ou -3 => va a gauche (-90)
        /// -1 ou 3 => va a droite (90)
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private float RotateBy(LinkedListNode<Direction> direction)
        {
            if (direction.Next.Value == Direction.STOP) {
                return 0;
            }
            else if (direction.Value - direction.Next.Value == 1 || direction.Value - direction.Next.Value == -3)
            {
                return -90;
            }
            else
            {
                return 90;
            }
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
                    body.transform.Rotate(0, 0, RotateBy(direction));
                }
                // translation
                float x = 0;
                float y = 0;
                switch (direction.Value)
                {
                    case Direction.LEFT:
                        x = -1;
                        break;
                    case Direction.UP:
                        y = 1;
                        break;
                    case Direction.DOWN:
                        y = -1;
                        break;
                    case Direction.RIGHT:
                        x = 1;
                        break;
                }
                body.transform.position += new Vector3(
                    x * SNAKE_SPEED * Time.deltaTime,
                    y * SNAKE_SPEED * Time.deltaTime,
                    0
                );
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
        /// Append body to last body
        /// </summary>
        private void SpawnSnakeBody()
        {
            SnakeBody b = this;
            while (b.next != null)
            {
                b = next;
            }
            Vector3 p = new Vector3(0, 0, 0);
            p += b.transform.position;
            int r = 0;
            switch (snakePosition.Last.Value)
            {
                case Direction.LEFT:
                    p.x += b.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 0.2f;
                    break;
                case Direction.UP:
                    p.y -= b.GetComponent<SpriteRenderer>().sprite.bounds.size.y * 0.2f;
                    r = 90;
                    break;
                case Direction.RIGHT:
                    p.x -= b.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 0.2f;
                    r = 180;
                    break;
                case Direction.DOWN:
                    p.y += b.GetComponent<SpriteRenderer>().sprite.bounds.size.y * 0.2f;
                    r = -90;
                    break;
                case Direction.STOP:
                    break;
                default:
                    break;
            }
            GameObject body = new GameObject("body", typeof(SnakeBody), typeof(BoxCollider2D));
            SpriteRenderer renderer = body.AddComponent<SpriteRenderer>();
            renderer.sprite = snakebody;
            next = body.GetComponent<SnakeBody>();
            next.transform.position += p;
            next.transform.Rotate(0, 0, r);
            next.transform.localScale *= 0.2f;
            snakePosition.AddLast(snakePosition.Last.Value);
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
                    // queue
                    SpawnSnakeBody();
                    // pomme
                    System.Random r = new System.Random();
                    pomme.transform.position += new Vector3(
                        (float)r.NextDouble() * 8 - 4, // -4 => 4
                        (float)r.NextDouble() * 8 - 4,
                        0
                    );
                }
                else // TODO: à verifier la condition pour que snake collide avec snake
                {
                    Debug.Log("Snake se mord la queue !");
                    ChangeDirections(Direction.STOP);
                }
            }
        }

        */
    }
