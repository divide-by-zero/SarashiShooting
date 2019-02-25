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
    private Renderer _enemyRenderer;

    private void Awake()
    {
        _variation = Random.Range(0, 256);

        _enemyRenderer = GetComponent<Renderer>();
        _enemyRenderer.material.color = new Color32(255, (byte) (256 - _variation), 0, 128);
        _movingEnemyHP = (int) ((256 - _variation) / 64 + 1);
        //_movingEnemyHP = (int) ((100 / (_variation)) + 1);
        Debug.Log(_movingEnemyHP);
    }

    private void Update()
    {
        transform.LookAt(playerTransform.position);
        transform.Translate(Vector3.forward * Dt * _variation * Speed);
    }

    private void OnCollisionEnter(Collision ot)
    {
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
            _enemyRenderer.material.color = new Color32(255, (byte) (256 - 1 / (_movingEnemyHP - 1) / 100), 0, 128);
            if (_movingEnemyHP < 1)
            {
                enemyNum--;
                Destroy(this.gameObject);
            }
        }
    }
}