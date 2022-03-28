using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private AnimationClip spitAnim;
    [SerializeField] private float spitForce;
    [SerializeField] private float maxDistance = 4f;
    [SerializeField] private float shootDelay =2f;
    [SerializeField] private bool lookRight = false;
    private Animator animator;
    private int dir = 1;
    private float currTime;
    private bool isDelayComplete;

    public delegate void ShootEvent();
    public static event ShootEvent IsShootingEvent;

    void Start()
    {
        animator = GetComponent<Animator>();
        isDelayComplete = true;
        currTime = Time.time;

    }

    private void Update()
    {
        EnemyDir();
        Timer();
    }

    void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(shootPoint.position, Vector2.right * dir, maxDistance);

        if (hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("Damageable") & isDelayComplete)
            {
                isDelayComplete = false;
                currTime = Time.time;
                animator.SetTrigger("Shoot");
                Invoke("Shooting",spitAnim.length);
            }
        }
    }

    private void Shooting()
    {
        GameObject currentSpit = Instantiate(enemyBullet, shootPoint.position, Quaternion.identity);
        Rigidbody2D currentSpitVelocity = currentSpit.GetComponent<Rigidbody2D>();
        IsShootingEvent();
        currentSpitVelocity.velocity = new Vector2(spitForce * dir, currentSpitVelocity.velocity.y);
    }

    private void Timer()
    {
        if (shootDelay < (Time.time - currTime))
            isDelayComplete = true;
        else
            isDelayComplete = false;
    }

    private void EnemyDir()
    {
        if (!lookRight)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            dir = -1;
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            dir = 1;
        }
    }
}
