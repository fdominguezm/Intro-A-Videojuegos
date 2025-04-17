using UnityEngine;

public class Pistol : Gun
{
    public override void Attack()
    {
        if (_bulletCount > 0 && !_isCoolingDown)
        {
            _isCoolingDown = true;
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            _bulletCount--;
        }
    }

}
