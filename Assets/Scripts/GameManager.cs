using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
            paddle.GetComponent<PaddleController>().PaddleDestroy();
            playerCount -= 1;

            if (playerCount == 1)
            {
                //Game Over
            }
        }
    }
}
