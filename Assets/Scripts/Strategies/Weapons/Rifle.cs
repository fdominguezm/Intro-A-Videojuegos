using UnityEngine;

public class Rifle : Gun
{
    [SerializeField] private int _bulletsPerShot = 5;

    public override void Attack()
    {
        for (int i = 0; i < _bulletsPerShot; i++)
        {
            Instantiate(BulletPrefab,
                transform.position + Vector3.right * i * 0.6f,  // desplazamiento en eje X
                transform.rotation);
        }
    }
}