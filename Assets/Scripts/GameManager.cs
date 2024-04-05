using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const int WINNINGSCORE = 10;
    public static int Score { get; private set; }

    public static GameManager instance;

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

        Score = 0;
    }

    private void Update()
    {
        if (Score >= WINNINGSCORE)
        {
            UIManager.instance.ResultGame("YOU WIN");
        }
    }

    public void IncreScore(int score)
    {
        Score += score;
    }

    
}
