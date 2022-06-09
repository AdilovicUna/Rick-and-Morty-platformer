using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public GameObject leftBorders;
    public GameObject rightBorders;
    public GameObject topBorders;
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Controller>().getTeleported())
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            player.GetComponent<Controller>().setTeleported(false);
        }
        else
        {
            int i = player.GetComponent<Controller>().getLayer();
            float x = checkXBoundary(i) ? player.transform.position.x : transform.position.x;
            float y = checkYBoundary(i) ? player.transform.position.y : transform.position.y;

            transform.position = new Vector3(x, y, transform.position.z);
        }
    }

    bool checkXBoundary(int i)
    {
        return player.transform.position.x > leftBorders.transform.GetChild(i).position.x + 4f &&
                player.transform.position.x < rightBorders.transform.GetChild(i).position.x - 4f;
    }

    bool checkYBoundary(int i)
    {
        return player.transform.position.y > ground.transform.GetChild(i).position.y + 2f &&
                player.transform.position.y < topBorders.transform.GetChild(i).position.y - 2f;
    }
}
