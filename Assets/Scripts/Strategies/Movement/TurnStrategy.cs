using UnityEngine;

[RequireComponent(typeof(Actor))]
public class TurnStrategy : MonoBehaviour, IRotatable
{
    public float Speed => GetComponent<Actor>().ActorStats.Turn;

    public void FaceDirection(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
    }
}
