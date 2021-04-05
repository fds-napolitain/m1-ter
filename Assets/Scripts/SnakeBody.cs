using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    protected const float SNAKE_SPEED = 3f;
    protected SnakeBody next = null;
    protected SnakeBody previous = null;
    protected int i;
}
