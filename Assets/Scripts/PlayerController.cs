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
        private GameManager _gameManager;

        private void Awake()
        {
            DontDestroyOnLoad(GameManager.Instance);
            _gameManager = GameManager.Instance;

            _gameManager.OnClicked.Subscribe(val => { Debug.Log("orala"); });

            _gameManager.IsMoving.Subscribe(moveV => { transform.Translate(moveV); });

            _gameManager.IsRotating.Subscribe(rotateT =>
            {
                transform.RotateAround(gameObject.transform.position, Vector3.up,
                    rotateT * Dt * RotateSpeed);
            });
        }
    }
}