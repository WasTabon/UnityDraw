using System;
using UnityEngine;
using UnityEngine.UI;

namespace Draw.Scripts.UI
{
    public class UIManager
    {
        public event Action<Color> OnColorChanged;

        public UIManager(Button redButton, Button greenButton, Button blueButton)
        {
            redButton.onClick.AddListener(() => OnColorChanged?.Invoke(Color.red));
            greenButton.onClick.AddListener(() => OnColorChanged?.Invoke(Color.green));
            blueButton.onClick.AddListener(() => OnColorChanged?.Invoke(Color.blue));
        }
    }
}
