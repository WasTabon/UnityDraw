using System.IO;
using System.Threading.Tasks;
using Draw.Scripts.UI;
using UnityEngine;

namespace Draw.Scripts.System.Utils
{
    public class TextureManager
    {
        private const int TextureWidth = 1024;
        private const int TextureHeight = 1024;
        
        private Texture2D _texture2D;
        private Renderer _drawableRenderer;

        public TextureManager(Renderer drawableRenderer, UIManager uiManager)
        {
            _drawableRenderer = drawableRenderer;
            
            uiManager.OnClear += ClearTexture;
            
            _texture2D = new Texture2D(TextureWidth, TextureHeight);
            _drawableRenderer.material.mainTexture = _texture2D;
        }
        
        private void ClearTexture()
        {
            Color[] clearPixels = new Color[_texture2D.width * _texture2D.height];

            for (int i = 0; i < clearPixels.Length; i++)
            {
                clearPixels[i] = Color.white;
            }

            _texture2D.SetPixels(clearPixels);
            _texture2D.Apply();        
        }

        public async Task SaveTextureAsync(string filePath)
        {
            _texture2D.Apply();
            
            byte[] textureBytes = _texture2D.EncodeToPNG();
            
            await Task.Run(() => File.WriteAllBytes(filePath, textureBytes));
        }

        public async Task LoadTextureAsync(string filePath)
        {
            if (File.Exists(filePath))
            {
                byte[] textureBytes = await Task.Run(() => File.ReadAllBytes(filePath));

                _texture2D.LoadImage(textureBytes);
                _texture2D.Apply();
            }
            else
            {
                Debug.LogError($"File not found: {filePath}");
            }
        }
        
    }
}
