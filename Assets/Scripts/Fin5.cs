using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fin5 : MonoBehaviour
{
    public Text finText;


    public string fin;

    void Start()
    {
        fin = "Vous croyez sérieusement avoir une chance ? Au moins, vous êtes mort en jouant les héros. Si Sekip s’en sort, et qu’il n’est pas traumatisé à vie, il pourra raconter à tout le monde votre acte héroïque inutile.";
        finText.text = fin;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            SceneManager.LoadScene("Intro");
        }
    }
}