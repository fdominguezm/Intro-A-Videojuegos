using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private int _bulletsPerShot => _gunStats.BulletsPerShot;
    [SerializeField] private float spreadAngle = 30f; // Ángulo total del cono de disparo

    public override void Attack()
    {
        if (_bulletCount > 0 && !_isCoolingDown)
        {
            _isCoolingDown = true;

            float angleStep = spreadAngle / (_bulletsPerShot - 1);
            float startAngle = -spreadAngle / 2f;

            for (int i = 0; i < _bulletsPerShot; i++)
            {
                float angleOffset = startAngle + i * angleStep;
                Quaternion rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + angleOffset);

                GameObject bullet = Instantiate(BulletPrefab, transform.position, rotation, _bulletsParent);
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
