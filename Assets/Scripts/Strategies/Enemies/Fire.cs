using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float time;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IBurn burn = collision.gameObject.GetComponent<IBurn>();
            burn.ApplyBurn(time, damage);
        }
    }
}