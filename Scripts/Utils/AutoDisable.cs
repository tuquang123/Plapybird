using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Disable banner after 2f start game 
/// </summary>
public class AutoDisable : MonoBehaviour
{
    public GameObject banner;
    public float timer = 1.5f;
    private void Start()
    {
        banner.SetActive(true);
        StartCoroutine(DisableBanner());
    }
    IEnumerator DisableBanner()
    {
        yield return new WaitForSeconds(timer);
        banner.SetActive(false);
    }
}

