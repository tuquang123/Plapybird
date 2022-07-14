using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UserData;

namespace Shop
{
    /// <summary>
    /// Button buy x3 Rock And X3 Prince Rock = true
    /// </summary>
    public class PurchaseX3Rock : MonoBehaviour
    {
        Button _purchaseBt ;
        [SerializeField] private int price;

        private void Awake()
        {
            _purchaseBt = GetComponent<Button>();
            _purchaseBt.onClick.AddListener(X3MoneyRock);
        }
        // rock
        public void X3MoneyRock()
        {
            if (UserInventory.Instance.currentMoney >= price )
            {
                UserInventory.Instance.SubtractMoney(price);
                UserInventory.Instance.UpdateCurrenMoney(-price);
                //UserInventory.Instance.UpdateCurrenMoney(price);
                Destroy(gameObject);
                UserInventory.Instance.x3PrinceRock = true;
                Debug.Log("Money rock");
            }

        }
    }
}