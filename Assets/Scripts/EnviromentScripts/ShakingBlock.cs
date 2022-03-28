using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingBlock : MonoBehaviour
{
    [SerializeField] private float timerLength;
    [SerializeField] private GameObject block;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    private Animator animator;
    private float currentState;
    private const float stillState = 0;
    private const float shakeState = 1;
    private const float goneState = 2;
    private bool isTimeOut;
    private bool isTimerStarted;
    private float currTime; 

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        sr = block.GetComponent<SpriteRenderer>();
        animator = block.GetComponent<Animator>();
        isTimeOut = true;
        currentState = 0;
    }


    void Update()
    {
        
        switch(currentState)
        {
            case stillState:
                animator.SetBool("isShaking", false);

                Color temp = sr.color;
                temp.a = 1f;
                sr.color = temp;

                bc.isTrigger = false;

                break;

            case shakeState:
                animator.SetBool("isShaking", true);

                if (isTimerStarted)
                {                   
                    currTime = Time.time;
                    isTimerStarted = false;
                }

                Timer();
                break;

            case goneState:

                animator.SetBool("isShaking", false);

                temp = sr.color;
                temp.a = 0f;
                sr.color = temp;

                bc.isTrigger = true;
                Timer();
                break;
        }
    }

    private void Timer()
    {
        
        isTimeOut = false;
        if (timerLength < (Time.time - currTime))
        {
            if (currentState == shakeState)
            {
                currentState = goneState;
                currTime = Time.time;
            }
            else if (currentState == goneState)
                currentState = stillState;
            isTimeOut = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isTimeOut) isTimerStarted = true;
        
        currentState = shakeState;
    }
}
