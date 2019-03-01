using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotScript : MonoBehaviour
{
    private bool _flag = true;
    private AudioSource _au;

    [SerializeField]
    private GameObject enemyBullet;

    private void Start()
    {
        StartCoroutine(nameof(IntervalShot));
        _au = GetComponent<AudioSource>();
    }

    private IEnumerator IntervalShot()
    {
        while (_flag)
        {
            transform.LookAt(PlayerController.playerTransform.position);
            yield return new WaitForSeconds(GameManager.Instance.IntervalCulc() * Random.Range(0.8f, 1.4f));
            ShotFunction();
        }
    }

    private void ShotFunction()
    {
        var transform1 = transform;
        var rotation = transform1.rotation;
        var position = transform1.position;
        var subBullet = Instantiate(enemyBullet, position + rotation * Vector3.forward * 1.5f,rotation);
        Destroy(subBullet.gameObject, 3);
        _au.volume = 200 / (PlayerController.playerTransform.position - position).magnitude;
        _au.Play();
    }

    private void OnDestroy()
    {
        _flag = false;
    }
}