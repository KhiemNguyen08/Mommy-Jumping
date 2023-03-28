using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{
    public static int bestScore
    {
        set
        {
            int oldScore = PlayerPrefs.GetInt(PresfKey.BestScore.ToString(), 0);
            if(value> oldScore || oldScore ==0)
            {
                PlayerPrefs.SetInt(PresfKey.BestScore.ToString(), value);
            }
        }
        get => PlayerPrefs.GetInt(PresfKey.BestScore.ToString(), 0);
    }
}
