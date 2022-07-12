using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// behavior , move Mouse , and check disable Move when collider HookTag. PingPongMovement
/// </summary>
public class Mouse : MonoBehaviour
{
    #region Variable
    
    private Vector3 _startPoint;
    private Vector3 _endPoint;
    [SerializeField] private int speed;

    #endregion //variable

    #region Private Methor

    private void Start()
    {
        var position = transform.position;
        
        _startPoint = position;
        _startPoint += Vector3.left * 2;
        _endPoint = position;
        _endPoint += Vector3.right * 2;
    }

    private void Update()
    {
        if (CheckPoint(_startPoint) || CheckPoint(_endPoint))
        {
            speed *= -1;
        }
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }
    //check position 
    bool CheckPoint(Vector3 point)
    {
        return Mathf.Floor(point.x) == Mathf.Floor(transform.position.x);
    }
    //Physics
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("HookTag"))
        {
            // DisableScript();
            this.enabled = false;
        }
    }

    #endregion
   
    
}
