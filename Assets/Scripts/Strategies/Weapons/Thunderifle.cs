using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Thunderifle : Gun
{
    // [SerializeField] private float _spreadAngle = 30f;
    [SerializeField] private float _range = 30f;
    [SerializeField] private float _pushForce = 0.5f;

    [SerializeField] private LayerMask _raycastMask;


    private int _pellets => _gunStats.BulletsPerShot;

    private Collider2D _ownCollider;

    [SerializeField] private LineRenderer _lineRenderer;

    IEnumerator ShowRay(Vector2 origin, Vector2 hitPoint)
    {
        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(0, origin);
        _lineRenderer.SetPosition(1, hitPoint);

        yield return new WaitForSeconds(0.05f);

        _lineRenderer.enabled = false;
    }

    private void Start()
    {
        // Agarra el collider propio o del padre (si el arma está en un hijo)
        _ownCollider = GetComponent<Collider2D>();
        if (_ownCollider == null && transform.root != null)
        {
            _ownCollider = transform.root.GetComponent<Collider2D>();
        }
    }


    public override void Attack()
    {
        // Debug.Log("disparo1");

        if (_bulletCount <= 0 || _isCoolingDown) return;
        // Debug.Log("disparo");

        _isCoolingDown = true;
        _bulletCount--;

        // HashSet<IDamageable> alreadyHit = new HashSet<IDamageable>();

        // float angleStep = _spreadAngle / (_pellets - 1);
        // float startAngle = -_spreadAngle / 2f;

        // for (int i = 0; i < _pellets; i++)
        // {
        //     float angleOffset = startAngle + i * angleStep;
        //     Quaternion spreadRotation = Quaternion.Euler(0, 0, angleOffset);

        Vector3 origin = transform.position + transform.right * 1.5f;
        Vector3 direction = transform.right;

        //     Debug.DrawRay(origin, direction * _range, Color.cyan, 1f);

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, _range);
        StartCoroutine(ShowRay(origin, hit.point));

        if (hit.collider != null)
        {
            //HASTA ACA FUNCIONA BIEN
            // Debug.Log("Golpeo");
            IDamageable target = hit.collider.GetComponentInParent<IDamageable>();
            Debug.Log(hit.collider.tag);
            if (target != null && hit.collider.CompareTag("Enemy"))
            {
                // Debug.Log("Raycast tocó: " + hit.collider.name);
                Debug.Log(Damage);
                Debug.Log(target);
                EventQueueManager.Instance.AddCommand(new ApplyDamageCmd(target, Damage));

                // Empuje opcional si tiene Rigidbody2D
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(direction * _pushForce, ForceMode2D.Impulse);
                }
            }
        }


        base.Attack();
        EventManager.instance.Event_OnShot(WeaponIndex.thunderifle);
    }
}
