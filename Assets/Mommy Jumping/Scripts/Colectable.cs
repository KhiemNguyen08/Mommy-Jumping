using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectable : MonoBehaviour
{
    public int scoreBonus;
    public GameObject exp;

    public void Triger()
    {
        if (exp)
        {
            Instantiate(exp, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
        if (GameManager.Ins)
        {

            GameManager.Ins.AddScore(scoreBonus);
        }
        if (AudioController.Ins)
            AudioController.Ins.PlaySound(AudioController.Ins.gotCollectable);

    }
}
