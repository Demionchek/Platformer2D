using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScript : MonoBehaviour
{
    private SliderJoint2D slider;
    private JointMotor2D motor2D;

    void Start()
    {
        slider = GetComponent<SliderJoint2D>();
        slider.useMotor = true;
        motor2D.motorSpeed = 1f;
        motor2D.maxMotorTorque = 10000f; 
    }


    void Update()
    {
        if (transform.position.y >= -1.4f)
           motor2D.motorSpeed = -1;

        else if (transform.position.y <= -3.7f)
            motor2D.motorSpeed = 1;

        slider.motor = motor2D;
    }
}
