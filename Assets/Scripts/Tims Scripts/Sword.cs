using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Sword : MonoBehaviour
{
    public GameObject Oberobjekt;
    public float knockbackPower = 25;
    private KeyCode Attack = KeyCode.Mouse0;
    private GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(Attack))
        {
            Oberobjekt.transform.rotation = Quaternion.AngleAxis((Oberobjekt.transform.rotation.z), Vector3.forward);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Slime_Const.Tag_Enemy))
        {
            other.gameObject.GetComponent<EnemyStandart>().TakeDamage(gm.swordDamage);

        }
    }
}
