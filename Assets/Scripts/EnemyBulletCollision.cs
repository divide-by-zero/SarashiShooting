using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject ot)
    {
        if (ot.CompareTag("Player"))
        {
            var player = ot.GetComponent<PlayerController>();

            if (player && player.bulletNum > 1)
            {
                player.bulletNum--;
            }
        }
    }
}