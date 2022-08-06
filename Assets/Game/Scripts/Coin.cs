using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //private BoxCollider2D col;
    //public AudioSource sound;

    void awake ()
    {
        //col = GetComponent<BoxCollider2D>();
        //sound = GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //sound.Play();
            //col.enabled = false;
            GameController.gameController.SetCoins(1);
            Destroy(this.gameObject);
        }
    }
}
