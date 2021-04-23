using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    public float bulletSpeed = 30f;

    private Vector3 target;

    // Use this for initialization
    void Start()
    {
       Cursor.visible = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        crosshairs.transform.position = new Vector2(-target.x, -target.y);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);


        if (Input.GetMouseButton(0) && Time.time > nextFire) // wird aktiviert wenn angegebene Maustaste gedrückt gehalten wird //if (Input.GetMouseButtonDown(1))
        {
            nextFire = Time.time + fireRate;
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            FireBullet(direction, rotationZ);
        }
    }
    void Update()
    {

    }
    void FireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = -direction * bulletSpeed;
    }
}