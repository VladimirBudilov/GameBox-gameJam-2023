using Cinemachine;
using UnityEngine;

namespace Components.CameraBased
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class SetFollowComponent :MonoBehaviour
    {
        private void Start()
        {
            var vCamera = GetComponent<CinemachineVirtualCamera>();
            vCamera.Follow = FindObjectOfType<CameraFollowComponent>().transform;
        }
    }
}