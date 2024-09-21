using UnityEngine;
/// <summary>
/// Класс, сохраняющий прогресс при помощи PlayerPrefs
/// </summary>
public class PrefsManager
{
    private const string MONEY_KEY = "Money";
    private const string HERO_KEY = "Hero";
    private const string HERO_BOUGHT_KEY = "BougthHero_{0}";

    public static void SaveCurrentHero(string heroName)
    {
        PlayerPrefs.SetString(HERO_KEY, heroName);
        PlayerPrefs.Save();
    }
    
    public static string LoadHero()
    {
        return PlayerPrefs.GetString(HERO_KEY);
    }

    public static void SaveMoneyProgress(int level)
    {
        PlayerPrefs.SetInt(MONEY_KEY, level);
        PlayerPrefs.Save();
    }

    public static int LoadMoney()
    {
        // Если деньги еще не были сохранены - возвращаем -1; 
        if (!PlayerPrefs.HasKey(MONEY_KEY))
        {
            return -1;
        }
        
        return PlayerPrefs.GetInt(MONEY_KEY);
    }

    public static bool WasHeroBought(string name)
    {
        // Если значение ключа с заданным именем равно 1 - значит такой ключ сохранен 
        // Смотри метод SaveNewBoughtHero
        return PlayerPrefs.GetInt(string.Format(HERO_BOUGHT_KEY, name)) == 1;
    }

    public static void SaveNewBoughtHero(string name)
    {
        // Сохраняем имя купленного героя при помощи string.Format "BougthHero_{0}"
        // Таким образом, для каждого купленного героя будет свой ключ в формате "BougthHero_{0}",
        // где вместо {0} будет подставлено ИмяГероя
        var key = string.Format(HERO_BOUGHT_KEY, name);
        // Значение для каждого ключа равно 1
        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();
    }
}