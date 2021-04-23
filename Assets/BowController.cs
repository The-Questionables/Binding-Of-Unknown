using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowController : MonoBehaviour
{
    [Header("Weapon Movement and Rotation.")]
    [SerializeField] Transform player;
    //[SerializeField] float offset = 1f; // transform the offset into the x offset the child has from the parent (bow from player).
    //[SerializeField] AudioClip projectileSound;
    //[SerializeField] [Range(0, 1)] float projectileSoundVolume = 1f;

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
      //  Vector3 playerToMouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
        //playerToMouseDir.z = 0;
       // transform.position = player.position + (offset * playerToMouseDir.normalized);
    }
}
