using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCrack : MonoBehaviour
{
    [SerializeField] private GameObject CrackTilemap;
    private int counter = 0;

    public delegate void CrackEvents();
    public static event CrackEvents Crack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable") & counter == 0)
        {
            Crack();
            Destroy(CrackTilemap, 0.5f);
            counter++;
        }
    }

}
