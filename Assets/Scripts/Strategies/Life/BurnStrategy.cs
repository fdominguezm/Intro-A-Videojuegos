using UnityEngine;

public class BurnStrategy : MonoBehaviour, IBurn
{
    private IDamageable _damageable;
    private float _burning;
    private float _tickTimer;
    private int _damage;

    public void ApplyBurn(float time, int damage)
    {
        if (_burning < time)
        {
            _burning = time;
        }

        _damage = damage;
    }

    private void Start()
    {
        _damageable = GetComponent<IDamageable>();
    }

    void Update()
    {
        if (_burning > 0)
        {
            EventManager.instance.EventBurning(true);
            _burning -= Time.deltaTime;
            _tickTimer -= Time.deltaTime;

            if (_tickTimer <= 0f)
            {
                EventQueueManager.Instance.AddCommand(new ApplyDamageCmd(_damageable, _damage));
                _tickTimer = 1f;
            }
        }
        else
        {
            EventManager.instance.EventBurning(false);
            _tickTimer = 1f;
        }
    }
}
