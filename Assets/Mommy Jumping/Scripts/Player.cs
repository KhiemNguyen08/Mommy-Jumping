using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public float moveSpeed;
    Platform m_platformLanded;
    float m_movingLimitX;

    Rigidbody2D m_rb;

    public Platform PlatformLanded { get => m_platformLanded; set => m_platformLanded = value; }
    public float MovingLimitX { get => m_movingLimitX; }
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MovingHandle();
    }
    public void Jump()
    {
        if (!GameManager.Ins || GameManager.Ins.state != GameState.Playing) return;
        if (!m_rb || m_rb.velocity.y > 0 || !m_platformLanded ) return;
        m_rb.velocity = new Vector2(m_rb.velocity.x, jumpForce);
        if(m_platformLanded is BreakablePlatform)
        {
            m_platformLanded.PlatformAction();
        }
        if (AudioController.Ins)
            AudioController.Ins.PlaySound(AudioController.Ins.jump);

    }
    private void MovingHandle()
    {
        if (!GamePadController.Ins || !GameManager.Ins || !m_rb || GameManager.Ins.state != GameState.Playing) return;
        if (GamePadController.Ins.CanMoveLeft)
        {
            m_rb.velocity = new Vector2(-moveSpeed, m_rb.velocity.y);
        }else if (GamePadController.Ins.CanMoveRight)
        {
            m_rb.velocity = new Vector2(moveSpeed, m_rb.velocity.y);
        }
        else
        {
            m_rb.velocity = new Vector2(0, m_rb.velocity.y);
        }
        m_movingLimitX = Helper.Get2DCamSize().x / 2;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GameTag.Conlecttable.ToString())){
            var colectable = col.GetComponent<Colectable>();
            if (!colectable) return;
            colectable.Triger();
        }
    }
}
