using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.Timeline;
using static GameManager;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    public int _playerHP = 1000;

    private const float RotateSpeed = 200;
    private const int BulletLifeTime = 3;

    private GameManager _gameManager;
    [SerializeField] private ParticleSystem bullet;

    public static Transform playerTransform;

    private static PlayerController _playerInstance = null;


    public static PlayerController PlayerInstance
    {
        get { return _playerInstance; }
    }

    private void Awake()
    {
        if (_playerInstance == null)
        {
            _playerInstance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(GameManager.Instance);
        _gameManager = GameManager.Instance;

        playerTransform = transform;

        _gameManager.OnClicked.Subscribe(val => { ShootBullet(val); });

        _gameManager.IsMoving.Subscribe(moveV => { transform.Translate(moveV); });

        _gameManager.IsRotating.Subscribe(rotateT =>
        {
            transform.RotateAround(gameObject.transform.position, Vector3.up,
                rotateT * Dt * RotateSpeed);
        });
    }


    private void ShootBullet(int n)
    {
        var transform1 = transform;
        var rotation = transform1.rotation;
        var subBullet = Instantiate(bullet, transform1.position + rotation * Vector3.forward * 1.5f,
            rotation);
        subBullet.emission.SetBurst(0, new ParticleSystem.Burst(0, n));
        Destroy(subBullet.gameObject, BulletLifeTime);
    }

    private void OnCollisionEnter(Collision ot)
    {
        if (ot.gameObject.CompareTag("Item"))
        {
            Destroy(ot.gameObject);
            bulletNum++;
        }
    }
}