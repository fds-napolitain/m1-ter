using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SampleScene : MonoBehaviour
{
    public Text scenarioText;
    public Text questionText;
    public Text reponse1Text;
    public Text reponse2Text;
    public Text reponse3Text;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (reponse1Text.text.Length != 0)
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                    if (hit.collider.gameObject.name == "Reponse1")
                    {
                        Debug.Log("Réponse 1 cliqué.");
                    }
                    else if (hit.collider.gameObject.name == "Reponse2")
                    {
                        Debug.Log("Réponse 2 cliqué.");
                    }
                    else if (hit.collider.gameObject.name == "Reponse3")
                    {
                        Debug.Log("Réponse 3 cliqué.");
                    }
                }
            }
            Debug.Log("Clic.");
        }
    }

}
