using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject endText;


    private void Start()
    {
        endPanel.SetActive(false);
        endText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Damageable"))
        {
            endPanel.SetActive(true);
            Invoke("ShowText", 1f);
        }
    }

    private void ShowText()
    {
        endText.SetActive(true);
    }
}
