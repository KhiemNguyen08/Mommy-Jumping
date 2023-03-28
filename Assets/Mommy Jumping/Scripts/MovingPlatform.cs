using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Platform
{
    public float moveSpeed;
    bool m_canMoveLeft;
    bool m_canMoveright;

    protected override void Start()
    {
        base.Start();
        float randIdx = Random.Range(0f, 1f);
        if(randIdx <= 0.5)
        {
            m_canMoveLeft = true;
            m_canMoveright = false;
        }else if (randIdx > 0.5){
            m_canMoveright = true;
            m_canMoveLeft = false;
        }
    }
    private void FixedUpdate()
    {
        float curSpeed = 0f;
        if (m_canMoveLeft)
        {
             curSpeed = -moveSpeed;
        } else if (m_canMoveright)
        {
             curSpeed = moveSpeed;
        }
        m_rb.velocity = new Vector2(curSpeed, 0f);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GameTag.Leftcomer.ToString())){
            m_canMoveLeft = false;
            m_canMoveright = true;
        }else if (col.CompareTag(GameTag.Rightcomer.ToString()))
        {
            m_canMoveright = false;
            m_canMoveLeft = true;
        }
    }
}
