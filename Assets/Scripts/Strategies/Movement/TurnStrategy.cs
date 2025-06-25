using UnityEngine;
using System.Collections.Generic;

public class TurnStrategy : MonoBehaviour, IRotatable
{
    private List<Transform> allChildRenderers = new List<Transform>();
    private void Awake()
    {
        allChildRenderers.Add(transform.Find("Pistol"));
        allChildRenderers.Add(transform.Find("Shotgun"));
        allChildRenderers.Add(transform.Find("Rifle"));
        allChildRenderers.Add(transform.Find("Thunderifle"));

    }

    public void FaceDirection(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        foreach (var t in allChildRenderers)
        {
            if (t != null && t.gameObject.activeInHierarchy)
            {
                t.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }
    }
}
