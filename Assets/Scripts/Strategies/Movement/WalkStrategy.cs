using UnityEngine;

[RequireComponent(typeof(Actor))]
public class WalkStrategy : MonoBehaviour, IMovable
{
    public float Speed => GetComponent<Actor>().ActorStats.Speed;


    public void Move(Vector2 direction)
    {
        transform.position += (Vector3)(direction.normalized * Speed * Time.deltaTime);
    }
}
