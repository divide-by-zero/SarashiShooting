using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotScript : MonoBehaviour
{
    private AudioSource _au;

    [SerializeField]
    private GameObject enemyBullet;

    private GameObject _targetPlayer;

    private void Start()
    {
        _au = GetComponent<AudioSource>();
        _targetPlayer = GameObject.FindWithTag("Player");   //TODO 考えもの
        if (_targetPlayer != null)
        {
            StartCoroutine(nameof(IntervalShot));
        }
    }

    private IEnumerator IntervalShot()
    {
        while (true)
        {
            transform.LookAt(_targetPlayer.transform.position);
            yield return new WaitForSeconds(GameManager.Instance.IntervalCulc() * Random.Range(0.8f, 1.4f));
            ShotFunction();
        }
    }

    private void ShotFunction()
    {
        var rotation = transform.rotation;
        var position = transform.position;
        var subBullet = Instantiate(enemyBullet, position + rotation * Vector3.forward * 1.5f,rotation);
        Destroy(subBullet.gameObject, 3);
        _au.volume = 200 / (_targetPlayer.transform.position - position).magnitude;
        _au.Play();
    }
}