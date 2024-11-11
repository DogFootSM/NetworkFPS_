using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{ 
    private CharacterController _characterController;
    private PlayerStatus _playerStatus;

    private float _moveSpeed = 0f;
    private void Awake() => Init();
    
    private void Init()
    {
        _characterController = GetComponent<CharacterController>();
        _playerStatus = GetComponent<PlayerStatus>(); 
    }

    public void SetPosition(Vector3 direction)
    {
        Vector3 local = transform.TransformDirection(direction);
        _characterController.Move(local * _moveSpeed * Runner.DeltaTime); 
    }

    public void SetRotation(float mouseX, float mouseY)
    { 
        mouseX += 50f * Runner.DeltaTime; 
        transform.localRotation = Quaternion.Euler(0, mouseX, 0);  
    }

    public void SetMoveSpeed(bool isWalk)
    {
        _moveSpeed = isWalk ? _playerStatus.MoveSpeed / 2 : _playerStatus.MoveSpeed; 
    }

}
