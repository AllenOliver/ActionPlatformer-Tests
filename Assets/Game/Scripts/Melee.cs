using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Melee : MonoBehaviour
{
    public GameObject Weapon_Front;
    public GameObject Weapon_Back;
    public Weapon CurrentWeapon;

    private Movement _currentMovement;
    private SpriteRenderer _weaponSprite_Front;
    private SpriteRenderer _weaponSprite_Back;
    private bool _canAttack;

    // Start is called before the first frame update
    private void Start()
    {
        _canAttack = true;
        _currentMovement = GetComponent<Movement>();
        _weaponSprite_Front = Weapon_Front.GetComponent<SpriteRenderer>();
        _weaponSprite_Back = Weapon_Back.GetComponent<SpriteRenderer>();
        Weapon_Front.Off();
        Weapon_Back.Off();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GameModeBase.instance.IsPaused)
        {
            if (Input.GetButtonDown("Attack"))
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        if (_canAttack && !_currentMovement.wallGrab)
        {
            _canAttack = false;

            if (_currentMovement.side == 1)
            {
                Weapon_Front.On();
            }
            else
            {
                Weapon_Back.On();
            }

            Debug.Log("Attacking");
            StartCoroutine(AttackDelay(.25f));
        }
    }

    private IEnumerator AttackDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Weapon_Front.Off();
        Weapon_Back.Off();
        _canAttack = true;
    }

    [Button(ButtonSizes.Small)]
    public void SetWeaponSprites()
    {
        _weaponSprite_Front = Weapon_Front.GetComponent<SpriteRenderer>();
        _weaponSprite_Back = Weapon_Back.GetComponent<SpriteRenderer>();

        _weaponSprite_Front.sprite = CurrentWeapon.WeaponSprite;
        _weaponSprite_Back.sprite = CurrentWeapon.WeaponSprite;
    }
}