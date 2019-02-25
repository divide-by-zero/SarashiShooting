using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class EnemyShotScript : MonoBehaviour
{
    private bool _flag = true;

    private void Awake()
    {
        StartCoroutine(nameof(ShotFunction));
    }

    public IEnumerator ShotFunction()
    {
        while (_flag)
        {
            transform.LookAt(PlayerController.playerTransform.position);
            yield return new WaitForSeconds(Instance.IntervalCulc() * Random.Range(0.8f, 1.4f));
        }

        yield break;
    }

    private void OnDestroy()
    {
        _flag = false;
    }
}