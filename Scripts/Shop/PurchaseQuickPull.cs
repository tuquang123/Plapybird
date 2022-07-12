using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UserData;

namespace Shop
{
    /// <summary>
    /// Button Buy item QuickPull and Quick pull = true 
    /// </summary>
    public class PurchaseQuickPull : MonoBehaviour
    {
        Button _purchaseBt ;
        [SerializeField] private int price;

        private void Awake()
        {
            _purchaseBt = GetComponent<Button>();
            _purchaseBt.onClick.AddListener(QuickPull);
        }
        //power liquid
        public void QuickPull()
        {
            if (UserInventory.Instance.currentMoney >= price )
            {
                UserInventory.Instance.SubtractMoney(price);
                Destroy(gameObject);
                UserInventory.Instance.quickPull = true;
                Debug.Log("Quick pull");
            }

            //Destroy(gameObject);
        }
    }
}