using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class IconMovement : MonoBehaviour
{

    [Header("Icon attributes:")]
    public float moveSpeed = 1f;

    [Header("Statistics:")]
    public Vector2 movement; // zwischenspeicherung von bewegungswerten
    public Rigidbody2D iconRb;
    /*
    void Start()
    {
        iconRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement = moveInput.normalized * moveSpeed;
    }

    private void FixedUpdate()
    {
        iconRb.MovePosition(iconRb.position + movement * Time.fixedDeltaTime);
    }
    */
}
