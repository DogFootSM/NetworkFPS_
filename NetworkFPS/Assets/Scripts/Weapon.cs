using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : NetworkBehaviour
{
    [SerializeField] private Transform _muzzlePoint;

    private void Awake() => Init();
 

    private void Init()
    {
        _muzzlePoint.position = Camera.main.transform.position;
        _muzzlePoint.forward = Camera.main.transform.forward;
    }

}
