using UnityEngine;

// [RequireComponent(typeof(Actor))]
public class TurnStrategy : MonoBehaviour, IRotatable
{
    // public float Speed => GetComponent<Actor>().ActorStats.Turn;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FaceDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)
            return;

        // Flip horizontal
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Ángulo de rotación (arma apuntando en dirección del movimiento)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Ajustamos con -90 porque el sprite por defecto mira a la derecha
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
