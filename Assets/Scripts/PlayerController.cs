using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniRx;
using UnityEngine;
using UnityEngine.Timeline;
using static GameManager;
using Debug = UnityEngine.Debug;

namespace PlayerSpace
{
    public class PlayerController : MonoBehaviour
    {
        private const float RotateSpeed = 200;
        private const int BulletLifeTime = 3;

        private GameManager _gameManager;
        [SerializeField] private ParticleSystem bullet;

        private void Awake()
        {
            DontDestroyOnLoad(GameManager.Instance);
            _gameManager = GameManager.Instance;

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
    }
}