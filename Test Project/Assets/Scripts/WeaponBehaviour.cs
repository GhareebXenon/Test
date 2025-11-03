using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] private Weapons weapons;
    public static event Action<int> OnShoot;
    private int shots = 0;

    private void Start()
    {
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shots++;
            attack();
            OnShoot?.Invoke(shots);
        }
       
    }

    public void attack()
    {
        Debug.Log($"Attacking with {weapons.weaponName}!Damage : {weapons.damage}");
        
    }
}
