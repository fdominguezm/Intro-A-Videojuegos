using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Gun", menuName = "Stats/Gun", order = 1)]
public class GunStats : ScriptableObject
{
    [SerializeField] private GunStatsValues _GunStatsValues;

    public GameObject BulletPrefab => _GunStatsValues.BulletPrefab;
    public int Damage => _GunStatsValues.Damage;
    public int MaxBullet => _GunStatsValues.MaxBullet;
    public float CooldownTime => _GunStatsValues.CooldownTime;
    public int BulletsPerShot => _GunStatsValues.BulletsPerShot;


}

[System.Serializable]
public struct GunStatsValues{
    public GameObject BulletPrefab;
    public int Damage;
    public int MaxBullet;
    public float CooldownTime;
    public int BulletsPerShot;
}