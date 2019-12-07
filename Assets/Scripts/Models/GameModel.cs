using UnityEngine;

namespace Scripts.Models
{
    public class GameModel
    {
        public static GameModel Instance { get; } = new GameModel(); //シングルトン

        public int Score;
        private  WandState WandState = WandState.Fire;

        public void ChangeWandState(WandState wandState)
        {
            Debug.Log($"WandStateが{wandState}になった");
            WandState = wandState;
        }

        public WandState GetWandState()
        {
            return WandState;
        }


    }

    public enum WandState
    {
        Fire,
        Water,
        plasma,
    }
}