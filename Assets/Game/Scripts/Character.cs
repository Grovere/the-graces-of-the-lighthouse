using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement Variables")]
    public float speed = 10f;
    public float jumpForce = 200f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float radius = 0.2f;

    public int vida = 5;
    public bool invulnerable = false;

    int extraJumps = 1;
    bool isJumping = false;
    bool isOnFloor = false;

    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator anim;

    [SerializeField]
    private Collider2D areaDeAtaque;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isOnFloor = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            isJumping = true;
            extraJumps--;
        }

        if (isOnFloor)
        {
            extraJumps = 1;
        }



        if (Input.GetButtonDown ("Fire1"))
        {
            anim.SetTrigger("attack");
        }

        PlayerAnimation();
    
    }

    public void IniciaAtaque()
    {
        areaDeAtaque.enabled = true;
    }

    public void TerminaAtaque()
    {
        areaDeAtaque.enabled = false;
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(move * speed, body.velocity.y);

        if ((move > 0 && sprite.flipX == true) || (move < 0 && sprite.flipX == false))
        {
            Flip();
        }

        if (isJumping)
        {
            body.velocity = new Vector2(body.velocity.x, 0f);
            body.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }

        if (body.velocity.y > 0f && !Input.GetButton("Jump"))
        {
            body.velocity += Vector2.up * -0.4f;
        }



    }

    void Flip()
    {
        sprite.flipX = !sprite.flipX;
        

    }
    void PlayerAnimation()
    {

        anim.SetFloat("VelX", Mathf.Abs(body.velocity.x));
        anim.SetFloat("VelY", Mathf.Abs(body.velocity.y));


    }

    IEnumerator Damage()
    {

        for(float i = 0f; i < 1f; i += 0.1f)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        invulnerable = false;

    }

    public void DamagePlayer()
    {
        vida--;
        invulnerable = true;
        
        StartCoroutine(Damage());

        if(vida < 1)
        {
            Debug.Log("Morreu");
        }

    }

}

