using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hanoi : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private static int errors = 0;
    private static int cp = 0;
    private static List<SpriteRenderer> list_sprite = new List<SpriteRenderer>(); //pour un emplacement on a une liste de sprite
    private static List<Hanoi> list_Hanoi = new List<Hanoi>(); //contient chaque emplacement ou ya la liste de sprite


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
