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

    private void Awake()
    {
        _variation = Random.Range(0, 256);

        GetComponent<Renderer>().material.color = new Color32(255, (byte) (256 - _variation), 0, 128);
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
            Debug.Log((int) (DamageC / _variation));
            Destroy(this.gameObject);
        }
    }
}