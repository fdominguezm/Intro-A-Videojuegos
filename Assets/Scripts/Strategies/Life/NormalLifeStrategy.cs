using UnityEngine;

public enum DamageType
{
    Character = 0,
    Zombie = 1,
    Wall = 2
}


[RequireComponent(typeof(Actor))]
public class NormalLifeStrategy : MonoBehaviour, IDamageable
{
    [SerializeField] DamageType type;
    public int CurrentLife => _currentLife;
    private bool dead;
    [SerializeField] private int _currentLife;

    public int MaxLife => GetComponent<Actor>().ActorStats.MaxLife;

    public void ApplyDamage(int damage)
    {
        _currentLife -= damage;
        if (gameObject.tag.Equals("Player")) EventManager.instance.Event_LifeChange(CurrentLife, MaxLife);
        EventManager.instance.Event_OnDamage(type);
        if (_currentLife <= 0 && !dead)
        {
            dead = true;
            Die();
        }
    }

    public void RestoreLife(int amount)
    {
        _currentLife += amount;
        if (_currentLife > MaxLife) _currentLife = MaxLife;
        if (gameObject.tag.Equals("Player")) EventManager.instance.Event_LifeChange(CurrentLife, MaxLife);
    }

    public void Die()
    {
        Debug.Log($"Object {name} has died!!!");
        if (gameObject.tag.Equals("Player"))
        {
            EventManager.instance.EventGameOver(false);
        }
        else if (gameObject.name.Equals("Zombie"))
        {
            EventManager.instance.EventZombieKilled();
        }
        Destroy(gameObject);

    }

    public void Start()
    {
        _currentLife = MaxLife;
        EventManager.instance.Event_LifeChange(CurrentLife, MaxLife);
        dead = false;
    }
}