using UnityEngine;

public class Gun : MonoBehaviour, IGun
{

    [SerializeField] protected GunStats _gunStats;
    public GameObject BulletPrefab => _gunStats.BulletPrefab;

    public int MaxBullet => _gunStats.MaxBullet;

    public int Damage => _gunStats.Damage;

    public float CooldownTime => _gunStats.CooldownTime;

    private float _cooldown;
    protected bool _isCoolingDown;
    protected int _bulletCount;
    [SerializeField] protected Transform _bulletsParent;

    public virtual void Attack() => Debug.Log("Parent attack");


    public void Reload() => _bulletCount = MaxBullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reload();
        _cooldown = CooldownTime;
        _isCoolingDown = false;
    }

    void Update()
    {
        if (_cooldown < 0)
        {
            _cooldown = CooldownTime;
            _isCoolingDown = false;
        }
        else if (_isCoolingDown)
        {
            _cooldown -= Time.deltaTime;
        }
    }

}
