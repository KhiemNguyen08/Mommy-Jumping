using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player player;
    public GameState state;
    public int starttingPlatform;
    public float xSpawnOffset;
    public float minYspawnPos;
    public float maxYspawnPos;
    public Platform[] platformPrefabs;
    public ColectableItem[] colectableItems;

    Platform m_lastPlatformSpawned;
    List<int> m_platformLandedIds;
    int m_score;
    float m_halfCamSizeX;

    public Platform LastPlatformSpawned { get => m_lastPlatformSpawned; set => m_lastPlatformSpawned = value; }
    public List<int> PlatformLandedIds { get => m_platformLandedIds; set => m_platformLandedIds = value; }
    public int Score { get => m_score;}

    public override void Awake()
    {
        MakeSingleton(false);
        m_platformLandedIds = new List<int>();
        m_halfCamSizeX = Helper.Get2DCamSize().x / 2;
    }
    public override void Start()
    {
        base.Start();
        state = GameState.Starting;
        Invoke("PlatformInit", 0.5f);
    }
    public void Playgame()
    {
        if (AudioController.Ins)
            AudioController.Ins.PlayBackgroundMusic();

        if (GUIManager.Ins)
        {
            GUIManager.Ins.ShowGamePlay(true);
        }
        Invoke("PlaygameIvk", 1f);
    }
    private void PlaygameIvk()
    {
        state = GameState.Playing;
        if (player)
            player.Jump();
    }
    void PlatformInit()
    {
        m_lastPlatformSpawned = player.PlatformLanded;
        for (int i = 0; i < starttingPlatform; i++)
        {
            SpawnPlatform();
        }
    }
    public bool PlatformLanded(int id)
    {
        if (PlatformLandedIds == null || PlatformLandedIds.Count <= 0) return false;
        return PlatformLandedIds.Contains(id);
    }

   public void SpawnPlatform()
    {
        if (!player || platformPrefabs == null || platformPrefabs.Length <= 0) return;
        float spawnPosX = Random.Range(
            -(m_halfCamSizeX - xSpawnOffset), (m_halfCamSizeX - xSpawnOffset));
        float disBeetweenPlat = Random.Range(minYspawnPos, maxYspawnPos);
        float spawnPosY = m_lastPlatformSpawned.transform.position.y + disBeetweenPlat;
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY);
        int ranIdx = Random.Range(0, platformPrefabs.Length);
        var platformPrefab = platformPrefabs[ranIdx];
        if (!platformPrefab) return;
        var platformClone = Instantiate(platformPrefab, spawnPos, Quaternion.identity);
        platformClone.Id = m_lastPlatformSpawned.Id + 1;
        m_lastPlatformSpawned = platformClone;
    }
    public void SpawnColectable(Transform spawnPoint)
    {
        if (colectableItems == null || colectableItems.Length <= 0 || state != GameState.Playing) return;
        int ranIdx = Random.Range(0, colectableItems.Length);
        var colectableItem = colectableItems[ranIdx];
        if (colectableItem == null) return;
        float rand = Random.Range(0f, 1f);
        if(rand <= colectableItem.spawnRate && colectableItem.colectablePrefabs)
        {
            var cClone = Instantiate(colectableItem.colectablePrefabs, spawnPoint.position, Quaternion.identity);
            cClone.transform.SetParent(spawnPoint);
        }
    }
    public void AddScore(int scoreToAdd)
    {
        if (state != GameState.Playing) return;
        m_score += scoreToAdd;
        Prefs.bestScore = m_score;
        if (GUIManager.Ins)
            GUIManager.Ins.UpdateScore(m_score);
        //if (AudioController.Ins)
        //    AudioController.Ins.PlaySound(AudioController.Ins.gotCollectable);
    }
}
