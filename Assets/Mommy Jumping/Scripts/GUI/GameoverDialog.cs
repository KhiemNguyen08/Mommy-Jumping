using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverDialog : Dialog
{
    public Text totalScoreTExt;
    public Text bestScoreTxt;
    public override void Show(bool isShow)
    {
        base.Show(isShow);
        if (totalScoreTExt && GameManager.Ins)
            totalScoreTExt.text = GameManager.Ins.Score.ToString();
        if (bestScoreTxt)
            bestScoreTxt.text = Prefs.bestScore.ToString();
    }
    public void Continue()
    {
        SceneManager.sceneLoaded += OnSceneLoadedEvent;
        if (SceneController.Ins)
            SceneController.Ins.LoadCurrentScene();
    }
    private void OnSceneLoadedEvent(Scene scene, LoadSceneMode mode)
    {
        if (GameManager.Ins)
            GameManager.Ins.Playgame();
        SceneManager.sceneLoaded -= OnSceneLoadedEvent;

    }
}
