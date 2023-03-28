using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : Singleton<GUIManager>
{
    public GameObject mainmenu;
    public GameObject gamePlay;
    public Text scoreText;
    public Dialog pauseDialog;
    public Dialog gameoverDialog;
    public override void Awake()
    {
        MakeSingleton(false);
    }
    public void ShowGamePlay(bool ishow)
    {
        if (gamePlay)
            gamePlay.SetActive(ishow);
        if (mainmenu)
            mainmenu.SetActive(!ishow);
    }
    public void UpdateScore(int score)
    {
        if (scoreText)
            scoreText.text ="Score: "+ score.ToString();
    }
}

