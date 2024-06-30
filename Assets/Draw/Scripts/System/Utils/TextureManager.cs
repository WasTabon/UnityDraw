using System.IO;
using System.Threading.Tasks;
using Draw.Scripts.UI;
using UnityEngine;

namespace Draw.Scripts.System.Utils
{
    public class TextureManager
    {
        private static readonly string SaveDirectory = Application.dataPath + "/SavedTextures/";
        private static readonly string SaveFilePath = SaveDirectory + "texture.png";
        
        private const int TextureWidth = 1024;
        private const int TextureHeight = 1024;

        private UIManager _uiManager;
        private Texture2D _texture2D;
        private Renderer _drawableRenderer;

        public TextureManager(Renderer drawableRenderer, UIManager uiManager)
        {
            _drawableRenderer = drawableRenderer;
            _uiManager = uiManager;
            
            _uiManager.OnClear += ClearTexture;
            _uiManager.OnSave += async () => await SaveTextureAsync();
            _uiManager.OnLoad += async () => await LoadTextureAsync();
            
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

        private async Task SaveTextureAsync()
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }

            _texture2D.Apply();

            byte[] textureBytes = _texture2D.EncodeToPNG();

            await File.WriteAllBytesAsync(SaveFilePath, textureBytes);
        }

        private async Task LoadTextureAsync()
        {
            if (File.Exists(SaveFilePath))
            {
                byte[] textureBytes = await File.ReadAllBytesAsync(SaveFilePath);

                _texture2D.LoadImage(textureBytes);
                _texture2D.Apply();
            }
        }
    }
}
