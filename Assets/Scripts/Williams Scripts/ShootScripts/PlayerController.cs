using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public int playerId;
    Player player;
    GameManager gamemanager;

    [Header("Georges attributes:")]
    public float movementBaseSpeed = 5.5f;
    public float crosshairDistance = 1.0f;
    public float arrowBaseSpeed = 1.0f;
    public float movementBasePenalty = 1.0f;
    public float shootingRecoilTime = 1.0f;

    public int maxHealth = 100;
    public int currentHealth;
    public int healpots; // Anzahl
    public HealthBar healthBar;
    public int healthRecover = 10;
    public int useHealpotions = 1;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;


    // [Space]
    // [Header("Statistics:")]
    Vector2 movementDirection;
    float movementSpeed;
    bool endOfAiming;
    bool isAiming;
    float shootingRecoil = 0;

    [Space]
    [Header("References:")]
    Rigidbody2D rb;
    public GameObject crosshair;
    public float detonationTimer = 0f;
    public GameObject Explosion;

    [Space]
    [Header("Prefabs:")]
    public GameObject arrowPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        gamemanager = FindObjectOfType<GameManager>();
        currentHealth = maxHealth;          // verändet Wert der Healtbar
        healthBar.SetMaxHealth(maxHealth);
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Q) && gamemanager.healpotions > 0 && currentHealth != maxHealth) // Gamemanager fragen wie viele heiltränke wir haben, wemm über 1 = true, wenn Leben Voll = false
        {
            HealDamage(healthRecover);
        }

        ProcessInputs();
        Move();
        Aim();
        Shoot();
    }

    void ProcessInputs()
    {

            movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
            movementDirection.Normalize();

           // endOfAiming = Input.GetButtonUp("Fire1");
           // isAiming = Input.GetMouseButton(0);
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            isAiming = true;
            endOfAiming = true;
        }
         // isAiming = Input.GetButton("Fire1");


        if(isAiming)
        {
            movementSpeed *= movementBasePenalty; // Reduzieren der Laufgeschwindigkeit beim schießen
        }
        if(endOfAiming)
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

        if(endOfAiming)
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * arrowBaseSpeed;
            arrow.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            Destroy(arrow, 2.0f);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {

            // Spiele Sound ab passiert in der explosion

            // Spiele Effect ab
            if (Explosion != null)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
            }

            // Zerstöre Gegner
            Destroy(gameObject, detonationTimer);
        }
    }

    public void HealDamage(int healthRecover)
    {
        currentHealth += healthRecover;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.SetHealth(currentHealth);
        gamemanager.UseHealpotions();

    }
}
