using System.Collections.Generic;
using Hero;
using Hero.Settings;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectedHeroHandler", menuName = "ScriptableObjects/SelectedHeroHandler", order = 51)]
public class SelectedHeroHandler : ScriptableObject
{
    [SerializeField]
    private List<HeroController> _heroControllers;
    private Dictionary<string, HeroSettings> _heroSettingsByName = new();
    private Dictionary<string, HeroController> _heroPrefabsByName = new();

    public void Initialize(IReadOnlyList<HeroController> heroControllers)
    {
        for (var i = 0; i < _heroControllers.Count; i++)
        {
            // Сохраняем в массив префабов героев актуальные настройки:
            var heroController = _heroControllers[i];
            heroController.HeroSettings = heroControllers[i].HeroSettings;
            
            // Заполняем соответствующие словари:
            _heroSettingsByName.Add(heroController.HeroSettings.Name, heroController.HeroSettings);
            _heroPrefabsByName.Add(heroController.HeroSettings.Name, heroController);
        }
    }
    
    public HeroSettings GetLastSelectedHeroSettings()
    {
        var prefabName = PrefsManager.LoadHero();

        // Если сохраненный герой есть - возвращаем его, если нет - берем первого:
        return _heroPrefabsByName.ContainsKey(prefabName) ? 
            _heroSettingsByName[prefabName] : 
            _heroControllers[0].HeroSettings;
    }

    public HeroController GetLastSelectedHeroPrefab()
    {
        var prefabName = PrefsManager.LoadHero();

        // Если сохраненный герой есть - возвращаем его, если нет - берем первого:
        return _heroPrefabsByName.ContainsKey(prefabName) ? 
            _heroPrefabsByName[prefabName] : 
            _heroControllers[0];
    }
    
    public void SetLastSelectedHero(HeroController hero)
    {
        PrefsManager.SaveCurrentHero(hero.HeroSettings.Name);
    }
}