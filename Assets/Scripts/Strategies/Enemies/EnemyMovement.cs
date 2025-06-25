using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Actor))]
public class EnemyMovement : MonoBehaviour
{
    public Transform target;

    public float Speed => GetComponent<Actor>().ActorStats.Speed;
    public int Damage => GetComponent<Actor>().ActorStats.Damage;
    private float KnockbackForce => GetComponent<Actor>().ActorStats.KnockbackForce;

    [Header("Movement Animators")]
    public Animator moveAnimator;
    private NavMeshAgent agent;


    private Vector2 direction;
    private Vector2 LastMoveDirection;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
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

            agent.SetDestination(target.position);
            // Vector2 rawDirection = (target.position - transform.position).normalized;
            Vector2 direction = GetEightDirection(agent.velocity);

            // transform.position += (Vector3)(direction * Speed * Time.deltaTime);
            Animate(direction);
            LastMoveDirection = direction;
        }
    }

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

    private void Animate(Vector2 direction)
    {
        moveAnimator.SetBool("isRunning", direction != Vector2.zero);
        moveAnimator.SetFloat("MoveX", direction.x);
        moveAnimator.SetFloat("MoveY", direction.y);
        if (direction != Vector2.zero)
        {
            moveAnimator.SetFloat("LastMoveX", LastMoveDirection.x);
            moveAnimator.SetFloat("LastMoveY", LastMoveDirection.y);
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
