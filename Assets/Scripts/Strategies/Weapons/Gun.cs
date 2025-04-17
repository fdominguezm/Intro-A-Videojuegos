using UnityEngine;

public class Gun : MonoBehaviour, IGun
{

    public GameObject BulletPrefab => _bulletPrefab;
    [SerializeField] private GameObject _bulletPrefab;

    public int MaxBullet => _maxBullet;
    [SerializeField] private int _maxBullet = 20;

    public int Damage => _damage;
    [SerializeField] private int _damage = 10;

    public float CooldowndTime => _cooldownTime;
    [SerializeField] private float _cooldownTime = 10f;

    private float _cooldown;
    protected bool _isCoolingDown;
    protected int _bulletCount;

    public virtual void Attack() => Debug.Log("Parent attack");


    public void Reload() => _bulletCount = _maxBullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reload();
        _cooldown = _cooldownTime;
        _isCoolingDown = false;
    }

    void Update()
    {
        if (_cooldown < 0)
        {
            _cooldown = _cooldownTime;
            _isCoolingDown = false;
        }
        else if (_isCoolingDown)
        {
            _cooldown -= Time.deltaTime;
        }
    }

}
