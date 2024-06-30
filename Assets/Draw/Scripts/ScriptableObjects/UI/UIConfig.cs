using UnityEngine;

namespace Draw.Scripts.ScriptableObjects.UI
{
    [CreateAssetMenu(fileName = "UIConfig", menuName = "Configs / New UIConfig")]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private string _redButtonTag;
        [SerializeField] private string _greenButtonTag;
        [SerializeField] private string _blueButtonTag;
        [SerializeField] private string _sliderBrushSizeTag;
        [SerializeField] private string _clearButtonTag;

        public string RedButtonTag => _redButtonTag;
        public string GreenButtonTag => _greenButtonTag;
        public string BlueButtonTag => _blueButtonTag;
        public string SliderBrushSizeTag => _sliderBrushSizeTag;
        public string ClearButtonTag => _clearButtonTag;
    }
}
