using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SubsystemsImplementation;

/// <summary>
/// Game Manager 
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Init, config
    [SerializeField] 
    private GameObject gameStart;  // Ui game Start
    [SerializeField] 
    private GameObject []dayNight; // array background
    [SerializeField]
    private GameObject score;      // UI score
    void Start()
    {
        dayNight[Random.Range(0,dayNight.Length)].SetActive(true); // random background
        Time.timeScale = 1;
    }
    #endregion// Init config

    // enum userState
    // {
    //     abcxyz,
    //     adfa,
    //     adfaf,
    //     
    // }

    // #region Public
    // /// <summary>
    // /// Return current score of Player
    // /// </summary>
    // public int ABC()
    // {
    //     if (true)
    //     {
    //         // abc
    //         int a = 1;
    //         switch (a)
    //         {
    //             case 1:
    //                 return 1;
    //             default:
    //                 Debug.LogError("Not handle for value ...");
    //                 return;
    //         }
    //     }
    //     // else
    //     // {
    //     //     // user data error
    //     //     Debug.LogError("");
    //     // }
    //     return 0;
    // }
    // #endregion//public
    

    #region UI callbacks
    /// <summary>
    /// called from UI, config button ABC to invoke
    /// </summary>
    public void Replay() // restart game after click button
    {
        SceneManager.LoadScene(0);
    }
    
    public void Started() // start game after click button 
    {
        this.gameStart.SetActive(false);
        Time.timeScale = 1;
        score.SetActive(true);
    }
    #endregion//UI callbacks
}
