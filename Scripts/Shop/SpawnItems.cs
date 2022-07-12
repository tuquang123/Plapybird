using UnityEngine;
using Random = UnityEngine.Random;

namespace Shop
{
    /// <summary>
    /// random active item shop 
    /// </summary>
    public class SpawnItems : MonoBehaviour
    {
        [SerializeField] GameObject[] button;

        private void Start()
        {
            for (int i = 0; i < button.Length; i++)
            {
                // random value return 0 -> 1 
                if (Random.value < 0.5)
                {
                    //active true 
                    button[i].SetActive(true);
                }
                else
                {
                    //active false
                    button[i].SetActive(false);
                }
                Debug.Log(Random.value);
            }
        }
    }
}
