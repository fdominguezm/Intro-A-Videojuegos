using UnityEngine;

public class Pistol : Gun
{
    public override void Attack()
    {
        if (_bulletCount > 0)
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            _bulletCount--;
        }
    }

}
