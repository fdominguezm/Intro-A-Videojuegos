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

    private void Start()
    {
        _walkStrategy = GetComponent<WalkStrategy>();
        _turnStrategy = GetComponent<TurnStrategy>();

        SwitchWeapon((int)WeaponIndex.pistol);
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
        Vector2 direction = GetInputDirection();
        if (direction != Vector2.zero)
        {
            ICommand command = new MovementCommand(_walkStrategy, _turnStrategy, direction);
            command.Execute();
        }

        if (Input.GetKey(_attack)) _gun.Attack();
        if (Input.GetKey(_reload)) _gun.Reload();
        if (Input.GetKey(_pistol)) SwitchWeapon((int)WeaponIndex.pistol);
        if (Input.GetKey(_shotgun)) SwitchWeapon((int)WeaponIndex.shotgun);
        if (Input.GetKey(_rifle)) SwitchWeapon((int)WeaponIndex.rifle);

    }

    private void SwitchWeapon(int weaponIndex)
    {
        foreach (Gun gun in _gunList)
        {
            gun.gameObject.SetActive(false);
        }

        _gun = _gunList[weaponIndex];
        _gun.gameObject.SetActive(true);
    }
}
