using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Actor : MonoBehaviour
{
    public ActorStats ActorStats => _actorStats;
    [SerializeField] private ActorStats _actorStats;

}
