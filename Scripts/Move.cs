using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// move Pipe
/// </summary>
public class Move : MonoBehaviour
{
    private float speed = 1;
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; // move to the left
    }
}
