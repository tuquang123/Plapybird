using System;
using System.Collections.Generic;
using Ingame;
using UnityEngine;

namespace UserData
{
    /// <summary>
    /// GameManage time and Check next scene
    /// </summary>
    public class UserInventory: Singleton<UserInventory>
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        [Header("Data")]
        #region DataUser Public
    
        //Money 
        public int currentMoney;
    
        [Header("Item")]
        
        [Range(0,10)]
        [SerializeField]
        private int boom; 
        
        public bool quickPull;

        public bool x3PrinceRock;

        public bool x2ValueBag;
        
        public int level;
        
        public int goal = 650;

        public bool checkBoom;

        public bool GetBoomState()
        {
            return checkBoom;
        }

        /*public bool SetBoom(bool value)
        {
            checkBoom = value;
            // notify
            
        }*/
        
        #endregion // data
        public static event Action <int> OnMoneyChangedHandler;
        public event Action <int> OnBombChangedHandler;
        void Save()
        {
            PlayerPrefs.SetInt("lv", level);
        }
        public void SubtractMoney(int money)
        {
            currentMoney -= money;
        }
      
        /// <summary>
        /// add Boom
        /// </summary>
        /// <param name="boomPar"></param>
        public void AddBoom(int boomPar)
        {
            // check limit
            
            this.boom += boomPar;
            
            // validate, notify
            
            OnBombChangedHandler?.Invoke(this.boom);
        }

        #region Manager boom
        /// <summary>
        /// return value boom 
        /// </summary>
        /// <returns></returns>
        public int BoomInt()
        {
            return this.boom ;
        }
        /// <summary>
        /// Subtract Bom 
        /// </summary>
        /// <param name="boomPar"></param>
        /// <returns></returns>
        public int BoomSubtract(int boomPar)
        {
            return this.boom -= boomPar ;
        }
        
        #endregion // manager boom
        /// <summary>
        /// reset after next scene play
        /// </summary>
        public void ResetUserInventory()
        {
            quickPull = false;
            x3PrinceRock = false;
            x2ValueBag = false;
        }
        /// <summary>
        /// Update and display money
        /// </summary>
        /// <param name="value"></param>
        public void UpdateCurrenMoney(int value)
        {
            // update data
            currentMoney += value ;
            // notification
            OnMoneyChangedHandler?.Invoke(currentMoney);
            // if (onMoneyChangedHandler != null)
            // {
            //     onMoneyChangedHandler(currentMoney);
            // }
        }

        /*public enum CurrencyType
        {
            gold, diamond, coin, cash, titan
        }

        public class CurrencyInfo
        {

        public CurrencyType type;
        public int amount;
        }

        List<CurrencyInfo>*/
    }
}
