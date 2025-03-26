using UnityEngine;

public class CharacterInputManager : MonoBehaviour
{
    private WalkStrategy _walkStrategy;

    [SerializeField] private KeyCode _moveUp = KeyCode.W;
    [SerializeField] private KeyCode _moveDown = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;

    private void Start()
    {
        this._walkStrategy = GetComponent<WalkStrategy>();
    }

    private void Update()
    {
        if (Input.GetKey(_moveUp)) _walkStrategy.Move(transform.up);
        if (Input.GetKey(_moveDown)) _walkStrategy.Move(-transform.up);
        if (Input.GetKey(_moveLeft)) _walkStrategy.Move(-transform.right);
        if (Input.GetKey(_moveRight)) _walkStrategy.Move(transform.right);

    }
}
