using UnityEngine;
using UnityEngine.Events;

namespace Currency
{
    public class CurrencyManager : MonoBehaviour
    {
        public UnityEvent<int> MoneyValueChanged;
        [SerializeField] private int _defaultMoneyValue = 30000;
        private int _money;

        private void Start()
        {
            // Получаем деньги игрока из PlayerPrefs:
            var money = PrefsManager.LoadMoney();
            _money = money == -1 ? _defaultMoneyValue : money;
            
            MoneyValueChanged.Invoke(_money);
        }

        public bool TryBuy(int price)
        {
            if (_money >= price)
            {
                _money -= price;
                
                // Сохраняем деньги игрока в PlayerPrefs:
                PrefsManager.SaveMoneyProgress(_money);
                MoneyValueChanged.Invoke(_money);
                return true;
            }

            return false;
        }
    }
}