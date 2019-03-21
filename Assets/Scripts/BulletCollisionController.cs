using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionController : MonoBehaviour
{
    public PlayerController _parentPlayer;

    private void OnParticleCollision(GameObject ot)
    {
        if (ot.CompareTag("ShootingEnemy"))
        {
            GameManager.Instance.shootingEnemyNum--;
            GameManager.Instance.enemyNum--;

            Destroy(ot.gameObject);
        }

        if (ot.CompareTag("Item"))
        {
            Destroy(ot.gameObject);
            if (_parentPlayer != null)
            {
                _parentPlayer.bulletNum++;
            }
        }
    }
}