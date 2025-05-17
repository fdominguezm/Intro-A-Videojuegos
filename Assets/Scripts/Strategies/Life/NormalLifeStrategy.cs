using UnityEngine;

[RequireComponent(typeof(Actor))]

public class NormalLifeStrategy : MonoBehaviour, IDamageable
{
    public int CurrentLife => _currentLife;
    [SerializeField] private int _currentLife;

    public int MaxLife => GetComponent<Actor>().ActorStats.MaxLife;

    public void ApplyDamage(int damage)
    {
        _currentLife -= damage;
        if (gameObject.tag.Equals("Player"))
        {
            EventManager.instance.Event_LifeChange(CurrentLife, MaxLife);
            EventManager.instance.Event_OnPlayerDamage();
        }
        else if (gameObject.name.Equals("Zombie"))
        {
            EventManager.instance.Event_OnZombieDamage();
        }
        if (_currentLife <= 0) Die();
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
            EventManager.instance.EventGameOver(true);
        }
        Destroy(gameObject);

    }

    public void Start()
    {
        // audioSource = GetComponent<AudioSource>();
        _currentLife = MaxLife;
        EventManager.instance.Event_LifeChange(CurrentLife, MaxLife);
    }
}