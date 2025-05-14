 using UnityEngine;

public class NormalBulletStrategy : MonoBehaviour, IBullet
{
    public float Speed => _speed;
    [SerializeField] private float _speed = 5f;

    public float LifeTime => _lifetime;
    [SerializeField] private float _lifetime = 5f;

    public Gun Owner => _owner;
    [SerializeField] private Gun _owner;

    public void Travel()
    {
        transform.position += transform.up * Time.deltaTime * Speed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (!collision.gameObject.name.Equals("Character") && damageable != null) {
            EventQueueManager.Instance.AddCommand(new ApplyDamageCmd(damageable, Owner.Damage));
            Destroy(gameObject);
        }        
    }

    public void SetOwner(Gun gun) => _owner = gun;

    public void Update()
    {
        Travel();
        _lifetime -= Time.deltaTime;
        if(_lifetime <= 0) Destroy(gameObject);
    }
}