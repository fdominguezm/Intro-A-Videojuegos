using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    
    public GameObject BulletPrefab => throw new System.NotImplementedException();
    [SerializeField] private GameObject _bulletPrefab;

    public int MaxBullet => throw new System.NotImplementedException();
    [SerializeField] private int _maxBullet;

    public int Damage => throw new System.NotImplementedException();
    [SerializeField] private int _damage;

    [SerializeField] protected int _bulletCount;

    public virtual void Attack() => Debug.Log("Parent attack");
    

    public void Reload() => _bulletCount = _maxBullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reload();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
