using System;
using System.Collections.Generic;
using UnityEngine;

enum WeaponIndex
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

        QueueWeaponSwitch((int)WeaponIndex.pistol);
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
        if (Input.GetKey(_reload)) EventQueueManager.Instance.AddCommand(_reloadCmd);
        if (Input.GetKeyDown(_pistol)) QueueWeaponSwitch((int)WeaponIndex.pistol);
        if (Input.GetKeyDown(_shotgun)) QueueWeaponSwitch((int)WeaponIndex.shotgun);
        if (Input.GetKeyDown(_rifle)) QueueWeaponSwitch((int)WeaponIndex.rifle);


    }

    private void QueueWeaponSwitch(int index)
    {
        var switchCmd = new SwitchWeaponCmd(_gunList, index, OnWeaponSwitched);
        EventQueueManager.Instance.AddCommand(switchCmd);
    }

    private void OnWeaponSwitched(Gun gun)
    {
        _gun = gun;
        _attackCmd = new AttackCmd(_gun);
        _reloadCmd = new ReloadCmd(_gun);
    }

    public void SetKnockbackState(bool value)
    {
        _isKnockedBack = value;
    }


    // private void SwitchWeapon(int weaponIndex)
    // {
    //     foreach (Gun gun in _gunList)
    //     {
    //         gun.gameObject.SetActive(false);
    //     }

    //     _gun = _gunList[weaponIndex];
    //     _gun.gameObject.SetActive(true);

    //     _attackCmd = new AttackCmd(_gun);
    //     _reloadCmd = new ReloadCmd(_gun);
    // }
}
