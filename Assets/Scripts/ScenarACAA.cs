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
        scenario.Add("Une goutte de sueur coule sur votre front alors que vous ouvrez enfin délicatement ce boîtier. Le bip de l’engin s'accélère, devant vous deux fils. Un rouge et un bleu ! Vous devez choisir lequel couper.");
        scenario.Add("“Coupe le rouge” vous crie Sekip. “C’est toujours le rouge !”");
        scenario.Add("“Mais justement, c’est peut-être un piège” réplique Innoth.");
        scenario.Add("“Laissez-le choisir !” les coupe alors le Capitaine.");
        scenario.Add("Il se rapproche ensuite de vous et affirme :");
        scenario.Add("“Le choix te revient petit, je te fais confiance !”");
        scenario.Add("Il s’éloigne ensuite et ajoute :");
        scenario.Add("“Par contre, si tu nous tues, je ne te le pardonnerais jamais !”");
        scenarioText.text = scenario[i];
        i++;

        scenario1.Add("Vous choisissez de couper le fil rouge. Le bip se stoppe puis un gaz rouge à l’odeur étonnamment sucrée vous explose au visage, se répandant dans toute la pièce. Pris par surprise.");
        scenario1.Add("En quelques secondes le gaz se dissipe et vous reprenez votre souffle. Vous appelez les autres membres de l’équipage pour vérifier qu’ils vont bien et soupirez en réalisant que le gaz n’était visiblement pas mortel.");
        scenario1.Add("Vous avez un peu la tête qui tourne mais vous savez que vous devez rester concentrer, alors vous vous redressez.");
        scenario1.Add("Vous voyez alors un gigantesque ours en peluche vivant entrer dans la pièce et faire un énorme câlin à Innoth.");
        scenario1.Add("Vous clignez des yeux plusieurs fois cherchant à comprendre ce qu’il se passe, et vous entendez alors un deuxième ours entrer en chantonnant :");
        scenario1.Add("“Je veux des câlins, lins, lins, lins, lins, lins. Je veux plein de câlins, lins, lins, lins, lins, lins.”");
        scenario1.Add("Vous saviez que quelque chose est louche, mais vous ne pouvez vous empêcher de vouloir faire un câlin à ces ours en peluche géants.");
        scenario1.Add("Vous vous précipitez alors sur l’un d’eux et lui faites un énorme câlin. Il vous regarde, vous le regardez et faites un sourire béa stupide.");
        scenario1.Add("Ses deux énormes patounes vous attrapent alors le visage et vous rapprochent de sa bouche comme pour vous faire un énorme bisou.");
        scenario1.Add("Votre vision se trouble alors et vous avez juste le temps de réaliser que le gaz était hallucinogène et que ce n’était pas un doudou qui voulait vous faire un bisou, mais un alien qui voulait vous manger, avant que ledit alien croque dans votre tête.");

        scenario2.Add("Vous coupez le fil bleu en faisant une grimace effrayée et le silence se fait. Vous avez visiblement choisi le bon fil. Vous poussez alors un soupir de soulagement avant d’être ramené à la réalité par le capitaine.");
        scenario2.Add("“Nous devons nous armer ! L’alarme a probablement alerté tous les occupants du vaisseau et il ne devrait pas tarder à arriver, et nous ne savons toujours pas s’ils sont hostiles ou non.”");
        scenario2.Add("Vous hochez la tête en accord et vous précipitez vers les fameux pistolets à liquide noir qui vous intriguaient tant. Vous en attrapez un, attachez quelque chose ressemblant trait pour trait à un sabre laser à votre ceinture, puis vous équipez de ce qui semble être une arme plasmique dans votre seconde main.");
        scenario2.Add("Quelques instants plus tard, un alien vert géant avec des yeux de mouche et quatre bras squelettiques passe la porte et se jette sur vous. Alors, sans réfléchir, vous tirez avec le pistolet plasmique.");
        scenario2.Add("En un instant l’alien explose ne laissant qu’un millier de petits copeaux noirs.");
        scenario2.Add("“Wouhou ! C’était trop cool !” s’exclame le pilote.");
        scenario2.Add("Si ces aliens n’étaient pas vos ennemis avant, vous pouvez être sûr qu’ils le sont maintenant ! Vous n’avez donc plus le choix, vous devez vous battre.");
        scenario2.Add("Vous sortez alors de la pièce en formation et progressez un peu aléatoirement dans le vaisseau en tirant sur tous les ennemis que vous croisez. C’est affreux, mais vous commencez à y prendre goût.");
        scenario2.Add("Vous arrivez dans un couloir et entendez de nombreux bruits provenant de devant vous et derrière vous. Vous décidez donc d’ouvrir la porte au milieu.");
        scenario2.Add("Cette fois-ci, vous devez encore jouer à un jeu pour ouvrir la porte. Vous demandez alors à vos camarades de vous couvrir et commencez à jouer.");


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




