using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using static PlayerController;

public class EnemyMoveScript : MonoBehaviour
{
    private int _variation;
    private const float Speed = 0.05f;
    private const float DamageC = 500;
    private int _movingEnemyHP;

    private void Awake()
    {
        _variation = Random.Range(0, 256);

        GetComponent<Renderer>().material.color = new Color32(255, (byte) (256 - _variation), 0, 128);
        _movingEnemyHP = (int) ((_variation / 50) + 1);
    }

    private void Update()
    {
        transform.LookAt(playerTransform.position);
        transform.Translate(Vector3.forward * Dt * _variation * Speed);
    }

    private void OnCollisionEnter(Collision ot)
    {
        Debug.Log(ot.gameObject.tag);
        if (ot.gameObject.CompareTag("Player"))
        {
            PlayerInstance._playerHP -= (int) (DamageC / _variation);
            Destroy(this.gameObject);
        }
    }

    private void OnParticleCollision(GameObject ot)
    {
        if (ot.gameObject.CompareTag("PlayerBullet"))
        {
            _movingEnemyHP--;
            Debug.Log(_movingEnemyHP);
            if (_movingEnemyHP < 1)
            {
                enemyNum--;
                Destroy(this.gameObject);
            }
        }
    }
}