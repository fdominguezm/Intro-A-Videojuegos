using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    
    public GameObject BulletPrefab => _bulletPrefab;
    [SerializeField] private GameObject _bulletPrefab;

    public int MaxBullet => _maxBullet;
    private int _maxBullet = 20;

    public int Damage => _damage;
    private int _damage = 10;

    [SerializeField] protected int _bulletCount;

    public virtual void Attack() => Debug.Log("Parent attack");
    

    public void Reload() => _bulletCount = _maxBullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reload();
    }

}
