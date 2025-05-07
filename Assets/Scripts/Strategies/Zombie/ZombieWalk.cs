using System.Buffers;
using UnityEngine;
using System.Collections;

public class ZombieWalk : MonoBehaviour
{
    public Transform target; 
    public float speed = 2f;

    public int damage = 10;

    private float knockbackForce = 500f; 


    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

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
                    damageable.ApplyDamage(damage);
                }
                if (rb != null)
                {
                    Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                    rb.AddForce(knockbackDirection * knockbackForce);
                    StartCoroutine(StopKnockback(rb, 0.1f));

                }
        }
    }
}