using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int shootingEnemyNum = 0;
    public int enemyNum = 80;
    public int damageNum = 0;

    public GameObject enemyBullet;

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
        enemyBullet = (GameObject) Resources.Load("EnemyBullet");
    }

    public float IntervalCulc()
    {
        // ReSharper disable once PossibleLossOfFraction
        return 400 / shootingEnemyNum;
    }
}