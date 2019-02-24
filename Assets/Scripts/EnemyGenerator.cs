using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private const int EnemyNum = 80;

    [SerializeField] private GameObject _MovingEnemy;
    [SerializeField] private GameObject _ShootingEnemy;
    [SerializeField] private Renderer _renderer;

    private float _width;

    private void Awake()
    {
        _width = _renderer.bounds.size.x / 2;
        for (var i = 0; i < EnemyNum; i++)
        {
            var roll = Random.Range(1, 3);
            var subPosition = new Vector3(Random.Range(-_width, _width), 10, Random.Range(-_width, _width));

            switch (roll)
            {
                case 1:
                    Instantiate(_MovingEnemy, subPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(_ShootingEnemy, subPosition, Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
    }
}