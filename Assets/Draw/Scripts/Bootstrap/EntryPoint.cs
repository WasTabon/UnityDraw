using Draw.Scripts.Gameplay.Brush;
using Draw.Scripts.ScriptableObjects.UI;
using Draw.Scripts.System.Input;
using Draw.Scripts.System.Utils;
using Draw.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Draw.Scripts.Bootstrap
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Brush _brush;
        [SerializeField] private Renderer _drawableRenderer;
        [SerializeField] private UIConfig _uiConfig;
        
        private Button _redButton;
        private Button _greenButton;
        private Button _blueButton;
        private Button _clearButton;
        private Slider _brushSizeSlider;
        
        private InputManager _inputManager;
        private UIManager _uiManager;
        private TextureManager _textureManager;
        private Updater _updater;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
           CreateUpdater();
           CreateInputManager();
           
           GetButtons();
           CreateUIManager(_redButton, _greenButton, _blueButton, _brushSizeSlider, _clearButton);
           
           CreateTextureManager(_drawableRenderer, _uiManager);
           
           CreateBrush(_inputManager);
           
           _updater.RegisterUpdatable(_inputManager);
        }
        
        private void CreateUpdater()
        {
            GameObject created = new GameObject("Updater");
            Updater updater = created.AddComponent<Updater>();
            updater.Initialize();
            
            _updater = updater;
        }

        private void CreateInputManager()
        {
            _inputManager = new InputManager();
        }

        private void CreateTextureManager(Renderer drawableRenderer, UIManager uiManager)
        {
            _textureManager = new TextureManager(drawableRenderer, uiManager);
        }

        private void CreateBrush(InputManager inputManager)
        {
            _brush.Initialize(inputManager, _uiManager, _drawableRenderer);
        }

        private void CreateUIManager(Button redButton, Button greenButton, Button blueButton, Slider brushSizeSlider, Button clearButton)
        {
            _uiManager = new UIManager(redButton, greenButton, blueButton, brushSizeSlider, clearButton);
        }

        private void GetButtons()
        {
            _redButton = GameObject.FindWithTag(_uiConfig.RedButtonTag).GetComponent<Button>();
            _greenButton = GameObject.FindWithTag(_uiConfig.GreenButtonTag).GetComponent<Button>();
            _blueButton = GameObject.FindWithTag(_uiConfig.BlueButtonTag).GetComponent<Button>();
            _clearButton = GameObject.FindWithTag(_uiConfig.ClearButtonTag).GetComponent<Button>();
            _brushSizeSlider = GameObject.FindWithTag(_uiConfig.SliderBrushSizeTag).GetComponent<Slider>();
        }
    }
}
