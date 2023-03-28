using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform colectableSpawnPoint;
    int m_id;
    protected Player m_player;
    protected Rigidbody2D m_rb;

    public int Id { get => m_id; set => m_id = value; }

    protected virtual void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
        if (!GameManager.Ins) return;
        m_player = GameManager.Ins.player;
        if (colectableSpawnPoint)
        {
            GameManager.Ins.SpawnColectable(colectableSpawnPoint);
        }
    }
    public virtual void PlatformAction()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
