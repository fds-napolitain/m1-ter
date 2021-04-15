using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{

    public Text scenarioText;

    // Start is called before the first frame update
    void Start()
    {

        scenarioText.text = "blabla ";
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
        {

            scenarioText.text += "next blabla ";
        }

    }
}
