using System;
using Draw.Scripts.Interfaces;
using UnityEngine;

namespace Draw.Scripts.System.Input
{
    public class InputManager : IUpdatable
    {
        public event Action<Vector3> OnMouseMoved; // Изменено на Vector3 для сохранения координаты Z

        private Vector3 _lastMousePos;
        private readonly Camera _camera;
        private const float FixedZ = -1.5f; // Фиксированная координата Z

        public InputManager(Camera camera)
        {
            _lastMousePos = Vector3.zero;
            _camera = camera;
        }

        public void Update()
        {
            Vector3 currentMousePosition = UnityEngine.Input.mousePosition;
            if (currentMousePosition != _lastMousePos)
            {
                _lastMousePos = currentMousePosition;

                Ray ray = _camera.ScreenPointToRay(currentMousePosition);

                Vector3 targetPosition;
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    targetPosition = hit.point;
                }
                else
                {
                    // Вычисление точки на плоскости Z = FixedZ
                    float distance = (FixedZ - ray.origin.z) / ray.direction.z;
                    targetPosition = ray.origin + ray.direction * distance;
                }

                OnMouseMoved?.Invoke(targetPosition);
            }
        }
    }
}