using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransfer : MonoBehaviour
{

    public Vector2 playerAdjust;
    public Vector2 cameraAdjust;

    /*
    public GameObject mapRoom;
    public Rigidbody2D iconRb;
    public Rigidbody2D mapRb;
    public Rigidbody2D roomRb;
    */

    void Start()
    {
        //iconRb = GameObject.FindGameObjectWithTag("Icon").GetComponent<Rigidbody2D>();
        //mapRb = GameObject.FindGameObjectWithTag("Map").GetComponent<Rigidbody2D>();
        //roomRb = GameObject.FindGameObjectWithTag("Room").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            CameraMovement cam = Camera.main.GetComponent<CameraMovement>();
            cam.minPosition += cameraAdjust;
            cam.maxPosition += cameraAdjust;
            player.transform.position += new Vector3(playerAdjust.x,
                                                     playerAdjust.y,
                                                    0);
            /*
            // Bewegen von der Map
            if(playerAdjust.y == 4) // Top Room
            {
                // Bewege alle Räume auf der Map 1 nach Oben
                 mapRb.transform.position += new Vector3(0, 1, 0);



                //iconRb.transform.position += new Vector3(0, 1, 0);
                //iconRb.transform.position += new Vector3(playerAdjust.x, playerAdjust.y, 0);
                //map.transform.position += new Vector3(0, 1, 0);
                //map.transform.position += new Vector3(0, 20000, 0);
            }
            if (playerAdjust.x == -3) // Left Room
            {
                // Bewege alle Räume auf der Map 1 nach Links

                //mapRb.transform.position += new Vector3(1, 0, 0);
                //iconRb.transform.position += new Vector3(-20, 0, 0);
                //map.transform.position += new Vector3(-1, 0, 0);
                mapRb.transform.position += new Vector3(-20, 0, 0);
                roomRb.transform.position += new Vector3(-20, 0, 0);
                //iconRb.transform.position = mapRb.transform.position;
                iconRb.transform.position += new Vector3((float)-20.5, 0, 0);
                Instantiate(mapRoom, iconRb.transform.position, Quaternion.identity);
                Instantiate(mapRoom, iconRb.transform.position, Quaternion.identity);
            }
            if (playerAdjust.x == 3) // Right Room
            {
                // Bewege alle Räume auf der Map 1 nach Rechts

                //iconRb.transform.position += new Vector3(1, 0, 0);
                //map.transform.position += new Vector3(1, 0, 0);
            }
            if (playerAdjust.y == -4) // Bot Room
            {
                // Bewege alle Räume auf der Map 1 nach Unten

                //iconRb.transform.position += new Vector3(0, -1, 0);
                //map.transform.position += new Vector3(0, -1, 0);
            }

            // iconRb.transform.position += new Vector3(playerAdjust.x, playerAdjust.y, 0);
            //  StartCoroutine(textCo());
            */
        }

    }

}