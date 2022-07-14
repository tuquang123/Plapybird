using UnityEngine;

namespace Utils
{
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
}
