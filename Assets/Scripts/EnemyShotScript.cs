using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class EnemyShotScript : MonoBehaviour
{
    private bool _flag = true;

    private void Start()
    {
        StartCoroutine(nameof(IntervalShot));
    }

    private IEnumerator IntervalShot()
    {
        while (_flag)
        {
            transform.LookAt(PlayerController.playerTransform.position);
            ShotFunction();
            yield return new WaitForSeconds(Instance.IntervalCulc() * Random.Range(0.8f, 1.4f));
        }
    }

    private void ShotFunction()
    {
        var transform1 = transform;
        var rotation = transform1.rotation;
        var subBullet = Instantiate(enemyBullet, transform1.position + rotation * Vector3.forward * 1.5f,
            rotation);
        Destroy(subBullet.gameObject, 3);
    }

    private void OnDestroy()
    {
        _flag = false;
    }
}