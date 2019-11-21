using UnityEngine;

namespace VariousShooting
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] private float scrollSpeed = 1f;
        private SpriteRenderer _renderer;

        /// <summary>
        /// ゲーム開始時に呼ばれる処理
        /// </summary>
        private void Awake()
        {
            _renderer = gameObject.GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// 毎フレーム呼ばれる処理
        /// </summary>
        private void Update()
        {
            // ゲームプレイ中でないなら何もしない
            if (!GameData.isPlaying) return;
            
            // 背景画像を左側に動かす
            transform.Translate(-0.1f * scrollSpeed, 0, 0);
        
            // 背景画像が一定以上後方に移動したら
            if (transform.position.x < -_renderer.sprite.bounds.size.x * transform.localScale.x)
            {
                // 前方にワープさせる
                transform.position = new Vector3 (_renderer.sprite.bounds.size.x * transform.localScale.x, 0, 0);
            }
        }

        public void SetImage(Sprite image)
        {
            _renderer.sprite = image;
        }
    }
}
