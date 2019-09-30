using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    private Sprite _sprite;

    /// <summary>
    /// ゲーム開始時に呼ばれる処理
    /// </summary>
    private void Awake()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    /// <summary>
    /// 毎フレーム呼ばれる処理
    /// </summary>
    private void Update()
    {
        // 背景画像を左側に動かす
        transform.Translate(-0.1f * scrollSpeed, 0, 0);
        
        // 背景画像が一定以上後方に移動したら
        if (transform.position.x < -_sprite.bounds.size.x * transform.localScale.x)
        {
            // 前方にワープさせる
            transform.position = new Vector3 (_sprite.bounds.size.x * transform.localScale.x, 0, 0);
        }
    }
}
