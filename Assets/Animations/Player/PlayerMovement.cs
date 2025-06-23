using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public Rigidbody2D rb;
    private Vector2 direction;
    Animator anim;
    private Vector2 LastMoveDirection;

    private int weaponIndex = 0;

    [Header("Key Bindings - Movements")]
    [SerializeField] private KeyCode _moveUp = KeyCode.W;
    [SerializeField] private KeyCode _moveDown = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;

    [Header("Key Bindings - Weapons")]
    [SerializeField] private KeyCode _pistol = KeyCode.Alpha1;
    [SerializeField] private KeyCode _uzi = KeyCode.Alpha2;


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

    void FixedUpdate()
    {
        if (Input.GetKey(_pistol))
        {
            weaponIndex = 0;
        }
        else if (Input.GetKey(_uzi))
        {
            weaponIndex = 1;
        }
        Debug.Log(weaponIndex);
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


        anim.SetBool("isRunning", direction != Vector2.zero);
        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        if (direction != Vector2.zero)
        {
            anim.SetFloat("LastMoveX", LastMoveDirection.x);
            anim.SetFloat("LastMoveY", LastMoveDirection.y);
        }
    }

    private void AnimateWeapon(int index)
    {
        anim.SetInteger("WeaponIdx", index);
    }
}
