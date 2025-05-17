using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    public AudioClip shootClip;
    public AudioClip reloadClip;
    public AudioSource audioSource;
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
        if (reloadClip != null)
        {
            audioSource.PlayOneShot(reloadClip);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
