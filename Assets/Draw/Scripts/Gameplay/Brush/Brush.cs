using Draw.Scripts.System.Input;
using Draw.Scripts.UI;
using UnityEngine;

namespace Draw.Scripts.Gameplay.Brush
{
    public class Brush
    {
        private InputManager _inputManager;
        private UIManager _uiManager;
        private Movement _movement;
        private Painter _painter;
        
        public Brush(InputManager inputManager, UIManager uiManager, Renderer drawableRrenderer, LayerMask drawableLayerMask, Transform transform)
        {
            _movement = new Movement(transform);
            _painter = new Painter(drawableRrenderer, drawableLayerMask);
            
            _inputManager = inputManager;
            _uiManager = uiManager;
            
            _inputManager.OnMouseMoved += _movement.MoveHandler;
            _inputManager.OnLeftMousePressed += _painter.Paint;
            _uiManager.OnColorChanged += _painter.ChangeColor;
            _uiManager.OnBrushSizeChanged += _painter.ChangeBrushSize;
        }
        
        public void Cleanup()
        {
            _inputManager.OnMouseMoved -= _movement.MoveHandler;
            _inputManager.OnLeftMousePressed -= _painter.Paint;
                
            _uiManager.OnColorChanged -= _painter.ChangeColor;
            _uiManager.OnBrushSizeChanged -= _painter.ChangeBrushSize;
        }
    }
}
