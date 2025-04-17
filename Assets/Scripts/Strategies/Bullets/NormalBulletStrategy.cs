 using UnityEngine;

public class NormalBulletStrategy : MonoBehaviour, IBullet
{
    public float Speed => _speed;
    [SerializeField] private float _speed = 5f;

    public float LifeTime => _lifetime;
    [SerializeField] private float _lifetime = 5f;


    public void Travel()
    {
        transform.position += transform.up * Time.deltaTime * Speed;
    }

    public void Update()
    {
        Travel();
        _lifetime -= Time.deltaTime;
        if(_lifetime <= 0) Destroy(gameObject);
    }
}