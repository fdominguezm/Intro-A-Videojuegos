using UnityEngine;

public interface IMovable {
    float Speed { get; }

    void Move(Vector3 direction); 
}
