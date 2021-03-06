using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            collision.gameObject.GetComponent<Healths>().TakeDamage(damage);
        }
        
        if(!collision.CompareTag("CameraCollider") && !collision.CompareTag("EnemyState"))
        Destroy(gameObject);
    }
}
