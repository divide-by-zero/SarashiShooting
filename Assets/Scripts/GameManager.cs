using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Async;


public class GameManager : MonoBehaviour
{
    private const float MoveSpeed = 20;

    public static float Dt;
    public ReactiveProperty<int> clickProperty = new ReactiveProperty<int>(0);

    private Subject<int> _clickSubject = new Subject<int>();
    private Subject<Vector3> _axisSubject = new Subject<Vector3>();
    private Subject<float> _rotateSubject = new Subject<float>();

    public static int bulletNum = 1;
    public static int shootingEnemyNum = 0;
    public static int enemyNum = 80;

    public static GameObject enemyBullet;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = new GameObject(typeof(GameManager).Name);
                _instance = obj.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    public IObservable<int> OnClicked
    {
        get { return _clickSubject; }
    }

    public IObservable<Vector3> IsMoving
    {
        get { return _axisSubject; }
    }

    public IObservable<float> IsRotating
    {
        get { return _rotateSubject; }
    }

    private void Awake()
    {
        enemyBullet = (GameObject) Resources.Load("EnemyBullet");
    }

    private void Update()
    {
        Dt = Time.deltaTime;
        //what is Value???
        //clickProperty.Value = (int) Input.GetAxisRaw("Fire1");
        // Debug.Log((int) Input.GetAxisRaw("Fire1"));

        if (Input.GetMouseButtonDown(0))
        {
            _clickSubject.OnNext(bulletNum);
        }

        var subV = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (subV.magnitude > 0)
        {
            var speedSub = MoveSpeed * Dt;
            _axisSubject.OnNext(subV * speedSub);
        }

        var mouseInputX = Input.GetAxis("Mouse X");
        if (Mathf.Abs(mouseInputX) > 0)
        {
            _rotateSubject.OnNext(mouseInputX);
        }
    }

    public float IntervalCulc()
    {
        // ReSharper disable once PossibleLossOfFraction
        return 400 / shootingEnemyNum;
    }
}