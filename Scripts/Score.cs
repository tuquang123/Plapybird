using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// score and highscore
/// </summary>
public class Score : MonoBehaviour
{
    [Header("Scene ref")]
    [SerializeField] 
    private Text textScore;
    [SerializeField] 
    private Text textHighScore;
    
    public static int score = 0;
    private int _highScore = 0; 
    void Start()
    {
        score = 0;
        _highScore = 0;
        _highScore = PlayerPrefs.GetInt(("highScore"));
    }
    void Update()
    {
        textHighScore.text = _highScore.ToString();
        textScore.text= score.ToString();
        if (score > _highScore)
        {
            PlayerPrefs.SetInt("highScore",score);
        }
    }
}