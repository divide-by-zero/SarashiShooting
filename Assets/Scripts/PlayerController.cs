using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Timeline;
using static GameManager;

namespace PlayerSpace
{
    public class PlayerController : MonoBehaviour
    {
        private const float MoveSpeed = 20;
        private const float RotateSpeed = 200;
        private GameManager _gameManager;

        private void Awake()
        {
            DontDestroyOnLoad(GameManager.Instance);
        }

        private void Update()
        {
            PlayerMove();
            PlayerRotate();
        }

        private void PlayerMove()
        {
            var speedSub = MoveSpeed * Dt;
            var vX = Input.GetAxis("Horizontal") * speedSub;
            var vZ = Input.GetAxis("Vertical") * speedSub;
            transform.Translate(vX, 0, vZ);
        }

        private void PlayerRotate()
        {
            var mouseInputX = Input.GetAxis("Mouse X");
            transform.RotateAround(gameObject.transform.position, Vector3.up,
                mouseInputX * Time.deltaTime * RotateSpeed);
        }
    }
}