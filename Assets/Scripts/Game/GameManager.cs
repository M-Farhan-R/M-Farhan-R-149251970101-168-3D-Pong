using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallManager ballManager;
    public GameObject gameOverPanel;
    public List<GameObject> walls, paddles;
    public int scoreP1, scoreP2, scoreP3, scoreP4, playerCount; 
    public int maxScore;

    void Start()
    {
        playerCount = 4;
    }

    public void AddScoreP1()
    {
        scoreP1 += 1;
        GameOverState(scoreP1, walls[0], paddles[0]);
    }

    public void AddScoreP2()
    {
        scoreP2 += 1;
        GameOverState(scoreP2, walls[1], paddles[1]);
    }

    public void AddScoreP3()
    {
        scoreP3 += 1;
        GameOverState(scoreP3, walls[2], paddles[2]);
    }

    public void AddScoreP4()
    {
        scoreP4 += 1;
        GameOverState(scoreP4, walls[3], paddles[3]);
    }

    void GameOverState(int score, GameObject wall, GameObject paddle)
    {
        if (score >= maxScore)
        {
            wall.GetComponent<WallTrigger>().TriggerOff();
            paddle.GetComponent<PaddleController>().PaddleDeactive();
            playerCount -= 1;

            if (playerCount == 1)
            {
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
                for (int i = 0; i < paddles.Count; i++)
                {
                    if (paddles[i].activeInHierarchy)
                    {
                        gameOverPanel.GetComponent<GameOverControl>().SetPlayerWinText("Player ", i + 1);
                    }
                }
            }
        }
    }

    public void ResetGame()
    {
        for (int i = 0; i < paddles.Count; i++)
        {
            walls[i].GetComponent<WallTrigger>().TriggerOn();
            paddles[i].GetComponent<PaddleController>().PaddleActive();
            paddles[i].GetComponent<PaddleController>().ResetPosition();
        }
        ballManager.RemoveAllBall();
        ballManager.timer = 0;
        scoreP1 = 0;
        scoreP2 = 0;
        scoreP3 = 0;
        scoreP4 = 0;
        playerCount = 4;
    }
}
