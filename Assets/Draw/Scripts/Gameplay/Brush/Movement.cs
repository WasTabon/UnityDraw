using Draw.Scripts.System.Input;
using UnityEngine;

namespace Draw.Scripts.Gameplay.Brush
{
    public class Movement
    {
        private Transform _brushTransform;
        
        public Movement(Transform brushTransform ,InputManager inputManager)
        {
            _brushTransform = brushTransform;
            inputManager.OnMouseMoved += Move;
        }

        public void Move(Vector3 targetPos)
        {
            targetPos.z = -1.5f;
            _brushTransform.position = targetPos;
        }
    }
}
