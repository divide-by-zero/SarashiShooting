using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text _leftEnemyLabel;

    [SerializeField]
    private Text _damageLabel;

    public int shootingEnemyNum = 0;
    public int enemyNum = 80;
    public int damageNum = 0;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                //よくあるシングルトン　すでにシーンに存在する場合はそれを使用するう
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    var obj = new GameObject(typeof(GameManager).Name);
                    _instance = obj.AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }

    public void Start()
    {
        //enemyNumやdamageNumの変更を監視。　そのままTextへ流し込み
        if (_leftEnemyLabel != null)
        {
            this.ObserveEveryValueChanged(manager => manager.enemyNum).SubscribeToText(_leftEnemyLabel);
        }
        if (_damageLabel != null)
        {
            this.ObserveEveryValueChanged(manager => manager.damageNum).SubscribeToText(_damageLabel);
        }
    }

    public float IntervalCulc()
    {
        // ReSharper disable once PossibleLossOfFraction
        return 400 / shootingEnemyNum;
    }
}