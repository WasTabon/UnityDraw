using Draw.Scripts.System.Input;
using UnityEngine;

namespace Draw.Scripts.Gameplay.Brush
{
    public class Brush : MonoBehaviour
    {
        [SerializeField] private LayerMask _drawableLayerMask;
        
        private InputManager _inputManager;
        private Movement _movement;
        private Painter _painter;

        private bool _isInitialized;
        
        public void Initialize(InputManager inputManager, Renderer drawableRrenderer)
        {
            _movement = new Movement(gameObject.transform);
            _painter = new Painter(transform, drawableRrenderer, _drawableLayerMask);
            
            _inputManager = inputManager;
            
            _inputManager.OnMouseMoved += _movement.MoveHandler;
            _inputManager.OnLeftMousePressed += _painter.Paint;
            
            _isInitialized = true;
        }

        private void Update()
        {
            
        }

        private void OnDisable()
        {
            _inputManager.OnMouseMoved -= _movement.MoveHandler;
        }
    }
}
