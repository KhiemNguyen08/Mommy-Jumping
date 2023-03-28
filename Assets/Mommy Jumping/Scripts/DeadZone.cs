using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(GameTag.Player.ToString()))
        {
            Destroy(col.gameObject);
            GameManager.Ins.state = GameState.Gameover;
            if (GUIManager.Ins)
                GUIManager.Ins.gameoverDialog.Show(true);
            Debug.Log("gameover");
            if (AudioController.Ins)
                AudioController.Ins.PlaySound(AudioController.Ins.gameover);

        }
        if (col.CompareTag(GameTag.Platform.ToString()))
        {
            Destroy(col.gameObject);
        }
    }
}
