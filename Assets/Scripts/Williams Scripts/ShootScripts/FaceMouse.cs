using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    //public int playerId;
    Player player;
    public bool useController;

    [Header("Georges attributes:")]
    public float movementBaseSpeed = 5.5f;
    public float crosshairDistance = 1.0f;
    public float arrowBaseSpeed = 1.0f;
    public float movementBasePenalty = 1.0f;
    public float shootingRecoilTime = 1.0f;

    // [Space]
    // [Header("Statistics:")]
    Vector2 movementDirection;
    float movementSpeed;
    bool endOfAiming;
    bool isAiming;
    float shootingRecoil = 0;
    bool lockPosition;

    [Space]
    [Header("References:")]
    Rigidbody2D rb;
    public GameObject crosshair;

    [Space]
    [Header("Prefabs:")]
    public GameObject arrowPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();

        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Move();
        Aim();
        Shoot();
    }

    void ProcessInputs()
    {
        if (useController)
        {
            movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
            movementDirection.Normalize();

            endOfAiming = Input.GetButtonUp("Fire1");
            isAiming = Input.GetButton("Fire1");
            lockPosition = Input.GetButton("LockPosition");
        }
        else
        {
            Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); // Speichern des Mausortes
            movementDirection += mouseMovement; // Mausbewegung wird der Bewegungsrichtung hinzugefügt
                                                // mouseMovement; // Mausbewegung wird in mouseMovement gespeichert
            movementDirection.Normalize(); // Geschwindigkeit der Bewegung wird in der Diagonalen angepasst

            movementSpeed = Input.GetAxis("Vertical"); // ermöglicht das laufen mit den Pfeiltasten
            endOfAiming = Input.GetButtonUp("Fire1");
            isAiming = Input.GetButton("Fire1");
            lockPosition = Input.GetButton("LockPosition");
        }

        if (isAiming)
        {
            movementSpeed *= movementBasePenalty; // Reduzieren der Laufgeschwindigkeit beim schießen
        }
        if (endOfAiming)
        {
            shootingRecoil = shootingRecoilTime;
        }
        if (shootingRecoil > 0.0f)
        {
            shootingRecoil -= Time.deltaTime;
        }
    }

    void Move()
    {
        rb.velocity = movementDirection * movementSpeed * movementBaseSpeed;
    }

    void Aim()
    {
        if (movementDirection != Vector2.zero)
        {
            crosshair.transform.localPosition = movementDirection * crosshairDistance;
        }
    }

    void Shoot()
    {
        Vector2 shootingDirection = crosshair.transform.localPosition;
        shootingDirection.Normalize();

        if (endOfAiming)
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * arrowBaseSpeed;
            arrow.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            Destroy(arrow, 2.0f);
        }
    }
}