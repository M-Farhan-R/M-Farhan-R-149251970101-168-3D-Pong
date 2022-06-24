using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverControl : MonoBehaviour
{
    public Text playerWinTxt;

    public List<Color> pColor;

    void Start()
    {

    }

    public void SetPlayerWinText(string player, int n)
    {
        playerWinTxt.text = player + n.ToString() + " Win !!!";
        for (int i = 0; i < pColor.Count; i++)
        {
            if (i == n - 1)
            {
                playerWinTxt.color = pColor[i];
            }
        }
    }
}
