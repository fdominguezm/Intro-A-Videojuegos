using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Actor", menuName = "Stats/Actor", order = 0)]
public class ActorStats : ScriptableObject
{
    [SerializeField] private ActorStatsValues _actorStatsValues;

    public int MaxLife => _actorStatsValues.MaxLife;
    public float Speed => _actorStatsValues.Speed;

    public float Turn => _actorStatsValues.Turn;
    public float KnockbackForce => _actorStatsValues.KnockbackForce;
    public int Damage => _actorStatsValues.Damage;


}

[System.Serializable]
public struct ActorStatsValues{
    public int MaxLife;
    public float Speed;
    public float Turn;
    public float KnockbackForce;
    public int Damage;
}