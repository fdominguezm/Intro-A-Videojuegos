using System.Collections.Generic;
using UnityEngine;

public class CharacterInputManager : MonoBehaviour
{
    private WalkStrategy _walkStrategy;
    [SerializeField] private List<Gun> _gunList;
    [SerializeField] private Gun _gun;
    [SerializeField] private KeyCode _moveUp = KeyCode.W;
    [SerializeField] private KeyCode _moveDown = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _pistol = KeyCode.Alpha1;
    [SerializeField] private KeyCode _shotgun = KeyCode.Alpha2;
    [SerializeField] private KeyCode _rifle = KeyCode.Alpha3;
    [SerializeField] private KeyCode _attack = KeyCode.Space;
    [SerializeField] private KeyCode _reload = KeyCode.R;
    
    private void Start()
    {
        this._walkStrategy = GetComponent<WalkStrategy>();
    }

    private void Update()
    {
        if (Input.GetKey(_moveUp)) _walkStrategy.Move(transform.up);
        if (Input.GetKey(_moveDown)) _walkStrategy.Move(-transform.up);
        if (Input.GetKey(_moveLeft)) _walkStrategy.Move(-transform.right);
        if (Input.GetKey(_moveRight)) _walkStrategy.Move(transform.right);
        if (Input.GetKey(_attack)) _gun.Attack();
        if (Input.GetKey(_reload)) _gun.Reload();
        if (Input.GetKey(_pistol)) SwitchWeapon(0);
        if (Input.GetKey(_shotgun)) SwitchWeapon(1);
        if (Input.GetKey(_rifle)) SwitchWeapon(2);
        
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
