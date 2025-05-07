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
    private WalkStrategy _walkStrategy;
    private TurnStrategy _turnStrategy;

    [SerializeField] private List<Gun> _gunList;
    [SerializeField] private Gun _gun;
    [SerializeField] private KeyCode _moveUp = KeyCode.W;
    [SerializeField] private KeyCode _moveDown = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _pistol = KeyCode.F1;
    [SerializeField] private KeyCode _shotgun = KeyCode.F2;
    [SerializeField] private KeyCode _rifle = KeyCode.F3;
    [SerializeField] private KeyCode _attack = KeyCode.Space;
    [SerializeField] private KeyCode _reload = KeyCode.R;

    private void Start()
    {
        _walkStrategy = GetComponent<WalkStrategy>();
        _turnStrategy = GetComponent<TurnStrategy>();

        SwitchWeapon((int) WeaponIndex.pistol);
    }

    private void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(_moveUp)) moveDirection += Vector3.up;
        if (Input.GetKey(_moveDown)) moveDirection += Vector3.down;
        if (Input.GetKey(_moveLeft)) moveDirection += Vector3.left;
        if (Input.GetKey(_moveRight)) moveDirection += Vector3.right;

        if (moveDirection != Vector3.zero)
        {
            moveDirection.Normalize(); // Ensures speed is consistent in diagonals
            _walkStrategy.Move(moveDirection);
            _turnStrategy.FaceDirection(moveDirection);
        }

        if (Input.GetKey(_attack)) _gun.Attack();
        if (Input.GetKey(_reload)) _gun.Reload();
        if (Input.GetKey(_pistol)) SwitchWeapon((int) WeaponIndex.pistol);
        if (Input.GetKey(_shotgun)) SwitchWeapon((int) WeaponIndex.shotgun);
        if (Input.GetKey(_rifle)) SwitchWeapon((int) WeaponIndex.rifle);

        // if (Input.GetKeyDown(KeyCode.Escape)) EventManager.instance.EventGameOver(true);
        
        // if (Input.GetKeyDown(KeyCode.E)) EventManager.instance.EventGameOver(false);
        
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
