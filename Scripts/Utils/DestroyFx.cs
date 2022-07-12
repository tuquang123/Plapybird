using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// when animation fx end , fx will destroy after 1.5f
/// </summary>
public class DestroyFx : MonoBehaviour
{
    //call to key a animation
    public void DestroyFxboom()
    {
        Destroy(gameObject);
    }
}
