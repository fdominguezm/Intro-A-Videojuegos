using UnityEngine;

[RequireComponent(typeof(Actor))]
public class ZombieWalk : MonoBehaviour
{
    public Transform target;
    public float Speed => GetComponent<Actor>().ActorStats.Speed;
    public int Damage => GetComponent<Actor>().ActorStats.Damage;
    private float KnockbackForce => GetComponent<Actor>().ActorStats.KnockbackForce;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 rawDirection = (target.position - transform.position).normalized;
            Vector2 quantizedDir = GetEightDirection(rawDirection);

            // Flip horizontal
            if (quantizedDir.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (quantizedDir.x > 0)
            {
                spriteRenderer.flipX = false;
            }

            transform.position += (Vector3)(quantizedDir * Speed * Time.deltaTime);

            float angle = Mathf.Atan2(quantizedDir.y, quantizedDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
        }
    }

    // Este método redondea la dirección al eje o diagonal más cercano
    private Vector2 GetEightDirection(Vector2 input)
    {
        if (input == Vector2.zero) return Vector2.zero;

        float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;

        // Redondeamos el ángulo a múltiplos de 45 grados
        float roundedAngle = Mathf.Round(angle / 45f) * 45f;

        // Convertimos el ángulo redondeado a vector
        float radians = roundedAngle * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;

        return direction;
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
