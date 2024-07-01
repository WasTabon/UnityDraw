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
        [SerializeField] private GameObject brush;
        [SerializeField] private Renderer _drawableRenderer;
        [SerializeField] private UIConfig _uiConfig;
        [SerializeField] private LayerMask _drawableLayerMask;
        
        private Button _redButton;
        private Button _greenButton;
        private Button _blueButton;
        private Button _clearButton;
        private Button _saveButton;
        private Button _loadButton;
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
           CreateUIManager(_redButton, _greenButton, _blueButton, _brushSizeSlider, _clearButton, _saveButton, _loadButton);
           
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
            _brush = new Brush(inputManager, _uiManager, _drawableRenderer, _drawableLayerMask, brush.transform);
            
        }

        private void CreateUIManager(Button redButton, Button greenButton, Button blueButton, Slider brushSizeSlider, Button clearButton, Button saveButton, Button loadbButton)
        {
            _uiManager = new UIManager(redButton, greenButton, blueButton, brushSizeSlider, clearButton, saveButton, loadbButton);
        }

        private void GetButtons()
        {
            _redButton = GameObject.FindWithTag(_uiConfig.RedButtonTag).GetComponent<Button>();
            _greenButton = GameObject.FindWithTag(_uiConfig.GreenButtonTag).GetComponent<Button>();
            _blueButton = GameObject.FindWithTag(_uiConfig.BlueButtonTag).GetComponent<Button>();
            _clearButton = GameObject.FindWithTag(_uiConfig.ClearButtonTag).GetComponent<Button>();
            _saveButton = GameObject.FindWithTag(_uiConfig.SaveButtonTag).GetComponent<Button>();
            _loadButton = GameObject.FindWithTag(_uiConfig.LoadButtonTag).GetComponent<Button>();
            _brushSizeSlider = GameObject.FindWithTag(_uiConfig.SliderBrushSizeTag).GetComponent<Slider>();
        }
    }
}
