using UnityEngine;

public class Rifle : Gun
{
    [SerializeField] private int _bulletsPerShot = 5;

    public override void Attack()
    {
        if (_bulletCount > 0)
        {
            for (int i = 0; i < _bulletsPerShot; i++)
            {
                Instantiate(BulletPrefab,
                    transform.position + Vector3.right * i * 0.6f,  // desplazamiento en eje X
                    transform.rotation);
            }
            _bulletCount--;
        }
    }
}