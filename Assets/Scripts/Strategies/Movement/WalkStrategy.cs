using UnityEngine;


public class WalkStrategy : MonoBehaviour, IMovable
{
    public float Speed => _speed;
    [SerializeField] private float _speed = 10f;

    public void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * Speed;
    }

}
