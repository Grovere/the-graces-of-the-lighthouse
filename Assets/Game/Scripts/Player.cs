using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movement Variables")]
    public float speed = 10f;
    public float jumpForce = 200f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float radius = 0.2f;

    public bool isAlive = true;

    public int vida = 3;
    public bool invulnerable = false;
    

    int extraJumps = 1;
    bool isJumping = false;
    bool isOnFloor = false;

    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator anim;

    [SerializeField]
    private Collider2D areaDeAtaque;
    public Transform areaDeAtaqueB;
    
    


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isAlive)
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
        if(isAlive)
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
        }



    

    void Flip()
    {
        sprite.flipX = !sprite.flipX;
        areaDeAtaqueB.localPosition = new Vector2(-areaDeAtaqueB.localPosition.x, areaDeAtaqueB.localPosition.y);
        

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
            isAlive = false;
            anim.SetTrigger("Death");
            Invoke("ReloadLevel", 2f);
        }

    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HealthRestore()
    {
        if(vida < 3)
        {
            vida++;
        }
    }


}
