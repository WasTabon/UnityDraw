using UnityEngine;

namespace Draw.Scripts.System.Utils
{
    public class TextureManager
    {
        private Texture2D _texture2D;

        public TextureManager(Renderer drawableRenderer)
        {
            _texture2D = new Texture2D(1024, 1024);
            
            drawableRenderer.material.mainTexture = _texture2D;
        }
    }
}
