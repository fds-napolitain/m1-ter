using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenarAABA : MonoBehaviour
{

    public Text scenarioText;
    public Text questionText;
    public Text reponse1Text;
    public Text reponse2Text;

    public List<string> scenario = new List<string>();
    public List<string> scenario1 = new List<string>();
    public List<string> scenario2 = new List<string>();
    public List<string> scenario3 = new List<string>();
    public List<string> scenario4 = new List<string>();
    public List<string> scenario5 = new List<string>();
    public List<string> scenario6 = new List<string>();
    public List<string> scenario7 = new List<string>();
    public string question;
    public string reponse1;
    public string reponse2;
    public int i = 0;
    public int branche = 0;

    private void Start()
    {
        // AABA
        scenario.Add("La porte s’ouvre et vous soufflez de soulagement. Au moins cette fois vous ne vous êtes pas planté…");
        scenario.Add("Vous passez en premier et découvrez que vous venez d’entrer dans la cuisine. Vous vous sentez alors étonnamment mal à l’aise sans comprendre exactement pourquoi. Rapidement, vous remarquez une porte à gauche au fond de la pièce.");
        scenario.Add("Vous vous en approchez et regardez par la petite fenêtre de porte en espérant qu’elle soit connectée à la bonne pièce, et ce que vous découvrez vous glace le sang.");
        scenario.Add("Un alien gigantesque, vert avec des yeux de mouche des antennes et quatre bras se tient à côté de ce qui semble être les restes du corps d’Innoth. Il a la bouche couverte de sang et il en est train de lécher un à un ses seize doigts ensanglantés.");
        scenario.Add("Vous savez que vous avez bloqué l’autre porte en échouant. Vous savez donc qu’il y a une très forte probabilité pour que la porte soit également bloquée de l’intérieur. Ainsi, il ne reste qu’une sortie pour cet extraterrestre vert : la porte contre laquelle vous êtes actuellement collé.");
        scenario.Add("Vous avez donc deux options :");
        scenarioText.text = scenario[i];
        i++;

        // AABAA
        scenario1.Add("Vous regardez rapidement autour de vous pour chercher une cachette. Vous voyez ce placard coulissant sous le plan de travail et décidez de vous y glisser.");
        scenario1.Add("Vous voyez Sekip se glisser dans un autre placard en face de vous. Le capitaine est entré dans la chambre froide et compte sur vous pour l’en faire sortir une fois tout cela fini.");
        scenario1.Add("Vous entendez la porte s’ouvrir et inconsciemment vous retenez votre respiration. Par une petite fente vous pouvez voir Sekip en face de vous. Il est tout aussi mal que vous.");
        scenario1.Add("L’extraterrestre passe devant vous et continue sa progression. Vous entendez la porte de la chambre froide, puis un long frisson vous glace le sang quand vous entendez votre capitaine crier.");
        scenario1.Add("“Non ! Laissez-moi ! Spat ! Sekip !”");
        scenario1.Add("Il vous appelle à l’aide. Vous pouvez alors :");
        
        // AABAB
        scenario2.Add("Vous choisissez de prendre vos jambes à votre cou. Un choix en apparence plus que judicieux.");
        scenario2.Add("Vous faites demi-tour et faites signe à vos camarades de faire de même.");
        scenario2.Add("Vous trouvez à nouveau face à un choix :");

        // AABAAA
        scenario3.Add("Vous ouvrez votre placard à la volée et sortez pour découvrir qu’il est déjà trop tard, le capitaine est mort. Vous paniquez alors et tentez de fuir, mais vous n’avez aucune chance.");
        scenario3.Add("L’alien vous saute dessus et en tombant vous croisez le regard de Sekip horrifié juste avant d’être dévoré vivant.");

        // AABAAB
        scenario4.Add("Vous choisissez de l’abandonner, réalisant que vous n’avez aucune chance. Cinq secondes plus tard, vous voyez du sang gicler sur le sol devant vous.");
        scenario4.Add("Vous attendez avec horreur en entendant les bruits terrifiants de votre capitaine se faisant dévorer, quand soudain la tête du capitaine tombe devant vous.");
        scenario4.Add("Sekip en face de vous, terrifié, ne peut retenir un couinement.");
        scenario4.Add("Les bruits cessent alors immédiatement et vous entendez votre ennemi se rapprocher. Avant que vous ne compreniez ce qu’il se passe vous vous retrouvez nez à nez avec l’alien.");
        scenario4.Add("Il vous regarde de ses yeux noirs opaques dans lequel vous voyez votre reflet. Et vous savez, vous savez que vous êtes mort… A cause de Sekip !");
        scenario4.Add("Alors, pris d’une rage soudaine, vous bondissez de votre placard et ouvrez le placard de Sekip. Si vous devez mourir, vous voulez que lui aussi !");
        scenario4.Add("L’extraterrestre vous attrape par le col puis attrape Sekip en faisant un sourire tordu très effrayant, puis il vous emmène dans la chambre froide. Il n’a aucun mal à vous retenir malgré votre résistance, et mais vous n’abandonnez pas !");
        scenario4.Add("Toutefois, c’était un combat perdu d’avance et vous le réalisez quand il vous transperce la poitrine avec un crochet pour vous accrocher dans la chambre froide.");
        scenario4.Add("Alors que vos derniers instants arrivent, vous croisez le regard de Sekip suspendu en face de vous, et vous vous mitraillez du regard jusqu’à votre dernier soupir.");

        // AABABA
        scenario5.Add("Vous savez que le monstre vous a entendu partir. Vous ne réfléchissez donc pas pendant trois siècles et partez en courant.");
        scenario5.Add("Vous avancez dans l’inconnue la plus complète. Il fait sombre et vous ne voyez pas à plus de deux mètres devant vous ! Si seulement vous n’aviez pas oublié votre lampe torche dans la cuisine !");
        scenario5.Add("Vous continuez à avancer jusqu’à tomber dans une impasse. Non ! C’est impossible ! Vous réalisez que vous avez fait le mauvais choix ! Ce chemin est sans issue !");
        scenario5.Add("Bientôt, vous entendez la respiration excitée de votre ennemi qui visiblement adore chasser. Il se rapproche et vous ne savez pas quoi faire !");
        scenario5.Add("Quand vous le voyez en face de vous, quelque chose se déconnecte dans votre cerveau et sans réfléchir, vous poussez violemment Sekip sur l’alien avant de passer en courant à côté, utilisant le pilote comme appat.");
        scenario5.Add("Le capitaine qui comprend ce que vous venez de faire vous suit rapidement. ");
        scenario5.Add("Alors que vous courrez, vous entendez les hurlements de douleur de Sekip, puis le silence. La seule chose qui vous vient à l’esprit c’est que maintenant, vous ne verrez jamais vos dix dollars.");
        scenario5.Add("Vous repassez devant la porte bloquée et tombez sur deux autres aliens tenant Loulou en discutant dans une langue inconnue.");
        scenario5.Add("Alors, avant que vous ne puissiez penser à quoi que ce soit, vous sentez qu’on vous pousse violemment sur les deux monstres. Le capitaine vient de vous faire exactement ce que vous avez fait à Sekip.");
        scenario5.Add("Il part en courant avec Loulou qui en a profiter pour se libérer et vous êtes presque sûr de l’avoir entendu vous chuchoter : “Ce n’est pas contre toi…”");
        scenario5.Add("Les deux aliens vous regardent avec envie, et moins d’un centième de seconde plus tard vous hurlez en appelant vos parents, priant pour qu’on abrège vos souffrances.");

        // AABABB
        scenario6.Add("Alors que vous partez en courant, vous l’entendez franchir la porte. Il vous a entendu partir, vous en êtes maintenant sûr.");
        scenario6.Add("Vous tentez de rebrousser chemin pour aller au vaisseau. Vous vous élancez donc, retombez face à la porte que vous avez bloquée et continuez en suivant les traces de sang en sans inverse.");
        scenario6.Add("Mais vous entendez rapidement du bruit au bout du couloir. Beaucoup de bruit !");
        scenario6.Add("Ainsi, encore une fois, vous faites marche arrière et vous retrouvez face à la porte bloquée. A droite, l’alien qui a mangé votre ami. Derrière vous, probablement un groupe d’aliens ! Vous êtes piégés.");
        scenario6.Add("Vous tentez donc de vous acharner sur cette porte pour l’ouvrir mais rien à faire.");
        scenario6.Add("Et puis, vous sentez quelqu’un vous pousser violemment et vous atterrissez directement sur l’alien qui arrive de la droite. Vous comprenez alors que Sekip vient de vous jeter sur l’extraterrestre pour faire dimension pour que lui et le capitaine puissent s’enfuir. ");
        scenario6.Add("Bientôt vous sentez des dents s’enfoncer dans votre épaule et en arracher un bout. Vous hurlez et vous débattez, mais vous n’avez aucune chance ! Vous devenez alors le deuxième casse-croûte vivant de la journée de ce monstre vert.");
        scenario6.Add("Alors que votre dernière heure arrive, vous maudissez le pilote de votre équipage en priant pour qu’ils ne survivent pas à cet enfer !");

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
                reponse1Text.text = "Tenter de vous cacher dans la cuisine";
                reponse2Text.text = "Fuir la pièce au plus vite";
            }
            else if(i == scenario.Count - 1 && branche == 1)
            {
                scenarioText.text = "";
                questionText.text = scenario[i];
                reponse1Text.text = "Sortir de votre cachette et tenter d’aider le capitaine";
                reponse2Text.text = "Rester silencieux et ne pas bouger";
            }
            else if (i == scenario.Count - 1 && branche == 4)
            {
                scenarioText.text = "";
                questionText.text = scenario[i];
                reponse1Text.text = "Aller à droite";
                reponse2Text.text = "Rebrousser chemin en allant à gauche";
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
                    if (branche == 2)
                    {
                        SceneManager.LoadScene("Fin5");
                    }
                    else if(branche == 3)
                    {
                        SceneManager.LoadScene("Fin6");
                    }
                    else if(branche == 5)
                    {
                        SceneManager.LoadScene("Fin7");
                    }
                    else
                    {
                        SceneManager.LoadScene("Fin8");
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
                        branche += 1;
                        questionText.text = "";
                        reponse1Text.text = "";
                        reponse2Text.text = "";
                        i = 0;
                        scenarioText.text = scenario[i];
                        i++;
                        scenario1 = scenario3;
                        scenario2 = scenario4;
                    }
                    else if (hit.collider.gameObject.name == "Reponse2")
                    {
                        scenario = scenario2;
                        if (branche == 0)
                            branche+=2;
                        branche += 2;
                        questionText.text = "";
                        reponse1Text.text = "";
                        reponse2Text.text = "";
                        i = 0;
                        scenarioText.text = scenario[i];
                        i++;
                        scenario1 = scenario5;
                        scenario2 = scenario6;
                    }
                    i = 0;
                }
            }
        }
    }
}

