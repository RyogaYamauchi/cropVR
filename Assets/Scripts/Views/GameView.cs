using System.Collections;
using Scripts.Models;
using UnityEngine;

namespace Scripts.Views
{
    public class GameView : MonoBehaviour
    {
        private GameModel _gameModel = GameModel.Instance;
        [SerializeField] private EffectPortView _effectPortView = default;


        private void Update()
        {
            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                OnPushA();
            }

            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                OnPushB();
            }

            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                OnPushForward();
            }
        }

        public void OnPushA()
        {
            switch (_gameModel.GetWandState())
            {
                case WandState.plasma:
                    _gameModel.ChangeWandState(WandState.Fire);
                    break;
                case WandState.Fire:
                    _gameModel.ChangeWandState(WandState.Water);
                    break;
                case WandState.Water:
                    _gameModel.ChangeWandState(WandState.plasma);
                    break;
            }
        }

        public void OnPushB()
        {
            switch (_gameModel.GetWandState())
            {
                case WandState.plasma:
                    _gameModel.ChangeWandState(WandState.Water);
                    break;
                case WandState.Fire:
                    _gameModel.ChangeWandState(WandState.plasma);
                    break;
                case WandState.Water:
                    _gameModel.ChangeWandState(WandState.Fire);
                    break;
            }
        }

        public void OnPushForward()
        {
            Debug.Log($"ハッシャ！！{_gameModel.GetWandState()}");
            switch (_gameModel.GetWandState())
            {
                case WandState.plasma:
                    StartCoroutine(PlayPlasmaAnimation());
                    break;
                case WandState.Fire:
                    StartCoroutine(PlayFireAnimation());
                    break;
                case WandState.Water:
                    StartCoroutine(PlayWaterAnimation());
                    break;
            }
        }

        public IEnumerator PlayPlasmaAnimation()
        {
            StartCoroutine(_effectPortView.PlayPlasmaAnimation());
            yield return null;
        }

        public IEnumerator PlayFireAnimation()
        {
            StartCoroutine(_effectPortView.PlayFireAnimation());

            yield return null;
        }

        public IEnumerator PlayWaterAnimation()
        {
            StartCoroutine(_effectPortView.PlayWaterAnimation());
            yield return null;
        }
    }
}