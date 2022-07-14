using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UserData;

/// <summary>
/// Button Start game when user press
/// </summary>
public class NextGameButton : MonoBehaviour
{
    //method call when button press
    public void UIPlay()
    {
        SceneManager.LoadScene(UserInventory.Instance.level);
        Debug.Log("Lever = " + UserInventory.Instance.level);
    }

    public void UIStartGame()
    {
        SceneManager.LoadScene(1);
    }
}