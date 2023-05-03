using UnityEngine;

namespace Components.GameplayObjects.Rope
{
    public class RopeLinkComponent : MonoBehaviour
    {
        [ContextMenu("showTransform")]
        public void ShowTransform()
        {
            Debug.Log($"position = {transform.position}, localposition = {transform.localPosition}");
        }
    }
}