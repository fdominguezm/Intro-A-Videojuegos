using UnityEngine;

public interface IDamageable 
{
    int CurrentLife {get;}
    int MaxLife {get;}

    void ApplyDamage(int damage);
    void RestoreLife(int amount);
    void Die();

}