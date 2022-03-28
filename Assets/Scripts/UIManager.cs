using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject FailedPanel;
    [SerializeField] private GameObject Player;
    [SerializeField] private Slider healthBar;
    private float playersHealth;
    private bool isPlayerAlive;

    void Start()
    {
        Time.timeScale = 1f;
        FailedPanel.SetActive(false);
        healthBar.minValue = 0;
        healthBar.maxValue = Player.GetComponent<Healths>().MaxHealth;       
    }

    void Update()
    {
        HealthBar();

        if (!isPlayerAlive)
        {
            Invoke("OnCharacterDied", 2f);
        }
    }

    private void HealthBar()
    {
        if (Player != null)
        {
            isPlayerAlive = Player.GetComponent<Healths>().IsAlive;
            playersHealth = Player.GetComponent<Healths>().CurrHealth;
            healthBar.value = playersHealth;
        }
    }

    private void OnCharacterDied()
    {
        Time.timeScale = 0f;
        FailedPanel.SetActive(true);
    }

    public void OnRestartClick()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneIndex);
    }
}
