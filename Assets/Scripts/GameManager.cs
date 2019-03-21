using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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
            DontDestroyOnLoad(_instance);
            return _instance;
        }
    }

    public float IntervalCulc()
    {
        // ReSharper disable once PossibleLossOfFraction
        return 400 / shootingEnemyNum;
    }
}