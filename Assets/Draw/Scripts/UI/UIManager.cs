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

        public UIManager(Button redButton, Button greenButton, Button blueButton, Slider brushSizeSlider, Button clearButton)
        {
            redButton.onClick.AddListener(() => OnColorChanged?.Invoke(Color.red));
            greenButton.onClick.AddListener(() => OnColorChanged?.Invoke(Color.green));
            blueButton.onClick.AddListener(() => OnColorChanged?.Invoke(Color.blue));
            clearButton.onClick.AddListener(() => OnClear?.Invoke());
            
            brushSizeSlider.onValueChanged.AddListener(value => OnBrushSizeChanged?.Invoke((int)value));
        }
    }
}
