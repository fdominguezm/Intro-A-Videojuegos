using UnityEngine;
using System.Collections.Generic;

public class TurnStrategy : MonoBehaviour, IRotatable
{
    private SpriteRenderer spriteRenderer;
    private List<Transform> allChildRenderers = new List<Transform>();
    private Vector2 lastDirection = Vector2.right; // por defecto mirando a la derecha
    private float minDirectionChange = 0.1f;       // magnitud mínima para considerar una dirección válida
    private float minAngleChange = 2f;             // evita cambios muy pequeños de ángulo (ruido)

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        allChildRenderers.Add(transform.Find("Pistol"));
        allChildRenderers.Add(transform.Find("Shotgun"));
        allChildRenderers.Add(transform.Find("Rifle"));
    }

    public void FaceDirection(Vector2 direction)
    {
        // Si la dirección es insignificante, no hacer nada
        if (direction.magnitude < minDirectionChange)
            return;

        // Si el cambio angular con respecto a la última dirección es muy chico, no rotar
        float angleDiff = Vector2.Angle(direction, lastDirection);
        if (angleDiff < minAngleChange)
            return;

        lastDirection = direction.normalized;

        // Flip horizontal
        spriteRenderer.flipX = direction.x < 0;

        foreach (var t in allChildRenderers)
        {
            if (t != null && t.gameObject.activeInHierarchy)
            {
                var childRenderer = t.GetComponent<SpriteRenderer>();
                if (childRenderer != null)
                    childRenderer.flipY = direction.x < 0;
            }
        }

        // Ángulo de rotación
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
