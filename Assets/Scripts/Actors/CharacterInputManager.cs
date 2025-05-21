using System;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponIndex
{
    pistol = 0,
    shotgun = 1,
    rifle = 2
}

public class CharacterInputManager : MonoBehaviour
{
    private IMovable _walkStrategy;
    private IRotatable _turnStrategy;

    [SerializeField] private List<Gun> _gunList;
    [SerializeField] private Gun _gun;

    [Header("Key Bindings - Movements")]
    [SerializeField] private KeyCode _moveUp = KeyCode.W;
    [SerializeField] private KeyCode _moveDown = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;

    [Header("Key Bindings - Attack")]
    [SerializeField] private KeyCode _pistol = KeyCode.Alpha1;
    [SerializeField] private KeyCode _shotgun = KeyCode.Alpha2;
    [SerializeField] private KeyCode _rifle = KeyCode.Alpha3;
    [SerializeField] private KeyCode _attack = KeyCode.Space;
    [SerializeField] private KeyCode _reload = KeyCode.R;

    // Command Properties - Weapons
    private AttackCmd _attackCmd;
    private ReloadCmd _reloadCmd;

    private bool _isKnockedBack = false;
    public bool IsKnockedBack => _isKnockedBack;

    private void Start()
    {
        _walkStrategy = GetComponent<WalkStrategy>();
        _turnStrategy = GetComponent<TurnStrategy>();

        QueueWeaponSwitch(WeaponIndex.pistol);
    }

    private Vector2 GetInputDirection()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(_moveUp)) direction += Vector2.up;
        if (Input.GetKey(_moveDown)) direction += Vector2.down;
        if (Input.GetKey(_moveLeft)) direction += Vector2.left;
        if (Input.GetKey(_moveRight)) direction += Vector2.right;

        return direction;
    }

    private void Update()
    {
        if (!_isKnockedBack)
        {
            Vector2 direction = GetInputDirection();
            if (direction != Vector2.zero)
            {
                EventQueueManager.Instance.AddCommand(new MovementCommand(_walkStrategy, _turnStrategy, direction));
            }
        }

        if (Input.GetKey(_attack)) EventQueueManager.Instance.AddCommand(_attackCmd);
        if (Input.GetKeyDown(_reload)) EventQueueManager.Instance.AddCommand(_reloadCmd);
        if (Input.GetKeyDown(_pistol)) QueueWeaponSwitch(WeaponIndex.pistol);
        if (Input.GetKeyDown(_shotgun)) QueueWeaponSwitch(WeaponIndex.shotgun);
        if (Input.GetKeyDown(_rifle)) QueueWeaponSwitch(WeaponIndex.rifle);


    }

    private void QueueWeaponSwitch(WeaponIndex index)
    {
        var switchCmd = new SwitchWeaponCmd(_gunList, index, OnWeaponSwitched);
        EventQueueManager.Instance.AddCommand(switchCmd);
    }

    private void OnWeaponSwitched(Gun gun)
    {
        _gun = gun;
        EventManager.instance.Event_WeaponChange(gun.name);
        EventManager.instance.Event_GunAmmoChange(gun.BulletCount);
        _attackCmd = new AttackCmd(_gun);
        _reloadCmd = new ReloadCmd(_gun);
    }

    public void SetKnockbackState(bool value)
    {
        _isKnockedBack = value;
    }

}
