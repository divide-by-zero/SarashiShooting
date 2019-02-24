using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Async;

public class GameManager : MonoBehaviour
{
    public static float Dt;
    public ReactiveProperty<int> clickProperty = new ReactiveProperty<int>(0);

    private Subject<int> _clickSubject = new Subject<int>();
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

    private void Awake()
    {
        //clickProperty.Subscribe(val => { Debug.Log(val); });
    }

    public IObservable<int> OnClicked
    {
        get { return _clickSubject; }
    }

    private void Update()
    {
        Dt = Time.deltaTime;
        //what is Value???
        //clickProperty.Value = (int) Input.GetAxisRaw("Fire1");
        // Debug.Log((int) Input.GetAxisRaw("Fire1"));

        if (Input.GetMouseButtonDown(0))
        {
            _clickSubject.OnNext(1);
        }
    }
}