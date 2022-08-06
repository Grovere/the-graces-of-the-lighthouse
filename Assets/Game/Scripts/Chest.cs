using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

public Trofeu trofeu;
private Animator anim;
private bool opened = false;

void Awake() 
{
    anim = GetComponent<Animator>();
}

void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && opened == false)
        {
            GameController.gameController.ShowImageChest(true);
            if(Input.GetKey(KeyCode.E))
            {
                opened = true;
                anim.SetTrigger("OpenChest");
                GameController.gameController.SetCoins(10);
                GameController.gameController.ShowImageChest(false);
                trofeu.AtualizarFinal();

            }
        }
    }

void OnTriggerExit2D(Collider2D other)
{
 if (other.gameObject.CompareTag("Player") && opened == false)
    {
        GameController.gameController.ShowImageChest(false);
            
    }
}

}
