using System;
using UnityEngine;
using UnityEngine.UI;

namespace Draw.Scripts.UI
{
    public class UIManager
    {
        public event Action<Color> OnColorChanged;
        public event Action<int> OnBrushSizeChanged;
        public event Action OnClear; 
        public event Action OnSave; 
        public event Action OnLoad; 

        public UIManager(Button redButton, Button greenButton, Button blueButton, Slider brushSizeSlider, Button clearButton, Button saveButton, Button loadButton)
        {
            redButton.onClick.AddListener(() => OnColorChanged?.Invoke(Color.red));
            greenButton.onClick.AddListener(() => OnColorChanged?.Invoke(Color.green));
            blueButton.onClick.AddListener(() => OnColorChanged?.Invoke(Color.blue));
            clearButton.onClick.AddListener(() => OnClear?.Invoke());
            saveButton.onClick.AddListener(() => OnSave?.Invoke());
            loadButton.onClick.AddListener(() => OnLoad?.Invoke());
            
            brushSizeSlider.onValueChanged.AddListener(value => OnBrushSizeChanged?.Invoke((int)value));
        }
    }
}
