using Ingame;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shop
{
    public class ToolTip : Singleton<ToolTip>
    {
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;
        
        /*#region SingleTon
        public static ToolTip Instance;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }
        #endregion //singleton*/

        #region Private Method 

        private void Start()
        {
            Cursor.visible = true;
            gameObject.SetActive( true);
        }
        void Update()
        {
            //transform.position = Input.mousePosition;
        }
        /// <summary>
        /// Send String mess and display , call to mouse collision
        /// </summary>
        /// <param name="mes"></param>
        public void SetShowTip(string mes)
        {
            gameObject.SetActive(true);
            textMeshProUGUI.text = mes;
        }
        /// <summary>
        /// disable tooltip , call to mouse collison
        /// </summary>
        public void HideTooltip()
        {
            gameObject.SetActive(false);
            textMeshProUGUI.text = string.Empty;
        }

        #endregion// private 
    }
}
