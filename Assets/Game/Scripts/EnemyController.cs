using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  
    public float speed;
    public float distanceAttack;

    protected bool isMoving = false;

    protected Rigidbody2D body2d;
    protected Transform player;
    protected SpriteRenderer sprite;




    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    protected float PlayerDistance()
    {
        return Vector2.Distance(player.position, transform.position);


    }

    protected void Flip()
    {
        sprite.flipX = !sprite.flipX;
        speed *= -1;

    }

    protected virtual void Update()
    {
        float distance = PlayerDistance();
        isMoving = (distance <= distanceAttack);

        if (isMoving)
        {
            if ((player.position.x > transform.position.x && sprite.flipX) || (player.position.x < transform.position.x && !sprite.flipX))
            {
                Flip();
            }
        }
    }

}


