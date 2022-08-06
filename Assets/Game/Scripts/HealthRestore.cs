using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestore : MonoBehaviour
{
public Player player;
    void OnTriggerEnter2D(Collider2D other) {
        
        if ( other.gameObject.tag.Equals("Player"))
        {
            player.HealthRestore();
            Destroy(this.gameObject);
            
        }
        
    }

}
