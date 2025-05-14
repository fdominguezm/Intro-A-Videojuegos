using System.Buffers;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Actor))]
public class ZombieWalk : MonoBehaviour
{
    public Transform target;
    public float Speed => GetComponent<Actor>().ActorStats.Speed;

    public int Damage => GetComponent<Actor>().ActorStats.Damage;

    private float KnockbackForce => GetComponent<Actor>().ActorStats.KnockbackForce;


    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * Speed * Time.deltaTime;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            CharacterInputManager inputManager = collision.gameObject.GetComponent<CharacterInputManager>();

            if (damageable != null)
                EventQueueManager.Instance.AddCommand(new ApplyDamageCmd(damageable, Damage));

            if (rb != null && inputManager != null)
            {
                Vector2 knockbackDir = (collision.transform.position - transform.position).normalized;
                ICommand knockbackCmd = new KnockbackCmd(rb, knockbackDir * KnockbackForce, 0.2f, inputManager);
                EventQueueManager.Instance.AddCommand(knockbackCmd);
            }
        }
    }

}