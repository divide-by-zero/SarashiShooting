﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class BulletCollisionContoroller : MonoBehaviour
{
    private void OnParticleCollision(GameObject ot)
    {
        if (ot.CompareTag("MovingEnemy"))
        {
            enemyNum--;
            Destroy(ot.gameObject);
        }

        if (ot.CompareTag("ShootingEnemy"))
        {
            shootingEnemyNum--;
            enemyNum--;
            Destroy(ot.gameObject);
        }

        if (ot.CompareTag("Item"))
        {
            Destroy(ot.gameObject);
            bulletNum++;
        }
    }
}