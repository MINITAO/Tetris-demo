using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tetris
{
    namespace Main
    {
        public class MainSceneManager : MonoBehaviour
        {
            public int Width = 10;
            public int Height = 20;
            public int LeftBorder = 0;
            public int RightBorder = 9;
            public int SorceInOneRow = 100;
            public string TitleSceneName = "Title";

            private static MainSceneManager instance;
            public static MainSceneManager Instance
            {
                get
                {
                    return instance;
                }
            }

            private void Awake()
            {
                // 适用于MonoBehavior的单例模式
                instance = this;
            }

            private void Start()
            {
                UIController.Instance.ShowGameOver(false);
                Createor.Instance.SpawnNext();
            }

            private void Update()
            {
                if(GameManager.GameState == GameState.playing)
                {
                    // UI计时
                    UIController.Instance.Timing();
                }
            }

            /// <summary>
            /// 加分
            /// </summary>
            public void AddSorce()
            {
                UIController.Instance.AddSore(SorceInOneRow);
            }

            /// <summary>
            /// 游戏结束
            /// </summary>
            public void GameOver()
            {
                GameManager.Over();
                UIController.Instance.ShowGameOver(true);
            }

            /// <summary>
            /// 重开游戏
            /// </summary>
            public void Restart()
            {
                GameManager.Start();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            /// <summary>
            /// 回到标题
            /// </summary>
            public void RollBackToTitle()
            {
                SceneManager.LoadScene(TitleSceneName);
            }

        }


    }
}


