using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionContoroller : MonoBehaviour
{
    private void OnParticleCollision(GameObject ot)
    {
        if (ot.CompareTag("MovingEnemy"))
        {
            Destroy(ot.gameObject);
        }
    }
}