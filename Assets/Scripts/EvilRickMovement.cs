using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilRickMovement : MonoBehaviour
{
    public int speed = 2;
    public float diameter = 2.5f;
    public float range = 3.0f;
    public GameObject mainRick;

    private float initPosX;
    private int direction = 1;
    private Rigidbody2D character;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("move", true);
        initPosX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(mainRick.transform.position.x - transform.position.x) <= range &&
            Mathf.Abs(mainRick.transform.position.y - transform.position.y) < 1 )
        {
            GetComponent<EvilRickShooting>().shoot();
        }
        else
        {
            GetComponent<EvilRickShooting>().stopShooting();
        }

        // moving left and right
        if (transform.position.x > initPosX + diameter)
        {
            direction = -1;
        }
        else if (transform.position.x < initPosX - diameter)
        {
            direction = 1;
        }
        transform.localScale = new Vector3(-direction, 1, 1);
        character.velocity = new Vector2(direction * speed, character.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EvilRick" || collision.gameObject.tag == "Morty")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());
        }
    }

    public int getDirection()
    {
        return direction;
    }
}
