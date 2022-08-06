using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public Player player;

    void OnCollisionEnter2D(Collision2D other) {
        if ( other.gameObject.tag.Equals("Enemy"))
        {
            if(!player.invulnerable)
            {
                player.DamagePlayer();
            }
        }

        if ( other.gameObject.tag.Equals("Bounds"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
