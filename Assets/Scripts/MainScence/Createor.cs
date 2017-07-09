using UnityEngine;

namespace Tetris
{
    namespace Main
    {
        public class Createor : MonoBehaviour
        {

            public Transform[] groups;

            private static Createor instance;
            public static Createor Instance
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

            public void SpawnNext()
            {
                // 只有在游戏还没结束时才会产生下一个
                if(GameManager.GameState == GameState.playing)
                {
                    Instantiate(groups[Random.Range(0, groups.Length)], transform.position, Quaternion.identity);
                }
            }
        }

    }
}


