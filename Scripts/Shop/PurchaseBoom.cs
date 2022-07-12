using UnityEngine;
using UnityEngine.UI;
using UserData;

namespace Shop
{
    /// <summary>
    ///button buy x1 Boom And Boom ++ 
    /// </summary>
    public class PurchaseBoom : MonoBehaviour
    {
        Button _purchaseBt ;
        [SerializeField] private int price;

        private void Awake()
        {
            _purchaseBt = GetComponent<Button>();
            _purchaseBt.onClick.AddListener(OnButtonBuyBombClick);
        }
        //add boom
        public void OnButtonBuyBombClick()
        {
            if (UserInventory.Instance.currentMoney >= price )
            {
                //subtract Boom inventory
                UserInventory.Instance.SubtractMoney(price);
                
                // increase bomb inventory
                UserInventory.Instance.AddBoom(1);
        
                // disable button
                Destroy(gameObject);
                
                //debug
                Debug.Log("Boom++");
            }
            
        }
    }
}

// class ShopButton
// {
//     public Currenctypy current;
//     public int amount;
//
//     void OnClick()
//     {
//         UserInventory.INceraseCUrrent(current, amount);
//     }
// }
