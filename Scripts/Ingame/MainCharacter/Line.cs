using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Class Active Line Renderer 
/// </summary>
public class Line : MonoBehaviour
{
    #region Variable

    private LineRenderer _lineRenderer;
    
    [SerializeField] 
    private Transform startPoint;
    
    private Vector3 _vectorStart;
    
    private Vector3 _vectorEnd;
    
    #endregion //variable

    #region Private
    private void Start()
    {
        _vectorStart = startPoint.position;
        
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.SetPosition(0,_vectorStart);
        _lineRenderer.SetPosition(1,transform.position);
    }
    private void Update()
    {
        _lineRenderer.SetPosition(1,transform.position);
    }
    #endregion //Private
}
