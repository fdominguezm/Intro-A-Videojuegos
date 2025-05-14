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

    private IEnumerator StopKnockback(Rigidbody2D rb, float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.linearVelocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Character"))
        {
                IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

                if (damageable != null)
                {
                    EventQueueManager.Instance.AddCommand(new ApplyDamageCmd(damageable, Damage));
                }
                if (rb != null)
                {
                    Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                    rb.AddForce(knockbackDirection * KnockbackForce);
                    StartCoroutine(StopKnockback(rb, 0.1f));

                }
        }
    }
}