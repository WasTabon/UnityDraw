using UnityEngine;

namespace Draw.Scripts.System.Utils
{
    public class TextureManager
    {
        public Texture2D texture2D { get; private set; }

        public TextureManager(Renderer renderer)
        {
            texture2D = new Texture2D(1024, 1024);
            
            renderer.material.mainTexture = texture2D;
        }
    }
}
