using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreP1, scoreP2, scoreP3, scoreP4;
    public GameManager gameManager;
    
    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        scoreP1.text = gameManager.scoreP1.ToString().Trim();
        scoreP2.text = gameManager.scoreP2.ToString().Trim();
        scoreP3.text = gameManager.scoreP3.ToString().Trim();
        scoreP4.text = gameManager.scoreP4.ToString().Trim();
    }
}
