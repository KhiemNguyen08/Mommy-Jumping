﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecking : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag(GameTag.Platform.ToString())) return;
        var platformLanded = col.gameObject.GetComponent<Platform>();
        if (!GameManager.Ins || !GameManager.Ins.player || !platformLanded) return;
        GameManager.Ins.player.PlatformLanded = platformLanded;
        GameManager.Ins.player.Jump();
        if (!GameManager.Ins.PlatformLanded(platformLanded.Id))
        {
            int randScore = Random.Range(3, 8);
            GameManager.Ins.AddScore(randScore);
            GameManager.Ins.PlatformLandedIds.Add(platformLanded.Id);
        }
    }
}
