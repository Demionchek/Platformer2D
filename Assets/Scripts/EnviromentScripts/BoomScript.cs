using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject Boom;
    [SerializeField] private GameObject[] toDestroy;
    [SerializeField] private Transform BoomPoint;
    private bool is_exploded;

    public delegate void ExplosionEvents();
    public static event ExplosionEvents BlowEvent;

    private void Start()
    {
        is_exploded = false;
        Explosion.SetActive(false);
    }

    private void Update()
    {
        if (is_exploded) 
        {
            Explosion.SetActive(true);
            Destroy(toDestroy[0], 2f);
            Destroy(toDestroy[1], 2f);
            Destroy(toDestroy[2], 2f);
            Destroy(toDestroy[3], 2f);
            is_exploded = false;
        }  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Damageable"))
        {           
            Instantiate(Boom, BoomPoint);
            is_exploded = true;
            BlowEvent();
        }
        
    }
}
