using System;
using Draw.Scripts.Interfaces;
using UnityEngine;
using static UnityEngine.Input;

namespace Draw.Scripts.System.Input
{
    public class InputManager : IUpdatable
    {
        private const float FixedZ = -1.5f;
        
        public event Action<Vector3> OnMouseMoved;
        public event Action<Vector3> OnLeftMousePressed;
        
        private Vector3 _targetPosition;
        private Vector3 _currentMousePosition;

        private float _distance;

        public void Update()
        {
            GetMouseInput();
            GetLeftMousePress();
        }

        private void GetMouseInput()
        {
            OnMouseMoved?.Invoke(PositionOfMouse());
        }

        private void GetLeftMousePress()
        {
            if (GetMouseButton(0))
            {
                OnLeftMousePressed?.Invoke(PositionOfMouse());
            }
        }

        private Vector3 PositionOfMouse()
        {
            _currentMousePosition = mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(_currentMousePosition);
                
            _distance = (FixedZ - ray.origin.z) / ray.direction.z;
            _targetPosition = ray.origin + ray.direction * _distance;
            return _targetPosition;
        }
    }
}