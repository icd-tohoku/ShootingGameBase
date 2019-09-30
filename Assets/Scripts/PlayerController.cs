using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    /// <summary>
    /// 毎フレーム呼ばれる処理
    /// </summary>
    private void Update()
    {
        // 上矢印が押されたら
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // 上に移動
            transform.Translate(0.1f * moveSpeed, 0, 0);
        }
        
        // 下矢印が押されたら
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // 下に移動
            transform.Translate(-0.1f * moveSpeed, 0, 0);
        }

        // 右矢印が押されたら
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 右に移動
            transform.Translate(0, -0.1f * moveSpeed, 0);
        }
        
        // 左矢印が押されたら
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 左に移動
            transform.Translate(0, 0.1f * moveSpeed, 0);
        }
    }
}
