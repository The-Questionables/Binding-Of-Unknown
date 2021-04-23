using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowController : MonoBehaviour
{
    [Header("Weapon Movement and Rotation.")]
    [SerializeField] Transform player;
    [SerializeField] float offset = 1f; // transform the offset into the x offset the child has from the parent (bow from player).

    [Header("Fire projectile.")]
    //[SerializeField] AudioClip projectileSound;
    //[SerializeField] [Range(0, 1)] float projectileSoundVolume = 1f;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform arrowTrigger;
    [SerializeField] float cooldownDuration = 1f;

    private bool canShoot = true;
    private GameObject projectileParent;
    private const string PROJECTILE_PARENT_NAME = "Projectiles";

    [Header("Ammunition.")]
    [SerializeField] GameObject regularProjectilePrefab;
    [SerializeField] Sprite regularArrow;

    private Sprite currentProjectile;
    private GameObject testProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        CreateProjectileParent();
        GetCurrentProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        BowRotationAndMovement();
    }

    private void BowRotationAndMovement()
    {
        // Bow Rotation around its own pivot point.
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Bow Rotation around the player's pivot point.
        Vector3 playerToMouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
        playerToMouseDir.z = 0;
        transform.position = player.position + (offset * playerToMouseDir.normalized);
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    public void ShotProjectile()
    {
        if (canShoot)
        {
           // AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundVolume);

                GameObject arrow = Instantiate(projectilePrefab, arrowTrigger.position, arrowTrigger.rotation) as GameObject;
                arrow.transform.parent = projectileParent.transform;

                StartCoroutine(ApplyCooldown());
            
        }
    }

    IEnumerator ApplyCooldown()
    {
        canShoot = false;

        yield return new WaitForSeconds(cooldownDuration);

        canShoot = true;
    }

    public void UpdateCooldownDuration(float newCooldownDuration)
    {
        cooldownDuration = newCooldownDuration;
    }

    public Sprite GetCurrentProjectile()
    {
        string currentProjectileName = projectilePrefab.name;

        if (currentProjectileName == "Regular Arrow")
        {
            currentProjectile = regularArrow;
        }
        return currentProjectile;
    }

    public void SwapProjectilePrefab(GameObject newProjectilePrefab)
    {
        projectilePrefab = newProjectilePrefab;
        GetCurrentProjectile();

    }
}
