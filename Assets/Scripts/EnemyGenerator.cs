using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject movingEnemy;
    [SerializeField] private GameObject shootingEnemy;
    [SerializeField] private new Renderer renderer;

    private float _width;

    private void Awake()
    {
        _width = renderer.bounds.size.x / 2;
        for (var i = 0; i < enemyNum; i++)
        {
            var roll = Random.Range(1, 3);
            var subPosition = new Vector3(Random.Range(-_width, _width), 10, Random.Range(-_width, _width));

            switch (roll)
            {
                case 1:
                    Instantiate(movingEnemy, subPosition, Quaternion.identity);
                    break;
                case 2:
                    shootingEnemyNum++;
                    Instantiate(shootingEnemy, subPosition, Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
    }
}