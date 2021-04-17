using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hittable : MonoBehaviour {
    private Text Live;
    public int points = 5;
    public int Drops = 0;
    public int Hitpoints = 10;
    public int Damage = 0;
    public GameManager gm;
   // public Game_Shaker CameraShake;
    public Transform spawnPosition;
    public GameObject Drop;
  

    void Start()
    {
        GameObject gmObj = GameObject.FindGameObjectWithTag("Game Controller");
        if (gmObj)
            gm = gmObj.GetComponent<GameManager>();
        else
            throw new MissingComponentException("Game Manager is missing");
    }

    void Awake() {
        if (!spawnPosition)
            spawnPosition = transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (tag == SpaceShip_Const.Tag_Enemy && (other.tag == SpaceShip_Const.Tag_Player || other.tag == "Player Projectile"))
        {

            if (other.tag == SpaceShip_Const.Tag_Player)
            {

                gm.PlayerHitpoints--;
                // gm.required_kills--;
            }
            else if (other.tag == "Player Projectile")
            {
                Hitpoints--;
                Destroy(other.gameObject);
               // gm.Live.maxValue += 1;

            }


        }

 

        else if (tag == SpaceShip_Const.Tag_Player && other.tag != "Item" && other.tag != "Explosion" && other.tag !=SpaceShip_Const.Tag_Enemy)
        {
            if (other.tag == "Heart")
            {
                Destroy(other.gameObject);
                gm.PlayerHitpoints++;
            }

            if (other.tag == "Heart Container")
            {
                Destroy(other.gameObject);
                gm.PlayerHitpoints++;
            }

            /*else if (other.tag != "Obstacle" && other.tag != "Bullet" && other.tag != "Shield")
            {
                Destroy(other.gameObject);

                StartCoroutine(CameraShake.Shake(1.15f, 1.15f));
            }*/

            else if (gm.PlayerHitpoints <= 0)
            {
//                Destroy(this.gameObject);
            }

        }


        else if (tag == "Bullet" && other.tag != SpaceShip_Const.Tag_Player && other.tag != "Shield")
        {
            Destroy(this.gameObject);
        }

        else if (tag == "Enemy Bullet")
        {
            if (other.tag == SpaceShip_Const.Tag_Player)
            {
                gm.PlayerHitpoints--;
                Destroy(this.gameObject);
            }
            else if (other.tag == "Wall" )
            {
                Destroy(this.gameObject);
            }

        }

        else if (tag == "Endboss" && other.tag != "Enemy Bullet" && other.tag != "Minigun" && other.tag != "Life Up" && other.tag != "Speed Up" && other.tag != "Rocket Up" && other.tag != "Shield Up")
        {

            if (other.tag == SpaceShip_Const.Tag_Player)
            {
                Drops = 0;
                gm.PlayerHitpoints--;
                Hitpoints = 0;
                // gm.required_kills--;
            }

            else if (other.tag == "Shield")
            {
                Hitpoints = Hitpoints - 15;
                Destroy(other.gameObject);
            }

            else if (other.tag == "Explosion") { Hitpoints -= 10; }

            if (other.tag == "Bullet")
            {
                Hitpoints--;
            }

            if (Hitpoints <= 0)
            {
                Destroy(this.gameObject);
                gm.score += points;
                // gm.required_kills--;
            }


        }


        else if (tag == "Untagged")
        {
        }


        if (Drops == 1 && Hitpoints <= 0)
        {
            PowerupSpawn();
        }
  

    
    }

    void PowerupSpawn()
    {
        if(Drop)
            Instantiate(Drop, spawnPosition.position, spawnPosition.rotation);
    }



    
}

