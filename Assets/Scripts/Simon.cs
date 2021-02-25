using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon : MonoBehaviour
{
    List<Sprite> list_sprite;

    List<int> list_id_sprite;

    int cp = 0;

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //action qui fait le simon mdr
        //initialise list_id_sprite
    }

    /*private void OnMouseDown() //This function is called each time player clicks on GameObject
    {
        if(list_sprite.FindIndex(spriteRenderer.sprite) == list_id_sprite.Find(cp))
        {
            if(cp == 4) //finish
            cp++;
            //action qui fait que la carte s'allume
        }
        else
        {
            cp = 0;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
