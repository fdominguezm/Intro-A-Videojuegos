using UnityEngine;

[RequireComponent(typeof(Actor))]

public class NormalLifeStrategy : MonoBehaviour, IDamageable
{
    public AudioClip damageClip;
    public AudioSource audioSource;
    public int CurrentLife => _currentLife;
    [SerializeField] private int _currentLife;

    public int MaxLife => GetComponent<Actor>().ActorStats.MaxLife;

    public void ApplyDamage(int damage)
    {
        _currentLife -= damage;
        if (gameObject.tag.Equals("Player")) EventManager.instance.Event_LifeChange(CurrentLife, MaxLife);
        if (damageClip != null) audioSource.PlayOneShot(damageClip);
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
            EventManager.instance.EventZombieKilled();
        }
        Destroy(gameObject);

    }

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _currentLife = MaxLife;
        EventManager.instance.Event_LifeChange(CurrentLife, MaxLife);
    }
}