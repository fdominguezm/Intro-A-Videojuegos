using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public Rigidbody2D rb;

    [Header("Child Animators")]
    public Animator bottomAnimator;
    public Animator topAnimator;

    private Vector2 direction;
    private Vector2 LastMoveDirection;

    private int weaponIndex = 0;

    [Header("Key Bindings - Movements")]
    [SerializeField] private KeyCode _moveUp = KeyCode.W;
    [SerializeField] private KeyCode _moveDown = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;

    [Header("Key Bindings - Weapons")]
    [SerializeField] private KeyCode _nextWeapon = KeyCode.E;
    [SerializeField] private KeyCode _prevWeapon = KeyCode.Q;

    void Update()
    {
        direction = GetInputDirection();
        transform.position += (Vector3)(direction.normalized * speed * Time.deltaTime);
        Animate(direction);
        LastMoveDirection = direction;

        if (Input.GetKeyDown(_nextWeapon))
        {
            weaponIndex = (weaponIndex + 1) % 3;
        }
        else if (Input.GetKeyDown(_prevWeapon))
        {
            weaponIndex = (weaponIndex + 2) % 3;
        }
        AnimateWeapon(weaponIndex);
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
        bottomAnimator.SetBool("isRunning", direction != Vector2.zero);
        bottomAnimator.SetFloat("MoveX", direction.x);
        bottomAnimator.SetFloat("MoveY", direction.y);
        if (direction != Vector2.zero)
        {
            topAnimator.SetFloat("MoveX", direction.x);
            topAnimator.SetFloat("MoveY", direction.y);
            bottomAnimator.SetFloat("LastMoveX", LastMoveDirection.x);
            bottomAnimator.SetFloat("LastMoveY", LastMoveDirection.y);
        }
    }

    private void AnimateWeapon(int index)
    {
        topAnimator.SetFloat("Index", index);
    }
}
