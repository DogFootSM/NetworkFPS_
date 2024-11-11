using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined, IPlayerLeft
{
    [Range(0, 10)]
    [SerializeField] private float spawnRange;

    [SerializeField] private GameObject _playerPrefab;

    private Vector3 spawnPos;

    public void PlayerJoined(PlayerRef player)
    {
        if (player != Runner.LocalPlayer)
            return;

        float xPos = Random.Range(-spawnRange, spawnRange);
        float zPos = Random.Range(-spawnRange, spawnRange);
        spawnPos = new Vector3(xPos, 0, zPos);

        NetworkObject obj = Runner.Spawn(_playerPrefab, spawnPos, Quaternion.identity);
        Camera.main.GetComponent<CameraController>().Target = obj.transform;

    }

    public void PlayerLeft(PlayerRef player)
    {

    }
    


}
