using Draw.Scripts.System.Input;
using UnityEngine;

namespace Draw.Scripts.Gameplay.Brush
{
    public class Brush : MonoBehaviour
    {
        private InputManager _inputManager;
        private Movement _movement;

        private bool _isInitialized;
        
        public void Initialize(InputManager inputManager)
        {
            _movement = new Movement(gameObject.transform);
            _inputManager = inputManager;
            
            _inputManager.OnMouseMoved += _movement.MoveHandler;
            
            _isInitialized = true;
        }

        private void OnDisable()
        {
            _inputManager.OnMouseMoved -= _movement.MoveHandler;
        }
    }
}
