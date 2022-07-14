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
        //button Purchase
        Button _purchaseBt ;
        
        [SerializeField]
         private int price;

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
                
                //display Money
                UserInventory.Instance.UpdateCurrenMoney(-price);
                
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
