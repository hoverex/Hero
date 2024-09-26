using System;
using Hero;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Action<HeroController> PlayerSpawned;
    [SerializeField] private Transform _playerRoot;
    [SerializeField] private SelectedHeroHandler _selectedHeroHandler;

    private void Start()
    {
        // Получаем префаб выбранного героя:
        var selectedHero = _selectedHeroHandler.GetLastSelectedHeroPrefab();
        var player = Instantiate(selectedHero, _playerRoot);
        PlayerSpawned?.Invoke(player);
    }
}