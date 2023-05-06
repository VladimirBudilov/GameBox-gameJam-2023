using UnityEngine;

namespace Components.Audio
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private string _id;
        [SerializeField] private AmbientChanger _ambientChanger;
        [ContextMenu("Test")]
        public void TestAmbient()
        {
            _ambientChanger.ChangeClip(_id);
        }
    }
}