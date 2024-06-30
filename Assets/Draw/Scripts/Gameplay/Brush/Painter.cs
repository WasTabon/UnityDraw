using UnityEngine;

namespace Draw.Scripts.Gameplay.Brush
{
    public class Painter
    { 
        private Renderer _drawableRenderer;
        private Texture2D _texture;
        
        private LayerMask _drawableLayerMask;
        
        private Color _currentColor;

        private int _brushSize = 15;

        public Painter(Renderer drawableRenderer, LayerMask drawableLayerMask)
        {
            _drawableRenderer = drawableRenderer;
            _drawableLayerMask = drawableLayerMask;
            
            _currentColor = Color.red;

            _texture = _drawableRenderer.material.mainTexture as Texture2D;
        }

        public void ChangeColor(Color color)
        {
            _currentColor = color;
        }

        public void ChangeBrushSize(int size)
        {
            _brushSize = size;
        }
        
        public void Paint(Vector3 targetPos)
        {
            Ray ray = new Ray(targetPos, Vector3.forward);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _drawableLayerMask))
            {
                Vector2 uv = hit.textureCoord;
                
                int x = (int)(uv.x * _texture.width);
                int y = (int)(uv.y * _texture.height);

                for (int i = 0; i < _brushSize; i++)
                {
                    for (int j = 0; j < _brushSize; j++)
                    {
                        _texture.SetPixel(x + i - _brushSize / 2, y + j - _brushSize / 2, _currentColor);
                    }
                }

                _texture.Apply();
            }
        }
    }
}
