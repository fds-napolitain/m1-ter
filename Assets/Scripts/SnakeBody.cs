using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    protected const float SNAKE_SPEED = 3f;
    public float[] snakeDirection = { 0, 0 }; // x y: -1 recule, 1 avance, 0 ne bouge pas sur l'axe
    public SnakeBody next = null;
    public SnakeBody previous = null;
}
