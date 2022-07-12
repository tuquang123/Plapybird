using ScriptTableObject;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shop
{
    /// <summary>
    /// Display tooltip On Mouse collision
    /// </summary>
    public class TooltipShow : MonoBehaviour
    {
        [SerializeField] InfoItem messenger;
        // Mouse collision to object
        private void OnMouseEnter()//legacy
        {
            ToolTip.Instance.SetShowTip(messenger.detail);
        }
        // Mouse exit to object
        private void OnMouseExit()
        {
            ToolTip.Instance.HideTooltip();
        }
    }
}
