using UnityEngine;

namespace Draw.Scripts.Gameplay.Brush
{
    public class Painter
    { 
        private Renderer _drawableRenderer;
        private Texture2D _texture;
        
        private LayerMask _drawableLayerMask;
        
        private Color _currentColor;
        
        private Transform _brushTransform;

        public Painter(Transform brushTransform, Renderer drawableRenderer, LayerMask drawableLayerMask)
        {
            _brushTransform = brushTransform;

            _drawableRenderer = drawableRenderer;
            _drawableLayerMask = drawableLayerMask;
            
            _currentColor = Color.red;

            _texture = _drawableRenderer.material.mainTexture as Texture2D;
            
            Debug.Log(_texture.width);
            Debug.Log(_texture.height);
        }

        public void Paint(Vector3 targetPos)
        {
            Ray ray = new Ray(targetPos, Vector3.forward);
            Debug.DrawRay(targetPos, Vector3.forward, Color.red);

            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _drawableLayerMask))
            {
                Debug.Log("Raycasted");
                
                Vector2 uv = hit.textureCoord;
                
                int x = (int)(uv.x * _texture.width);
                int y = (int)(uv.y * _texture.height);

                int brushX = (int)(25);
                int brushY = (int)(25);

                for (int i = 0; i < brushX; i++)
                {
                    for (int j = 0; j < brushY; j++)
                    {
                        _texture.SetPixel(x + i - brushX / 2, y + j - brushY / 2, _currentColor);
                    }
                }

                _texture.Apply();
            }
            else
            {
                Debug.Log("Not raycasted");
            }
        }
    }
}
