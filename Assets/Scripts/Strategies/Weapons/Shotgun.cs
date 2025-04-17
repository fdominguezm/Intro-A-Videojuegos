using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private int _bulletsPerShot = 8;

    public override void Attack()
    {
        if (_bulletCount > 0) {
            for (int i = 0; i < _bulletsPerShot; i++)
            {
                Vector2 offset = Random.insideUnitCircle * 1.5f;
                Vector3 spawnPos = transform.position + new Vector3(offset.x, offset.y, 0f);

                Instantiate(BulletPrefab, spawnPos, transform.rotation);
            }
            _bulletCount--;
        }
    }
}