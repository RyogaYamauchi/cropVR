using Scripts.Models;
using TMPro;
using UnityEngine;

namespace Scripts.Views
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private PointView _pointView;

        public void UpdateScore(int score)
        {
            _pointView.SetText(score.ToString());
        }
        
    }
}