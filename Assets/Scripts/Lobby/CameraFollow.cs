using Hero;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private Vector3 _offset;
    private Transform _player;
    
    private void Awake()
    {
        _playerSpawner.PlayerSpawned += StartFollowingPlayer;
    }

    private void LateUpdate()
    {
        if (!_player)
        {
            return;
        }

        transform.position = _player.position + _offset;
    }

    private void StartFollowingPlayer(HeroController player)
    {
        _player = player.transform;
    }
}