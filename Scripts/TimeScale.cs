using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// time scale = 0 when animation game over done 
/// </summary>
public class TimeScale : MonoBehaviour
{
    void Pause()
    {
        Time.timeScale = 0;
    }
    
}
