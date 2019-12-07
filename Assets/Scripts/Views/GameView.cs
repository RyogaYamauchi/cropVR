using System.Collections;
using Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Views
{
    public class GameView : MonoBehaviour
    {
        private GameModel _gameModel = GameModel.Instance;
        public IEffectPortView _effectPortView = default;
        public GameObject Canvas;
        public GameObject Player;
        public Text ResultText;

        public void SetResultText(int score, int rank)
        {
            string s = score < 500 ? "もっとがんばろう" : score < 750 ? "高得点だ！高いランクをめざそう!" : "すごすぎる...最高ランクだおめでとう!";
            ResultText.text = $"Score : {score}\nRank : {rank} \n{s}";
        }

        private void Awake()
        {
            _gameModel.GameView = this;
        }

        public void OnSE()
        {
            Player.GetComponent<AudioSource>().Play(0);
        }


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
                /*case WandState.plasma:
                    StartCoroutine(PlayPlasmaAnimation());
                    break;*/
                case WandState.Fire:
                    StartCoroutine(PlayFireAnimation());
                    break;
                /*case WandState.Water:
                    StartCoroutine(PlayWaterAnimation());
                    break;*/
            }
        }

        /*public IEnumerator PlayPlasmaAnimation()
        {
            StartCoroutine(_effectPortView.PlayPlasmaAnimation());
            yield return null;
        }*/

        public IEnumerator PlayFireAnimation()
        {
            StartCoroutine(_effectPortView.PlayFireAnimation());

            yield return null;
        }

        /*public IEnumerator PlayWaterAnimation()
        {
            StartCoroutine(_effectPortView.PlayWaterAnimation());
            yield return null;
        }*/
    }
}