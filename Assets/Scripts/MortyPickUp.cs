using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortyPickUp : MonoBehaviour
{
    public GameObject txt;
    public GameObject mortys;
    public AudioClip mortySound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.GetComponent<UnityEngine.UI.Text>().text = mortys.transform.childCount.ToString();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // pick up morty
        if (collision.gameObject.tag == "Morty" && Input.GetKey(KeyCode.O))
        {
            SoundManager.instance.play(mortySound);
            Destroy(collision.gameObject);
            txt.GetComponent<UnityEngine.UI.Text>().text = mortys.transform.childCount.ToString();
        }
    }

}
