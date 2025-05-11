using UnityEngine;

[RequireComponent(typeof(Actor))]
public class WalkStrategy : MonoBehaviour, IMovable
{
    public float Speed => GetComponent<Actor>().ActorStats.Speed;


    public void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * Speed;
    }

}
