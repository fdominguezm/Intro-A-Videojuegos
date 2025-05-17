using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private int _bulletsPerShot => _gunStats.BulletsPerShot;

    public override void Attack()
    {
        if (_bulletCount > 0 && !_isCoolingDown)
        {
            _isCoolingDown = true;
            for (int i = 0; i < _bulletsPerShot; i++)
            {
                Vector2 offset = Random.insideUnitCircle * 1.5f;
                Vector3 spawnPos = transform.position + new Vector3(offset.x, offset.y, 0f);

                GameObject bullet = Instantiate(BulletPrefab, spawnPos, transform.rotation, _bulletsParent);
                bullet.GetComponent<NormalBulletStrategy>().SetOwner(this);
            }
            _bulletCount--;
            base.Attack();
            if (shootClip != null)
            {
                audioSource.PlayOneShot(shootClip);
            }
        }
    }
}