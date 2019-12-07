using Scripts.Models;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameView : MonoBehaviour
    {
        private GameModel _gameModel = GameModel.Instance;

        private void Update()
        {
            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                Debug.Log("Aボタンを押した");
            }

            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                Debug.Log("Bボタンを押した");
            }

            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                Debug.Log("右人差し指トリガーを押した");
            }
        }
    }
}