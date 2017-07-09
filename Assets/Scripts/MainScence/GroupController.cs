using UnityEngine;

namespace Tetris
{
    namespace Main
    {
        public class GroupController : MonoBehaviour
        {

            private float lastFallTime;
            private bool canMove = true;
            private float createTime;
            private InputController inputController;

            private void Start()
            {
#if UNITY_STANDALONE
                inputController = new StandalonController();
#elif UNITY_ANDROID
                inputController = new TouchController();
#endif
                createTime = Time.time;
                if (MakeEffectiveMove(Vector3.zero)) // 生成后立即更新网格数据, 0移动表示使用当时位置的数据
                {
                    canMove = true;
                }
                else
                {
                    MainSceneManager.Instance.GameOver();  // 若一生成就无法移动, 说明游戏结束
                    canMove = false;
                }
            }

            private void Update()
            {
                if (canMove)
                {
                    InputControl();
                    AutoFall();
                }
                else
                {
                    if (GameManager.GameState == GameState.playing)
                    {
                        GridController.Instance.UpdateGrid(transform);
                        GridController.Instance.ClearFullRow();
                        Createor.Instance.SpawnNext();
                    }
                    enabled = false;
                }
            }

            /// <summary>
            /// 做有效的移动
            /// </summary>
            /// <param name="move"></param>
            /// <returns></returns>
            private bool MakeEffectiveMove(Vector3 move)
            {
                Vector3 nowPos = transform.position;
                transform.position += move;
                if (GridController.Instance.IsValid(transform))
                {
                    GridController.Instance.UpdateGrid(transform);
                    return true;
                }
                else
                {
                    transform.position = nowPos;
                    return false;
                }
            }

            /// <summary>
            /// 做有效的旋转
            /// </summary>
            /// <param name="rotation"></param>
            /// <returns></returns>
            private bool MakeEffectiveRotate(Vector3 rotation)
            {
                transform.Rotate(rotation);
                if (GridController.Instance.IsValid(transform))
                {
                    GridController.Instance.UpdateGrid(transform);
                    return true;
                }
                else
                {
                    transform.Rotate(-rotation);
                    return false;
                }
            }

            /// <summary>
            /// 玩家控制方块的方向和变形
            /// </summary>
            private void InputControl()
            {
                if (inputController.MoveLeft())
                {
                    MakeEffectiveMove(new Vector3(-1, 0, 0));
                }
                if (inputController.MoveRight())
                {
                    MakeEffectiveMove(new Vector3(1, 0, 0));
                }
                if (inputController.FastMoveDown() && Time.time - createTime >= 1) // 生成1秒后才允许快速下落, 提高用户体验
                {
                    MakeEffectiveMove(new Vector3(0, -1, 0));
                }
                if (inputController.MakeChange())
                {
                    // TO不允许旋转
                    if (!gameObject.tag.Equals("TO"))
                    {
                        MakeEffectiveRotate(new Vector3(0, 0, -90));
                    }
                }
            }

            /// <summary>
            /// 控制方块的自由掉落
            /// </summary>
            private void AutoFall()
            {
                int time = (int)(Time.time - lastFallTime);
                if (time >= 1)
                {
                    if (MakeEffectiveMove(new Vector3(0, -1, 0)))
                    {
                        lastFallTime = Time.time;
                    }
                    else
                    {
                        canMove = false;
                    }
                }
            }

        }


    }

}

