using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAbilityShoot : PlayerAbilityBase
{

    public List<GunBase> gunPrefabs;
    public Transform gunPosition;

    private GunBase _currentGun;
    private int _currentGunIndex;
    private List<GunBase> _instantiatedGuns = new List<GunBase>();

    protected override void Init()
    {
        base.Init();

        CreateGun();

        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => CancelShoot();

        
        inputs.Gameplay.SwapToGun1.performed += cts => ChangeGun(0);
        inputs.Gameplay.SwapToGun2.performed += cts => ChangeGun(1);
    }

    private void CreateGun()
    {
        _currentGunIndex = 0;
        InstantiateGuns();
        SetCurrentGun(_currentGunIndex);

    }

    private void InstantiateGuns()
    {
        foreach (var gunPrefab in gunPrefabs)
        {
            var gun = Instantiate(gunPrefab, gunPosition);
            gun.transform.localPosition = gun.transform.localEulerAngles = Vector3.zero;
            gun.gameObject.SetActive(false);
            _instantiatedGuns.Add(gun);
        }
    }

    private void SetCurrentGun(int index)
    {
        if (_currentGun != null)
        {
            _currentGun.gameObject.SetActive(false); // Desativa o gun atual
        }
        _currentGunIndex = index;
        _currentGun = _instantiatedGuns[_currentGunIndex];
        _currentGun.gameObject.SetActive(true);
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
        Debug.Log("Start Shoot");
    }       

    private void CancelShoot()
    {
        Debug.Log("Cancel Shoot");
        _currentGun.StopShoot();
    }

    private void ChangeGun(int index)
    {
        if (index < 0 || index >= _instantiatedGuns.Count) return;
        SetCurrentGun(index);
    }
}
