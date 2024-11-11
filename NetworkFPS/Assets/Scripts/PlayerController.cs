using Fusion;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : NetworkBehaviour
{

    private PlayerMovement _playerMovement;
    private Vector3 _inputDirection;
    private float mouseX;
    private float mouseY;
    private bool IsWalk;

    private void Awake() => Init();

    private void Init()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        PlayerInput();
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.blue);
    }

    public override void FixedUpdateNetwork()
    {
        PlayerObjectControl();
    }


    private void PlayerObjectControl()
    {

        if (!HasStateAuthority)
            return;

        if (_inputDirection != Vector3.zero)
        {
            _playerMovement.SetMoveSpeed(IsWalk);
            _playerMovement.SetPosition(_inputDirection.normalized);
        }

        _playerMovement.SetRotation(mouseX, mouseY);

    }
    private void PlayerInput()
    {
        if (!HasStateAuthority)
            return;

        _inputDirection.x = Input.GetAxisRaw("Horizontal");
        _inputDirection.z = Input.GetAxisRaw("Vertical");

        mouseX += Input.GetAxisRaw("Mouse X");
        mouseY -= Input.GetAxisRaw("Mouse Y");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            IsWalk = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            IsWalk = false;
        }


    }

}
