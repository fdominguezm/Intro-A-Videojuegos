using UnityEngine;

public interface IBullet {

    Gun Owner { get; }

    float Speed { get; }
    float LifeTime { get; }

    void Travel(); 
    void OnCollisionEnter2D(Collision2D collision);


}