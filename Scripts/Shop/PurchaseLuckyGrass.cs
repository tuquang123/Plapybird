using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UserData;

namespace Shop
{
    /// <summary>
    /// Button Buy Lucky Grass and x2 Value Mystic bag = true;
    /// </summary>
    public class PurchaseLuckyGrass : MonoBehaviour
    {
        Button _purchaseBt ;
        [SerializeField] private int price;

        private void Awake()
        {
            _purchaseBt = GetComponent<Button>();
            _purchaseBt.onClick.AddListener(X2ValueBag);
        }
        //leaf clover
        public void X2ValueBag()
        {
            if (UserInventory.Instance.currentMoney >= price )
            {
                UserInventory.Instance.SubtractMoney(price);
                UserInventory.Instance.x2ValueBag = true;
                Debug.Log("X2 value bag mystic");
                Destroy(gameObject);
            }

        }
    }
}