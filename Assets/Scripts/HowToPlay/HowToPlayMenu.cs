using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayMenu : MonoBehaviour
{
    public List<GameObject> pages;
    private int pageNumber;

    void Awake()
    {
        pageNumber = 1;
    }
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void NextButton()
    {
        pages[pageNumber - 1].SetActive(false);
        pages[pageNumber].SetActive(true);
        pageNumber++;
    }

    public void PrevButton()
    {
        pages[pageNumber - 1].SetActive(false);
        pages[pageNumber - 2].SetActive(true);
        pageNumber--;
    }
}
