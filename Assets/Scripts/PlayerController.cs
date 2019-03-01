using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.Timeline;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    private readonly float MoveSpeed = 20;

    public static Transform playerTransform;

    public int playerHp = 1000;

    private const float RotateSpeed = 200;
    private const int BulletLifeTime = 3;

    private AudioSource _pAudioSource;

    public int bulletNum = 1;

    private GameManager _gameManager;
    [SerializeField] private ParticleSystem bullet;


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

        playerTransform = transform;

        _pAudioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet(bulletNum);
        }

        var subV = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (subV.magnitude > 0)
        {
            var speedSub = MoveSpeed * Time.deltaTime;
            transform.Translate(subV * speedSub);
        }

        var mouseInputX = Input.GetAxis("Mouse X");
        if (Mathf.Abs(mouseInputX) > 0)
        {
            transform.RotateAround(gameObject.transform.position, Vector3.up,mouseInputX* Time.deltaTime * RotateSpeed);
        }
    }

    private void ShootBullet(int n)
    {
        var transform1 = transform;
        var rotation = transform1.rotation;
        var subBullet = Instantiate(bullet, transform1.position + rotation * Vector3.forward * 1.5f,
            rotation);
        subBullet.emission.SetBurst(0, new ParticleSystem.Burst(0, n));
        Destroy(subBullet.gameObject, BulletLifeTime);
        _pAudioSource.Play();
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