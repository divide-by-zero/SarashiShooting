using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerController : MonoBehaviour
{
    private readonly float MoveSpeed = 20;
    private readonly float RotateSpeed = 200;
    private readonly int BulletLifeTime = 3;

    private AudioSource _pAudioSource;

    public int bulletNum = 1;

    private GameManager _gameManager;
    [SerializeField] private ParticleSystem bullet;

    public int playerHp = 1000; //使ってない。　本当はゲームオーバー判定用？

    private void Awake()
    {
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

        //TODO 暫定対応 マウスが画面外に行ってしまって困るので、右ドラッグでのみ向きを変更するように
        if (Input.GetMouseButton((int)MouseButton.RightMouse))
        {
            var mouseInputX = Input.GetAxis("Mouse X");
            if (Mathf.Abs(mouseInputX) > 0)
            {
                transform.RotateAround(gameObject.transform.position, Vector3.up, mouseInputX * Time.deltaTime * RotateSpeed);
            }
        }
    }

    private void ShootBullet(int n)
    {
        var transform1 = transform;
        var rotation = transform1.rotation;
        var subBullet = Instantiate(bullet, transform1.position + rotation * Vector3.forward * 1.5f,rotation);
        subBullet.emission.SetBurst(0, new ParticleSystem.Burst(0, n));
        var controller = subBullet.GetComponent<BulletCollisionController>();
        controller._parentPlayer = this;
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