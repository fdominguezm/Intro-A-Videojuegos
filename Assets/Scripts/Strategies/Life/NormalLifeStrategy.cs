using UnityEngine;

public class NormalLifeStrategy : MonoBehaviour, IDamageable
{
    public int CurrentLife => _currentLife;
    [SerializeField] private int _currentLife;

    public int MaxLife => _maxLife;
    [SerializeField] private int _maxLife;

    public void ApplyDamage(int damage)
    {
        Debug.Log("Applying Damage");
        _currentLife -= damage;
        if (_currentLife <= 0) Die();
    }

    public void RestoreLife(int amount)
    {
        _currentLife += amount;
        if (_currentLife > MaxLife) _currentLife = MaxLife;
    }

    public void Die()
    {
        Debug.Log($"Object {name} has died!!!");

        Destroy(gameObject);
    }

    public void Start()
    {
        _currentLife = MaxLife;
    }
}