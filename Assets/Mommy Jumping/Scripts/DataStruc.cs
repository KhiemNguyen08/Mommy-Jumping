using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Starting,
    Playing,
    Gameover
}
public enum GameTag
{
    Platform,
    Player,
    Leftcomer,
    Rightcomer,
    Conlecttable
}
public enum PresfKey
{
    BestScore
}
[System.Serializable]
public class ColectableItem
{
    public Colectable colectablePrefabs;
    [Range(0f, 1f)]
    public float spawnRate;
}
