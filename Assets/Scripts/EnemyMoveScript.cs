using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class EnemyMoveScript : MonoBehaviour
{
    private int _variation;
    private const float Speed = 0.05f;

    private void Awake()
    {
        _variation = Random.Range(0, 256);

        GetComponent<Renderer>().material.color = new Color32(255, (byte) (256 - _variation), 0, 128);
    }

    private void Update()
    {
        transform.LookAt(PlayerController.playerTransform.position);
        transform.Translate(Vector3.forward * Dt * _variation * Speed);
    }
}