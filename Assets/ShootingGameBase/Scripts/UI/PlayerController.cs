using System;
using UnityEngine;

namespace Shooting.UI
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;

        /// <summary>
        /// 毎フレーム呼ばれる処理
        /// </summary>
        private void Update()
        {
            PositionUpdate();
        }

        private void PositionUpdate()
        {
            // 上矢印が押されたら
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                // 上に移動
                transform.Translate(0.1f * moveSpeed, 0, 0);
            }
        
            // 下矢印が押されたら
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                // 下に移動
                transform.Translate(-0.1f * moveSpeed, 0, 0);
            }

            // 右矢印が押されたら
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                // 右に移動
                transform.Translate(0, -0.1f * moveSpeed, 0);
            }
        
            // 左矢印が押されたら
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                // 左に移動
                transform.Translate(0, 0.1f * moveSpeed, 0);
            }
        }
    }
}
