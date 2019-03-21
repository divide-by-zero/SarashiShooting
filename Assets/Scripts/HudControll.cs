using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HudControll : MonoBehaviour
{
    [SerializeField]
    private Text _leftEnemyLabel;

    [SerializeField]
    private Text _damageLabel;

    public void Start()
    {
        //GameManagerのenemyNumやdamageNumの変更を監視。　そのままTextへ流し込み
        if (_leftEnemyLabel != null)
        {
            this.ObserveEveryValueChanged(_ => GameManager.Instance.enemyNum).SubscribeToText(_leftEnemyLabel).AddTo(this);
        }
        if (_damageLabel != null)
        {
            this.ObserveEveryValueChanged(_ => GameManager.Instance.damageNum).SubscribeToText(_damageLabel).AddTo(this);
        }
    }
}
