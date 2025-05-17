using UnityEngine;

public class Pistol : Gun
{
    public override void Attack()
    {
        if (_bulletCount > 0 && !_isCoolingDown)
        {
            _isCoolingDown = true;
            GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation, _bulletsParent);
            bullet.GetComponent<NormalBulletStrategy>().SetOwner(this);
            _bulletCount--;
            base.Attack();
            EventManager.instance.Event_OnGunShoot(0);
        }
    }

}
