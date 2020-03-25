using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 0.3f;
    Animator animation;
    SpriteRenderer sprite;
    public float flap = 1000f;
    bool jump = false;
    public float scroll = 5f;
    float direction = 0f;
    Rigidbody2D rb;
    public float PlayerHP = 100;
    // Start is called before the first frame update
    void Start()
    {
        this.animation = GetComponent<Animator>();
        this.sprite = GetComponent<SpriteRenderer>();
        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animation.SetBool("run", true);
            sprite.flipX = false;
            direction = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animation.SetBool("run", true);
            sprite.flipX = true;
            direction = -1f;
        }
        else
        {
            direction = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Z)){
            animation.SetBool("yarikamae", true);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            animation.SetBool("yarikamae", false);
            animation.SetBool("yarinage", true);
            Invoke("animationStop", 1f);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animation.SetBool("run", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animation.SetBool("run", false);
        }

        rb.velocity = new Vector2(scroll * direction, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.UpArrow) && !jump)
        {
            rb.AddForce(Vector2.up * flap);
            jump = true;
        }
        Debug.Log("jump: " + jump.ToString());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            jump = false;
        }
        if(collision.gameObject.tag == "enemy")
        {
             for(var i = 0; i < 10; i++)
            {
                PlayerHP--;
            }
            Debug.Log("プレイヤーHP: " + PlayerHP.ToString());
        }
    }

    void animationStop()
    {
        animation.SetBool("yarinage", false);
    }
    void animationStop2()
    {
        animation.SetBool("yarikamae", false);
    }
}

