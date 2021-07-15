using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    GameManager gamemanager; // Verknüpfung mit Gamemanager

    [Header("Player Color")]
    private Color nativeColor;
    private Color damageColor;
    private float changePlayerColor = 0.2f;

    [Header("Georges attributes:")]
    public float moveSpeed = 5f;
    public int useHealpotions = 1;

    /*
     * Altes Shoot Script
    [Header("Arrows:")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 5.0f;
    public float fireDelay = 0.5f;
    private float lastFire;
    */

    [Header("References:")]
    private Rigidbody2D rb;
    public Animator animator;
    public HealthBar healthBar;
    //public RelictChargeBar relictChargeBar; // new

    public Image imageCooldown; 
    private float imageCooldownTime = 5f;
    private float imageCooldownTimer = 0.0f;

    public GameObject Explosion;

    [Header("Relicts:")]
    public Image timeRewindImage;
    public Image totemImage;
    public Image heavyArmorImage;
    public Text infoText;
    public GameObject infoImage;

    [Header("Statistics:")]
    private Vector2 movement; // zwischenspeicherung von bewegungswerten

    private enum State // Statemachine fürs Rollen
    {
        Normal,
        Rolling,
    }

    private Vector3 rollDir;
    private State state;
    private float rollSpeed;
    private bool isCooldown = false;
    public float rollCooldownTime = 5f;
    public float nextRollTime = 0;

    void Start()
    {
        // Color
        nativeColor = GetComponent<SpriteRenderer>().color;
        damageColor = Color.red;

        imageCooldown.fillAmount = 0.0f; ///////// für UI
        // Updaten der Stats im Gamemanager
        gamemanager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * moveSpeed * 10;
        transform.LookAt(transform.position, this.rb.velocity);
        timeRewindImage.enabled = false;
        totemImage.enabled = false;
        heavyArmorImage.enabled = false;
        //infoText.enabled = false;
        infoText.text = "";
        infoImage.SetActive(false);


        // Update UI CurrentHealth, MaxHealth
        state = State.Normal; // fürs Rollen
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown)
        {
            ApplyCooldown();
        }

        healthBar.SetMaxHealth(gamemanager.maxHp);
        healthBar.SetHealth(gamemanager.hp);

        //relictChargeBar.SetMaxRelictCharge(gamemanager.maxRelictCharge);
        //relictChargeBar.SetRelictCharge(gamemanager.relictCharge);

        // Relikte
        if (gamemanager.timeRewind == 0) // begrenzen der einsammelbaren Relikte
        {
            gamemanager.isRelictCollectable = true;
            timeRewindImage.enabled = false;
        }
        else if (gamemanager.timeRewind == 1)
        {
            gamemanager.isRelictCollectable = false;
            timeRewindImage.enabled = true;

            //infoText.enabled = true;
            //infoText.text = "Time Rewind: Reduces the cooldown of the dash by half the time";
            //counterTime = counterTime - Time.deltaTime;
            //if (counterTime <= infoTextTime1)
            if(gamemanager.isTimeRewindActive == false)
            {
                // infoText.enabled = false;
                //infoText.text = "";
                ShowInfoText("Time Rewind: Reduces the cooldown of the dash by half the time");
                gamemanager.isTimeRewindActive = true;
            }
        }

        if (gamemanager.totem == 0) // begrenzen der einsammelbaren Relikte
        {
            gamemanager.isRelictCollectable = true;
            totemImage.enabled = false;
        }
        else if (gamemanager.totem == 1)
        {
            gamemanager.isRelictCollectable = false;
            totemImage.enabled = true;

            if (gamemanager.isTotemActive == false)
            {
                ShowInfoText("Totem: Potions Heal the double amount of HP");
                gamemanager.isTotemActive = true;
            }
        }

        if (gamemanager.heavyArmor == 0) // begrenzen der einsammelbaren Relikte
        {
            gamemanager.isRelictCollectable = true;
            heavyArmorImage.enabled = false;
        }
        else if (gamemanager.heavyArmor == 1)
        {
            gamemanager.isRelictCollectable = false;
            heavyArmorImage.enabled = true;

            if (gamemanager.isArmorActive == false)
            {
                ShowInfoText("Heavy Armor: Gain 50 % damage Reduction but deal 50 % less Damage to Enemies");
                gamemanager.isArmorActive = true;
            }
        }

        //if (Input.GetKeyDown(gamemanager.UseRelict) && gamemanager.timeRewind > 0 && gamemanager.relictCharge == 2)
        if (gamemanager.timeRewind == 1)
        {
            GameObject character = GameObject.Find("Hero");
            if (character != null)
            {
                // Alte Version
                //nextRollTime = 0; // setze cooldown auf 0
                //gamemanager.relictCharge = 0;
                // Update Dash UI
                //imageCooldownTimer = 0;

                rollCooldownTime = 2.5f;
                imageCooldownTime = 2.5f;
            }
            else
            {
                Debug.Log("Player wurde nicht gefunden!");
            }
        }

        switch (state)
        {
            case State.Normal:

                //Char Movement
                movement.x = Input.GetAxis("Horizontal");
                movement.y = Input.GetAxis("Vertical");
                /////////*********************************************** Test Rotation
                /*
                Vector3 newPosition = new Vector3(movement.x, 0.0f, movement.y);
                transform.LookAt(newPosition + transform.position);
                transform.Translate(newPosition * moveSpeed * Time.deltaTime, Space.World);
                */

                // animator einfügen
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);

                // altes ShootScript
                /*
                float shootHor = Input.GetAxis("ShootHorizontal");
                transform.forward = new Vector3(shootHor, 0, 0);
                float shootVert = Input.GetAxis("ShootVertical");
                if ((shootHor != 0 || shootVert != 0) && Time.time > lastFire + fireDelay)
                {
                    //Shoot(shootHor, shootVert);
                    lastFire = Time.time;
                }
                */

                if (Time.time > nextRollTime)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse1) && movement.magnitude > 0.001f) //movement > 0) //movement.x == true || movement.y == true)
                    {
                        //TakeDamage(20);
                        rollDir = movement;
                        rollSpeed = 55f;
                        state = State.Rolling;
                        // Play Roll Animation (rollDir)
                        nextRollTime = Time.time + rollCooldownTime;
                        //imageCooldown.fillAmount = 0.0f; //´passt das hier?
                        isCooldown = true;
                    }
                }
                break;
            case State.Rolling:
                float rollSpeedDropMultiplier = 5f;
                rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

                // UI Update
                imageCooldownTimer = imageCooldownTime;
                //ApplyCooldown();

                float rollSpeedMinimum = 50f;
                if (rollSpeed < rollSpeedMinimum)
                {
                    state = State.Normal;
                }
                break;
        }
    }

    void ApplyCooldown()
    {
        imageCooldownTimer -= Time.deltaTime;

        if (imageCooldownTimer < 0.0f)
        {
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            imageCooldown.fillAmount = imageCooldownTimer / imageCooldownTime;
        }
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case State.Normal:
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
                break;
            case State.Rolling:
                rb.velocity = rollDir * rollSpeed;
                break;
        }
    }

    //public void LoadRelictChargeBar(int relictCharge)
    //{
    //    gamemanager.relictCharge += relictCharge;
    //    relictChargeBar.SetRelictCharge(gamemanager.relictCharge);
    //}

    public void TakeDamage(int damage)
    {
        if (gamemanager.heavyArmor == 1) // hier Rüstung einbauen
        {
            gamemanager.hp -= (int)((float)damage / 100.0f * gamemanager.heavyArmorDamageReduction);
            // Leben : 100 * x
            // (damage / 100 * gamemanager.heavyArmorDamageReduction);
        }
        else
        {
            gamemanager.hp -= damage;
        }
        // Updaten des Healthbartextes im UI
        healthBar.SetHealth(gamemanager.hp);

        // Color
        StartCoroutine(ChangePlayerColorByHit());

        if (gamemanager.hp <= 0)
        {
            gamemanager.hp = 0;
            gamemanager.coins = 0; //setzt die coins auf null wenn du stirbst
            gamemanager.healthpotions = 0; //setzt die healthpotions auf null wenn du stirbst
            // Spiele Sound ab passiert in der explosion

            // Spiele Effect ab
            if (Explosion != null)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
            }

            // Zerstöre Spieler, Teleportiere ihn zurück zur Stadt
            SceneManager.LoadScene(Slime_Const.Overworld_Name);
            Debug.Log("Du bist gestorben");
        }
    }

    IEnumerator ChangePlayerColorByHit()
    {
        if (GetComponent<Animator>())
        {
            GetComponent<Animator>().enabled = false;
        }
        GetComponent<SpriteRenderer>().color = damageColor;

        yield return new WaitForSeconds(changePlayerColor);
        if (GetComponent<Animator>())
        {
            GetComponent<Animator>().enabled = true;
        }
        GetComponent<SpriteRenderer>().color = nativeColor;
    }

    void ShowInfoText(string text)
    {
        infoText.gameObject.SetActive(true);
        infoImage.SetActive(true);
        infoText.text = "" + text;

        Invoke("DeactivateStagetext", 6f);
    }

     void DeactivateStagetext()
     {
         infoText.gameObject.SetActive(false);
        infoImage.SetActive(false);
        CancelInvoke("DeactivateStagetext");
     }
}


/*
 * Altes Shoot Script mit Pfeiltasten
void Shoot(float x, float y) // Berechnen der Schussgeschwindigkeit und Spawn
{
    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
    // bullet.AddComponent<Rigidbody2D>().gravityScale = 0; // fügt dem Schuss einen Rigidbody hinzu, und setzt gravity auf 0
    bullet.GetComponent<Rigidbody2D>().velocity = new Vector3
    ((x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed, // if statement in einer zeile, prüfung ob x kleiner ist als 0, falls ja setzte den Wert auf - und führe die Rechnung aus
    (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
    0);
}
*/






















//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Hero : MonoBehaviour
//{
//    GameManager gamemanager; // Verknüpfung mit Gamemanager

//    [Header("Georges attributes:")]
//    public int maxHealth = 100;
//    public int currentHealth;
//    public float moveSpeed = 5f;
//    public float detonationTimer = 0f;
//    public int healthRecover = 10;
//    public int useHealpotions = 1;
//    public int maxHealpotionsSlots = 3; //******************************** Noch einbauen im UI und Player

//    [Header("Arrows:")]
//    public GameObject bulletPrefab;
//    public float bulletSpeed = 5.0f;
//    public float fireDelay = 0.5f;
//    private float lastFire;

//    [Header("References:")]
//    //public Animator playerAnimator;
//    private Rigidbody2D rb;
//    public Animator animator;
//    public HealthBar healthBar;
//    public GameObject Explosion;

//    [Header("Statistics:")]
//    public int healpotionsInInventory;
//    private Vector2 movement; // zwischenspeicherung von bewegungswerten

//    private enum State // Statemachine fürs Rollen
//    {
//        Normal,
//        Rolling,
//    }

//    private Vector3 rollDir; //********* new roll
//    private State state;
//    private float rollSpeed;

//    void Start()
//    {
//        // Updaten der Stats im Gamemanager
//        gamemanager = FindObjectOfType<GameManager>();
//        // drehen des Projektile des Charakters in Blickrichtung 
//        rb = GetComponent<Rigidbody2D>();
//        rb.velocity = transform.right * moveSpeed * 10;
//        transform.LookAt(transform.position, this.rb.velocity);

//        currentHealth = maxHealth;          // verändet Wert der Healtbar
//        healthBar.SetMaxHealth(maxHealth);
//        // Update UI CurrentHealth, MaxHealth
//        gamemanager.UpdateMaxHealthText(maxHealth);
//        gamemanager.UpdateCurrentHealthText(currentHealth);
//        gamemanager.UpdateMaxHealpotionsSlots(maxHealpotionsSlots);

//        state = State.Normal; // fürs Rollen
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        switch (state)
//        {
//            case State.Normal:

//                //Char Movement
//                movement.x = Input.GetAxis("Horizontal");
//                movement.y = Input.GetAxis("Vertical");
//                /////////*********************************************** Test Rotation
//                /*
//                Vector3 newPosition = new Vector3(movement.x, 0.0f, movement.y);
//                transform.LookAt(newPosition + transform.position);
//                transform.Translate(newPosition * moveSpeed * Time.deltaTime, Space.World);
//                */

//                // animator einfügen
//                 animator.SetFloat("Horizontal", movement.x);
//                 animator.SetFloat("Vertical", movement.y);
//                 animator.SetFloat("Speed", movement.sqrMagnitude);

//                float shootHor = Input.GetAxis("ShootHorizontal");
//                // transform.forward = new Vector3(shootHor, 0, 0);
//                float shootVert = Input.GetAxis("ShootVertical");
//                if ((shootHor != 0 || shootVert != 0) && Time.time > lastFire + fireDelay)
//                {
//                    Shoot(shootHor, shootVert);
//                    lastFire = Time.time;
//                }

//                if (Input.GetKeyDown(KeyCode.Q) && gamemanager.healpotions > 0 && currentHealth != maxHealth) // Gamemanager fragen wie viele heiltränke wir haben, wemm über 1 = true, wenn Leben Voll = false
//                {
//                    HealDamage(healthRecover);
//                }

//                if (Input.GetKeyDown(KeyCode.Mouse1))
//                {
//                    //TakeDamage(20);
//                    rollDir = movement;
//                    rollSpeed = 55f;
//                    state = State.Rolling;
//                    // Play Roll Animation (rollDir)
//                }
//                break;
//                case State.Rolling:
//                float rollSpeedDropMultiplier = 5f;
//                rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

//                float rollSpeedMinimum = 50f;
//                    if (rollSpeed < rollSpeedMinimum)
//                    {
//                        state = State.Normal;
//                    }
//                break;
//        }
//    }


//    void FixedUpdate()
//    {
//        switch (state)
//        {
//            case State.Normal:
//                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
//                break;
//            case State.Rolling:
//                rb.velocity = rollDir * rollSpeed;
//                break;
//        }

//    }

//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage;
//        healthBar.SetHealth(currentHealth);
//        // Updaten des Healthbartextes im UI
//        gamemanager.UpdateCurrentHealthText(currentHealth);
//        if (currentHealth <= 0)
//        {

//            // Spiele Sound ab passiert in der explosion

//            // Spiele Effect ab
//            if (Explosion != null)
//            {
//                Instantiate(Explosion, transform.position, Quaternion.identity);
//            }

//            // Zerstöre Spieler, Teleportiere ihn zurück zur Stadt
//            // Destroy(gameObject, detonationTimer);
//            Debug.Log("Du bist gestorben");
//        }
//    }

//    public void HealDamage(int healthRecover)
//    {
//        currentHealth += healthRecover;

//        if (currentHealth > maxHealth) // falls man mit einen Heiltrank mehr heilen sollte als man hat wird der Wert auf den Max wert gesetzt
//        {
//            currentHealth = maxHealth;
//        }

//        healthBar.SetHealth(currentHealth);
//        // Updaten des Healthbartextes im UI
//        gamemanager.UpdateCurrentHealthText(currentHealth);
//        // Updaten der HeiltrankAnzahl im UI
//        gamemanager.UseHealpotions();
//        // Updaten der HeiltrankSlotsAnzahl im UI
//        gamemanager.UpdateMaxHealpotionsSlots(maxHealpotionsSlots);

//    }

//    void Shoot (float x, float y) // Berechnen der Schussgeschwindigkeit und Spawn
//    {
//        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
//       // bullet.AddComponent<Rigidbody2D>().gravityScale = 0; // fügt dem Schuss einen Rigidbody hinzu, und setzt gravity auf 0
//        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3
//        ((x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed, // if statement in einer zeile, prüfung ob x kleiner ist als 0, falls ja setzte den Wert auf - und führe die Rechnung aus
//        (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
//        0);
//    }
//}