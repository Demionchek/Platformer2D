using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireForce;
    [SerializeField] private Transform FirePoint;


    

    public void Shoot(float direction)
    {
        GameObject currentBullet = Instantiate(bullet, FirePoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        if (direction > 0)
            currentBulletVelocity.velocity = new Vector2(fireForce * 1, currentBulletVelocity.velocity.y);
        else
            currentBulletVelocity.velocity = new Vector2(fireForce * -1, currentBulletVelocity.velocity.y);

    }
}
