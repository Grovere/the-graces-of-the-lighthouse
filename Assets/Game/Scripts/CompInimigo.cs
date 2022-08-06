using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompInimigo : MonoBehaviour
{
    [SerializeField]
    private int vida = 3;

    private AudioSource sound;
    protected SpriteRenderer sprite;

     void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        sound = GetComponent<AudioSource>();
    }

    public void TomaDano(int dano)
    {
        sound.Play();
        vida -= dano;
        StartCoroutine(Damage());
        if(vida <= 0)
        {  
            Morre();
        }

    }
       IEnumerator Damage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;

    }

    private void Morre()
    {   
        Destroy(gameObject);
    }
    
 }
