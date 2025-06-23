using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;


    public float speed = 0.5f;
    public Rigidbody2D rb;

    [Header("Movement Animators")]
    public Animator moveAnimator;

    private Vector2 direction;
    private Vector2 LastMoveDirection;

    [Header("Key Bindings - Movements")]
    [SerializeField] private KeyCode _moveUp = KeyCode.W;
    [SerializeField] private KeyCode _moveDown = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;

    void Start()
    {
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
            Vector2 direction = GetEightDirection(rawDirection);

            transform.position += (Vector3)(direction * speed * Time.deltaTime);
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
}
