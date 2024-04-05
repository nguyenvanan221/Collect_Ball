using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject winloseScreen;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text resultText;

    public static UIManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        Time.timeScale = 0f;
        winloseScreen.SetActive(false);
    }

    void Update()
    {
        scoreText.text = "Score: " + GameManager.Score.ToString();
    }

    public void ResultGame(string result)
    {
        winloseScreen.SetActive(true);
        resultText.text = result;
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
