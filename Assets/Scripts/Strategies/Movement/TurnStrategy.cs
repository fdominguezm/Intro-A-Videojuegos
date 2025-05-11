using UnityEngine;

[RequireComponent(typeof(Actor))]

public class TurnStrategy : MonoBehaviour, IMovable
{
    public float Speed => GetComponent<Actor>().ActorStats.Turn;

    public void Move(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
    public void FaceDirection(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
    }
}
