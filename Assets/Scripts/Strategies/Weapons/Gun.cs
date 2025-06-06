using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    [SerializeField] protected GunStats _gunStats;
    public GameObject BulletPrefab => _gunStats.BulletPrefab;

    public int MaxBullet => _gunStats.MaxBullet;

    public int Damage => _gunStats.Damage;

    public float CooldownTime => _gunStats.CooldownTime;

    public int BulletCount => _bulletCount;

    private float _cooldown;
    protected bool _isCoolingDown;
    protected int _bulletCount;
    [SerializeField] protected Transform _bulletsParent;

    public virtual void Attack() => EventManager.instance.Event_GunAmmoChange(_bulletCount);


    public void Reload()
    {
        _bulletCount = MaxBullet;
        EventManager.instance.Event_GunAmmoChange(_bulletCount);
        EventManager.instance.Event_OnReload();
    }

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
