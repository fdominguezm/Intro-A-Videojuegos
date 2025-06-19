using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public Rigidbody2D rb;
    private Vector2 direction;
    Animator anim;
    private Vector2 LastMoveDirection;

    [Header("Key Bindings - Movements")]
    [SerializeField] private KeyCode _moveUp = KeyCode.W;
    [SerializeField] private KeyCode _moveDown = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        direction = GetInputDirection();
        transform.position += (Vector3)(direction.normalized * speed * Time.deltaTime);
        Animate(direction);
        LastMoveDirection = direction;
    }

    private Vector2 GetInputDirection()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(_moveUp)) direction += Vector2.up;
        if (Input.GetKey(_moveDown)) direction += Vector2.down;
        if (Input.GetKey(_moveLeft)) direction += Vector2.left;
        if (Input.GetKey(_moveRight)) direction += Vector2.right;

        return direction;
    }

    private void Animate(Vector2 direction)
    {


        anim.SetBool("isRunning", direction != Vector2.zero);
        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        if (direction != Vector2.zero)
        {
            anim.SetFloat("LastMoveX", LastMoveDirection.x);
            anim.SetFloat("LastMoveY", LastMoveDirection.y);
        }
    }
}
