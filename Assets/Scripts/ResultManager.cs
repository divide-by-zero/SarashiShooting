using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    void Start()
    {
        //画面遷移していきなりタイトルに戻れるとリザルトが意図せず飛ばされる事があるので、1秒Delay
        this.UpdateAsObservable()
            .Delay(TimeSpan.FromSeconds(1))
            .Where(unit => Input.GetMouseButtonDown(0))
            .Subscribe(unit => SceneManager.LoadScene("Start"))
            .AddTo(this);
    }
}
