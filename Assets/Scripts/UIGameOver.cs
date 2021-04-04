using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    GameObject restartButton;
    TextMeshProUGUI gameOverText;

    private void Awake()
    {
        gameOverText = GetComponent<TextMeshProUGUI>();
        restartButton = GameObject.Find("Restart Button");

        FindObjectOfType<PlayerMovement>().GetComponent<Health>().OnDied += GameOver_OnDied;
    }

    private void Start()
    {
        gameOverText.enabled = false;
        restartButton.SetActive(false);
        
    }

    private void GameOver_OnDied()
    {
        gameOverText.enabled = true;
        restartButton.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
