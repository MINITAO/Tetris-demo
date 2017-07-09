using UnityEngine;

namespace Tetris
{
    namespace Title
    {
        public class StartButton : MonoBehaviour
        {

            /// <summary>
            /// 开始游戏按钮
            /// </summary>
            public void StatGame()
            {
                TitleSceneManager.Instance.StartGame();
            }

        }


    }   // End title namspace
}   // End tetris namespace


