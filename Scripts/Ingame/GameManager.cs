using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UserData;

namespace Ingame
{
    public class GameManager : MonoBehaviour
    {
        [Header("Variable")]

        #region Variable

        #region Private 
    
        [SerializeField] float startTimer  = 10f;
    
        [SerializeField] string scene = "Shop";
    
        [SerializeField] Text textTimer;
    
        //[SerializeField] Text textLevel;
    
        //[SerializeField] Text textGoal;

        [SerializeField] GameObject bannerWin;

        [SerializeField] GameObject bannerLoss;
    
        private float timeDisable = 1f;

        #endregion //private
    
        #endregion // variable
    
        #region Private Method
        private void Update()
        {
            //textLevel.text = UserInventory.Instance.goal.ToString();
            //textGoal.text = UserInventory.Instance.level.ToString();
            startTimer -= Time.deltaTime;
            textTimer.text = startTimer.ToString("F0");
        
            if (startTimer <= 0 && UserInventory.Instance.currentMoney >= UserInventory.Instance.goal )
            {
                bannerWin.SetActive((true));
                StartCoroutine(SceneShop());
            }
            if (startTimer <= 0 && UserInventory.Instance.currentMoney <= UserInventory.Instance.goal)
            {
                bannerLoss.SetActive(true);
                StartCoroutine(SceneStart());
                UserInventory.Instance.currentMoney = 0;
                UserInventory.Instance.ResetUserInventory();
            }
        }
        /// <summary>
        /// Load Scene Shop 
        /// </summary>
        /// <returns></returns>
        IEnumerator SceneShop()
        {
            yield return new WaitForSeconds(timeDisable);
            SceneManager.LoadScene(scene);
            UserInventory.Instance.ResetUserInventory();
            
            UserInventory.Instance.level++;// save level
            UserInventory.Instance.goal *= 2;
        }
        /// <summary>
        /// Load Next Scene
        /// </summary>
        /// <returns></returns>
        IEnumerator SceneStart()
        {
            yield return new WaitForSeconds(timeDisable);
            SceneManager.LoadScene(0);
        }
        #endregion //Private
    }
}
