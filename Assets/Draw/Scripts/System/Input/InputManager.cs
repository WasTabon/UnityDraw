using System;
using Draw.Scripts.Interfaces;
using UnityEngine;

namespace Draw.Scripts.System.Input
{
    public class InputManager : IUpdatable
    {
        private const float FixedZ = -1.5f;
        
        public event Action<Vector3> OnMouseMoved;
        
        private Vector3 _targetPosition;
        private Vector3 _currentMousePosition;

        private float _distance;

        public void Update()
        {
            _currentMousePosition = UnityEngine.Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(_currentMousePosition);
                
            _distance = (FixedZ - ray.origin.z) / ray.direction.z;
            _targetPosition = ray.origin + ray.direction * _distance;

            OnMouseMoved?.Invoke(_targetPosition);
        }
    }
}