using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bullets;
    public AudioClip shootSound;

    private GameObject gun;
    private GameObject muzzle;
    private float cooldown = 0.5f;
    private float timer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        gun = this.gameObject.transform.Find("Gun").gameObject;
        muzzle = gun.transform.Find("Muzzle").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            gun.active = true;
            if(cooldown < timer)
            {
                timer = 0.0f;
                SoundManager.instance.play(shootSound);
                int dir = Input.GetAxis("Horizontal") < -0.01f ? -1 : 1;
                GameObject bulletInstance = Instantiate(bullet, muzzle.transform.position, Quaternion.identity, bullets.transform);
                bulletInstance.GetComponent<Bullet>().setDirection(dir);
                bulletInstance.GetComponent<Bullet>().setKillTag("EvilRick");
                bulletInstance.GetComponent<Bullet>().setIgnoreTag("MainRick");
            }
        }
        else
        {
            gun.active = false;
        }
        timer += Time.deltaTime;
    }
}
