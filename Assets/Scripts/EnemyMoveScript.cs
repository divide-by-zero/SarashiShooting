using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using static PlayerController;
using UnityEngine.SceneManagement;

public class EnemyMoveScript : MonoBehaviour
{
    private int _variation;
    private const float Speed = 0.05f;
    private const float DamageC = 500;
    private int _movingEnemyHP;
    private Renderer _enemyRenderer;
    private AudioSource _dAu;

    private void Awake()
    {
        _variation = Random.Range(1, 256);

        _enemyRenderer = GetComponent<Renderer>();
        _enemyRenderer.material.color = new Color32(255, (byte) (256 - _variation), 0, 128);
        _movingEnemyHP = (int) ((256 - _variation) / 64 + 1);
        _dAu = GetComponent<AudioSource>();
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
            _dAu.Play();
            damageNum++;
            enemyNum--;
            if (enemyNum - shootingEnemyNum == 0)
            {
                SceneManager.LoadScene("Finish");
            }

            PlayerInstance.playerHp -= (int) (DamageC / _variation);
            Destroy(this.gameObject, 0.4f);
        }
    }

    private void OnParticleCollision(GameObject ot)
    {
        if (ot.gameObject.CompareTag("PlayerBullet"))
        {
            _movingEnemyHP--;
            if (_movingEnemyHP < 1)
            {
                enemyNum--;
                if (enemyNum - shootingEnemyNum == 0)
                {
                    SceneManager.LoadScene("Finish");
                }

                Destroy(this.gameObject);
            }

            _enemyRenderer.material.color = new Color32(255, (byte) (256 - 64 * (_movingEnemyHP - 1)), 0, 128);
        }
    }
}