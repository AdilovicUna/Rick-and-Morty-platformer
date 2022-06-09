using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehavior : MonoBehaviour
{
    public AudioClip portalSound;

    private GameObject portals;

    // Start is called before the first frame update
    void Start()
    {
        portals = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;

        int child = 0;
        do
        {
            child = Random.Range(0, portals.transform.childCount);

        } while (child == transform.GetSiblingIndex() && checkLayers(collider, child));

        Vector3 pos = portals.transform.GetChild(child).gameObject.transform.position;

        int direction = GetComponent<SpriteRenderer>().flipX == true ? 1 : -1;

        // transport
        if (collider.tag == "MainRick")
        {
            SoundManager.instance.play(portalSound);
            collider.transform.localPosition = new Vector3(pos.x + (2 * direction), pos.y, pos.z);
            collider.transform.localScale = new Vector3(-direction, 1, 1);
            collider.GetComponent<Controller>().setTeleported(true);

        }
        else if (collider.tag == "Bullet")
        {
            collider.transform.position = new Vector3(pos.x + 2, pos.y, pos.z);
            collider.GetComponent<Bullet>().setDirection(direction);
        }
    }

    bool checkLayers(GameObject collider, int child)
    {
        if(collider.tag == "MainRick")
        {
            if(collider.GetComponent<Controller>().sameLayer() && child == collider.GetComponent<Controller>().getLayer())
            {
                return false;
            }
            return true;
        }
        return true;
    }
}
