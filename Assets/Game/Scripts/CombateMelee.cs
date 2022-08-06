using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateMelee : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collission) 
    {
        if (collission.gameObject.tag.Equals("Enemy"))
        {
            var inimigo = collission.gameObject.GetComponent<CompInimigo>();
            inimigo.TomaDano (1);

        }
    }
    
}
