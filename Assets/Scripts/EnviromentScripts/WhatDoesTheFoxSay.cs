using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WhatDoesTheFoxSay : MonoBehaviour
{
    [SerializeField] private TextMesh WhatSheSays;
    [SerializeField] private TextMesh FinalMonologue;
    [SerializeField] private GameObject SayBckgrnd;
    [SerializeField] private GameObject TimeLine;
    [SerializeField] private GameObject DelObj;
    [SerializeField] private bool isTimelineUsed;
    [SerializeField] private int toneDelay;
    private string text;
    private bool wasActivated;
    private int counter = 0;

    public delegate void SayEvents();
    public static event SayEvents Talk;

    void Start()
    {
        if (isTimelineUsed)
            TimeLine.SetActive(false);
        text = WhatSheSays.text;
        WhatSheSays.text = "";
        SayBckgrnd.SetActive(false);
    }

    private void Erase()
    {
        StopAllCoroutines();
        WhatSheSays.text = "";
        SayBckgrnd.SetActive(false);
    }

    IEnumerator FoxSaysCorutine()
    {
        foreach (char abc in text)
        {
            WhatSheSays.text += abc;
            if (counter == toneDelay)
            {
                Talk();
                counter = 0;
            }
            counter++;

            yield return new WaitForSeconds(0.03f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable") && !wasActivated)
        {
            if (isTimelineUsed)
                TimeLine.SetActive(true);
            StartCoroutine(FoxSaysCorutine());
            wasActivated = true;
            Invoke("Erase", 13f);
            SayBckgrnd.SetActive(true);
        }
    }

    public void OffPreviousMonolog()
    {
        if (DelObj != null)
            DelObj.SetActive(false);
    }

    public void SceneManage()
    {
        SceneManager.LoadScene(1);
    }
}
