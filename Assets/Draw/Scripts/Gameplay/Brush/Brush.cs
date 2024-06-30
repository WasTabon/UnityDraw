using Draw.Scripts.System.Input;
using Draw.Scripts.UI;
using UnityEngine;

namespace Draw.Scripts.Gameplay.Brush
{
    public class Brush : MonoBehaviour
    {
        [SerializeField] private LayerMask _drawableLayerMask;
        
        private InputManager _inputManager;
        private UIManager _uiManager;
        private Movement _movement;
        private Painter _painter;

        private bool _isInitialized;
        
        public void Initialize(InputManager inputManager, UIManager uiManager, Renderer drawableRrenderer)
        {
            _movement = new Movement(gameObject.transform);
            _painter = new Painter(drawableRrenderer, _drawableLayerMask);
            
            _inputManager = inputManager;
            _uiManager = uiManager;
            
            _inputManager.OnMouseMoved += _movement.MoveHandler;
            _inputManager.OnLeftMousePressed += _painter.Paint;
            _uiManager.OnColorChanged += _painter.ChangeColor;
            _uiManager.OnBrushSizeChanged += _painter.ChangeBrushSize;
            
            _isInitialized = true;
        }

        private void OnDisable()
        {
            //_inputManager.OnMouseMoved -= _movement.MoveHandler;
            //_inputManager.OnLeftMousePressed -= _painter.Paint;
            //_uiManager.OnColorChanged -= _painter.ChangeColor;
            //_uiManager.OnBrushSizeChanged -= _painter.ChangeBrushSize;
        }
    }
}
