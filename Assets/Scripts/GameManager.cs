using System.Linq;
using Hero;
using HeroSelection;
using Lobby;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LobbyScreenManager _lobbyScreenManager;
    [SerializeField] private HeroesManager _heroesManager;
    [SerializeField] private HeroSelectionScreenManager _heroSelectionScreenManager;
    [SerializeField] private SelectedHeroHandler _selectedHeroHandler;

    private void Start()
    {
        var heroes = _heroesManager.GetHeroes();
        _selectedHeroHandler.Initialize(heroes);
        
        // Получаем выбранного героя из PlayerPrefs:
        var lastSelectedHeroSettings = _selectedHeroHandler.GetLastSelectedHeroSettings();
        var lastSelectedHero = heroes.FirstOrDefault(hero => hero.HeroSettings == lastSelectedHeroSettings);

        _heroSelectionScreenManager.Initialize(heroes);
        _lobbyScreenManager.Initialize(lastSelectedHero);
        _heroesManager.ActivateSelectedHero(lastSelectedHero);
        
        _heroSelectionScreenManager.HeroChanged += OnHeroChanged;
        _heroSelectionScreenManager.HeroSelected += OnHeroSelected;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(GlobalConstants.GAME_SCENE);
    }

    private void OnHeroChanged(HeroController selectedHero)
    {
        _heroesManager.ActivateSelectedHero(selectedHero);
    }
    
    private void OnHeroSelected(HeroController selectedHero)
    {
        // Сохраняем выбранного героя в PlayerPrefs:
        _selectedHeroHandler.SetLastSelectedHero(selectedHero);
    }

    private void OnDestroy()
    {
        _heroSelectionScreenManager.HeroChanged -= OnHeroChanged;
        _heroSelectionScreenManager.HeroSelected -= OnHeroSelected;
    }
}