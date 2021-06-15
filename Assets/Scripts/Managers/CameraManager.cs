#pragma warning disable 0649

using System;
using Gameplay;
using UnityEngine;
using Utils;

namespace Managers
{
    [RequireComponent(typeof(Camera))]
    public class CameraManager : Singleton<CameraManager>
    {
        [SerializeField] private PlayerController player;

        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            _camera.transform.position = GetPlayerPosition();
        }

        private Vector3 GetPlayerPosition()
        {
            var oldPosition = _camera.transform.position;
            
            try
            {
                var newPosition = player.transform.position;
                newPosition.z = oldPosition.z;
                return newPosition;
            }
            catch (NullReferenceException)
            {
                return oldPosition;
            }
        }
    }
}
