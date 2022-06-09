using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public int speed = 5;
    public int jumpingSpeed = 7;
    public GameObject gameOver;
    public GameObject mortys;
    public GameObject healthBar;
    public AudioClip healthSound;
    public AudioClip shotSound;

    private Rigidbody2D character;
    private Animator animator;
    private bool onGround = true;
    private bool teleported = false;
    private int layer = 0;
    private int prevLayer = -1;
    private int health;
    private int maxHealth;
    private int mortysCount;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.playLoop();
        character = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = (int)healthBar.GetComponent<Slider>().maxValue;
        maxHealth = (int)healthBar.GetComponent<Slider>().maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        // moving left and right
        if (onGround && Input.GetKey(KeyCode.Space))
        {
            onGround = false;
            character.velocity = new Vector2(horizontal * speed, jumpingSpeed);
        }
        else
        {
            character.velocity = new Vector2(horizontal * speed, character.velocity.y);
        }

        // animation and flipping
        if (horizontal < -0.01f)
        {
            animator.SetBool("move", true);
            animator.SetBool("jump", !onGround);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal > 0.01f)
        {
            animator.SetBool("move", true);
            animator.SetBool("jump", !onGround);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else // stand still
        {
            animator.SetBool("move", false);
            animator.SetBool("jump", false);
            transform.localScale = new Vector3(1, 1, 1);
        }

        // update layer (very bad solution to a camera problem I had but honestly anything else will take a lot of time)
        if (transform.position.y >= 25f)
        {
            prevLayer = layer;
            layer = 2;
        }
        else if (transform.position.y >= 10f)
        {
            prevLayer = layer;
            layer = 1;
        }
        else
        {
            prevLayer = layer;
            layer = 0;
        }

        mortysCount = mortys.transform.childCount;
        // game ending
        if (health <= 0 || mortysCount == 0)
        {
            gameOver.GetComponent<GameOver>().endGame(mortysCount);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    public void setTeleported(bool t)
    {
        teleported = t;
    }

    public bool getTeleported()
    {
        return teleported;
    }

    public int getLayer()
    {
        return layer;
    }

    public bool sameLayer()
    {
        return layer == prevLayer;
    }

    public bool addToHealth(int i)
    {
        if (i == 1) // pick up heart
        {
            SoundManager.instance.play(healthSound);
        }
        else // get shot
        {
            SoundManager.instance.play(shotSound);
        }
        if (i == -1 || health < maxHealth)
        {
            health += i;
            healthBar.GetComponent<Slider>().value = health;
            return true;
        }
        return false;
    }
}
