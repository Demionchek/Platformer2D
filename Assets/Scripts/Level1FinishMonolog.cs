using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1FinishMonolog : MonoBehaviour
{
    [SerializeField] private TextMesh WhatSheSays;
    [SerializeField] private GameObject SayBckgrnd;

    private string text;

    void Start()
    {
        text = WhatSheSays.text;
        WhatSheSays.text = "";
        StartCoroutine(FoxSaysCorutine());
        Invoke("Erase", 13f);
    }

    IEnumerator FoxSaysCorutine()
    {
        foreach (char abc in text)
        {
            WhatSheSays.text += abc;
            yield return new WaitForSeconds(0.06f);
        }
    }

    private void Erase()
    {
        StopAllCoroutines();
        WhatSheSays.text = "";
        SayBckgrnd.SetActive(false);
    }


}
