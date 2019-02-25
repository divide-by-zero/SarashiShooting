using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class EnemyBulletCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject ot)
    {
        if (ot.CompareTag("Player") && bulletNum > 1)
        {
            bulletNum--;
        }
    }
}