using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tetris
{
    namespace Title
    {
        public class TitleSceneManager : MonoBehaviour
        {

            // 下一个场景的名称, 为了在inspector面板中显示并编辑, 只能使用公共字段, 而不能使用公共属性
            public string NextSceneName = "Main";

            private static TitleSceneManager instance;
            public static TitleSceneManager Instance
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

            /// <summary>
            /// 开始游戏
            /// </summary>
            public void StartGame()
            {
                GameManager.Start();
                SceneManager.LoadScene(NextSceneName);
            }
        }


    }   // End title namspace
}   // End tetris namespace

