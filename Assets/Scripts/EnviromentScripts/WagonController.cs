using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonController : MonoBehaviour
{
    [SerializeField] private GameObject weel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            if (other.CompareTag("Damageable"))
                weel.GetComponent<WheelJoint2D>().useMotor = true;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("WagonStop"))
            weel.GetComponent<WheelJoint2D>().useMotor = false;
    }
}
