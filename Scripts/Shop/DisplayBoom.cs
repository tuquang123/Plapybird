using System.Collections.Generic;
using Ingame;
using UnityEngine;
using UserData;

namespace Shop
{
    /// <summary>
    /// Display Boom In UI
    /// </summary>
    public class DisplayBoom : Singleton<DisplayBoom>
    {
        [SerializeField] 
        GameObject [] imageBoomPrefab;
        [SerializeField] 
        int boom;

        private List<GameObject> _activeBombUI;
        private void Start()
        {
            for (int i = 0; i < UserInventory.Instance.BoomInt(); i++)
            {
                imageBoomPrefab[i].SetActive(true);
                _activeBombUI.Add(imageBoomPrefab[i]);
            }
            // listen to bomb change
            UserInventory.Instance.OnBombChangedHandler += OnBombChanged;
        }

        void OnBombChanged(int bomb)
        {
            // update UI, destroy.....
        }
        
        
        public void BoomUpdate()
        {
            if (UserInventory.Instance.checkBoom)
            {
                imageBoomPrefab[boom].SetActive(false); 
                UserInventory.Instance.checkBoom = false;
                boom++;
            }
        }
    }
}
