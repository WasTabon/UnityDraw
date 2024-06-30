using Draw.Scripts.UI;
using UnityEngine;

namespace Draw.Scripts.System.Utils
{
    public class TextureManager
    {
        private Texture2D _texture2D;
        private Renderer _drawableRenderer;

        public TextureManager(Renderer drawableRenderer, UIManager uiManager)
        {
            _drawableRenderer = drawableRenderer;

            uiManager.OnClear += CreateEmptyTexture;
            
            CreateEmptyTexture();
        }
        
        private void CreateEmptyTexture()
        {
            _texture2D = new Texture2D(1024, 1024);
            
            _drawableRenderer.material.mainTexture = _texture2D;
        }
        
    }
}
