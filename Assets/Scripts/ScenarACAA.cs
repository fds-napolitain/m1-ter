using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenarACAA : MonoBehaviour
{

    public Text scenarioText;
    public Text questionText;
    public Text reponse1Text;
    public Text reponse2Text;

    public List<string> scenario = new List<string>();
    public List<string> scenario1 = new List<string>();
    public List<string> scenario2 = new List<string>();
    public string question;
    public string reponse1;
    public string reponse2;
    public int i = 0;
    public int branche = 0;

    private void Start()
    {
        
        scenarioText.text = scenario[i];
        i++;

        


        questionText.text = "";
        reponse1Text.text = "";
        reponse2Text.text = "";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            if (i == scenario.Count - 1 && branche == 0)
            {
                scenarioText.text = "";
                questionText.text = scenario[i];
                reponse1Text.text = "Fil rouge";
                reponse2Text.text = "Fil bleu";
            }
            else
            {
                if (i != scenario.Count)
                {
                    scenarioText.text = scenario[i];
                    i++;
                }
                else
                {
                    if (branche == 1)
                    {
                        SceneManager.LoadScene("Fin12");
                    }
                    else
                    {
                        SceneManager.LoadScene("Collect3");
                    }
                }
                Debug.Log("Clic.");
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (reponse1Text.text.Length != 0)
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.gameObject.name == "Reponse1")
                    {
                        scenario = scenario1;
                        branche = 1;
                        questionText.text = "";
                        reponse1Text.text = "";
                        reponse2Text.text = "";
                        i = 0;
                        scenarioText.text = scenario[i];
                        i++;
                    }
                    else if (hit.collider.gameObject.name == "Reponse2")
                    {
                        scenario = scenario2;
                        branche = 2;
                        questionText.text = "";
                        reponse1Text.text = "";
                        reponse2Text.text = "";
                        i = 0;
                        scenarioText.text = scenario[i];
                        i++;
                    }
                    i = 0;
                }
            }
        }
    }
}




