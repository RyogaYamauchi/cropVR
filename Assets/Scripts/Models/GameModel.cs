using Scripts.Views;
using UnityEngine;

namespace Scripts.Models
{
    public class GameModel
    {
        public static GameModel Instance { get; } = new GameModel(); //シングルトン
        public GameView GameView;
        string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
        public int[] rankingValue = new int[5];

        public int Score;
        private WandState WandState = WandState.Fire;
        public void GetRanking()
        {
            //ランキング呼び出し
            for (int i = 0; i < ranking.Length; i++)
            {
                rankingValue[i]=PlayerPrefs.GetInt(ranking[i]);
            }
        }
        
        void SetRanking(int _value)
        {
            //書き込み用
            for (int i = 0; i < ranking.Length; i++)
            {
                //取得した値とRankingの値を比較して入れ替え
                if (_value>rankingValue[i])
                {
                    var change = rankingValue[i];
                    rankingValue[i] = _value;
                    _value = change;
                }
            }

            //入れ替えた値を保存
            for (int i = 0; i < ranking.Length; i++)
            {
                PlayerPrefs.SetInt(ranking[i],rankingValue[i]);
            }
        }

        public void AddScore(int score)
        {
            Score += score;
            int i = 0;
            int rank = 6;
            foreach (var value in rankingValue)
            {
                if (Score > value)
                {
                    rank -= 1;
                }
            }
            GameView.SetResultText(Score,rank);
        }

        public void ChangeWandState(WandState wandState)
        {
            Debug.Log($"WandStateが{wandState}になった");
            WandState = wandState;
        }

        public WandState GetWandState()
        {
            return WandState;
        }

        public void EndGame()
        {
            SetRanking(Score);
            Score = 0;
        }
    }

    public enum WandState
    {
        Fire,
        Water,
        plasma,
    }
}