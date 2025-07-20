using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Actor))]
public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject MinionPrefab;
    [SerializeField] private Transform _enemiesParent;
    [SerializeField] private int _minionsSummoned = 5;
    [SerializeField] private float _summonCooldown = 5f;

    private float _summonTimer;

    private void Start()
    {
        _summonTimer = _summonCooldown;
    }

    private void Update()
    {
        _summonTimer -= Time.deltaTime;

        if (_summonTimer <= 0f)
        {
            Summon();
            _summonTimer = _summonCooldown;
        }
    }
    private void Summon()
    {
        for (int i = 0; i < _minionsSummoned; i++)
        {
            Instantiate(MinionPrefab, transform.position, transform.rotation, _enemiesParent);
        }
    }

}