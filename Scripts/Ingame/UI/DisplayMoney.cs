using UnityEngine;
using UnityEngine.UI;
using UserData;

namespace Ingame.UI
{
    /// <summary>
    /// Display Money in screen 
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class DisplayMoney : MonoBehaviour
    {
        [SerializeField] Text moneyValue;
        // Start is called before the first frame update
        void Awake()
        {
            moneyValue = GetComponent <Text>();
        }
        private void OnEnable()
        {
            UserInventory.OnMoneyChangedHandler += UpdateMoney;
        }
        private void OnDisable()
        {
            UserInventory.OnMoneyChangedHandler += UpdateMoney;
        }
        //update money 
        void UpdateMoney(int value)
        {
            moneyValue.text = value.ToString();
        }
    }
}
