using TMPro;
using UnityEngine;

namespace Scripts.Views
{
    public class PointView : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshProUgui = default;

        private void Start()
        {
            _textMeshProUgui = GetComponent<TextMeshProUGUI>();
        }
        public void SetText(string text)
        {
            _textMeshProUgui.text = text;
        }
    }
}