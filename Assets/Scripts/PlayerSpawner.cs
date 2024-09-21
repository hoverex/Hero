using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Transform _playerRoot;
    [SerializeField] private SelectedHeroHandler _selectedHeroHandler;

    private void Start()
    {
        // Получаем префаб выбранного героя:
        var selectedHero = _selectedHeroHandler.GetLastSelectedHeroPrefab();
        Instantiate(selectedHero, _playerRoot);
    }
}