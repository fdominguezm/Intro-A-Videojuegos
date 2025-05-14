using System.Collections;
using UnityEngine;

public class KnockbackCmd : ICommand
{
    private Rigidbody2D _rb;
    private Vector2 _force;
    private float _duration;
    private CharacterInputManager _inputManager;

    public KnockbackCmd(Rigidbody2D rb, Vector2 force, float duration, CharacterInputManager inputManager)
    {
        _rb = rb;
        _force = force;
        _duration = duration;
        _inputManager = inputManager;
    }

    public void Execute()
    {
        if (_rb != null && _inputManager != null)
        {
            _inputManager.SetKnockbackState(true);
            _rb.linearVelocity = Vector2.zero;
            _rb.AddForce(_force, ForceMode2D.Impulse);
            _inputManager.StartCoroutine(EndKnockback());
        }
    }

    private IEnumerator EndKnockback()
    {
        yield return new WaitForSeconds(_duration);
        _rb.linearVelocity = Vector2.zero;
        _inputManager.SetKnockbackState(false);
    }
}
