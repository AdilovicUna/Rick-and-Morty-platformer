using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 10;

    private int direction = 1;
    private float lifetime = 15.0f;
    private float timer = 0.0f;
    private string killTag;
    private string ignoreTag;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction, 0, 0);
        if(lifetime < timer)
        {
            destroy();
        }
        timer += Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == killTag && killTag == "EvilRick") // destroy if evil rick
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == killTag && killTag == "MainRick") // damage if main rick
        {
            collision.gameObject.GetComponent<Controller>().addToHealth(-1);
        }
        else if(collision.gameObject.tag == ignoreTag) // ignore if for example evil rick encounters a bullet that any evil rick shot
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());
        }

        if(collision.gameObject.tag != ignoreTag && collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Portal") // destroy the bullet
        {
            destroy();
        }
    }

    private void destroy()
    {
        Destroy(this.gameObject);
    }

    public void setDirection(int dir)
    {
        direction = dir;
        GetComponent<SpriteRenderer>().flipX = dir == -1 ? true : false;
    }

    public void setKillTag(string tag)
    {
        killTag = tag;
    }

    public void setIgnoreTag(string tag)
    {
        ignoreTag = tag;
    }
}
