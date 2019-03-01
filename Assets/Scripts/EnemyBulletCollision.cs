using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject ot)
    {
        if (ot.CompareTag("Player") && GameManager.Instance.bulletNum > 1)
        {
            GameManager.Instance.bulletNum--;
        }
    }
}