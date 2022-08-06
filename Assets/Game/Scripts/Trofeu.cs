using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trofeu : MonoBehaviour
{

    public int final = 0;
    private bool ativo = false;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") && ativo)
        {
            SceneManager.LoadScene("Menu");
            Destroy(this.gameObject);
        }
    }
    public void AtualizarFinal()
{
    final++;

    if(final > 3)
    {
        ativo = true;
        sprite.enabled = true;
    }

}


    
}
