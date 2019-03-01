using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionController : MonoBehaviour
{
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
            GameManager.Instance.bulletNum++;
        }
    }
}