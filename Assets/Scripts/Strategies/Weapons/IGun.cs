using UnityEngine;

public interface IGun {

    GameObject BulletPrefab {get;}
    int MaxBullet {get;}
    int Damage{get;}
    void Attack();
    void Reload();
}