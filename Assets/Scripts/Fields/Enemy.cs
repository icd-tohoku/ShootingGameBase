using System;
using Systems;
using UnityEngine;

namespace Fields
{
    public class Enemy : MonoBehaviour
    {
        // Enemyの体力
        private int _hp = 1;

        // 撃破時にユーザがもらえるポイント
        private int _defeatPoint = 100;

        private void Awake()
        {
            // ゲームオーバー時に自身を破壊するよう設定
            EventManager.GameOverEvent += DestroySelf;
        }

        private void OnDestroy()
        {
            EventManager.GameOverEvent -= DestroySelf;
        }

        private void DestroySelf()
        {
            Destroy(gameObject);
        }

        /// <summary>
        /// 敵（自分）のパラメータの初期化処理
        /// </summary>
        /// <param name="hp"></param>
        /// <param name="defeatPoint"></param>
        public void Initialize(int hp, int defeatPoint)
        {
            _hp = hp;
            _defeatPoint = defeatPoint;
        }
    
        /// <summary>
        /// プレーヤーの弾が当たった時の処理
        /// </summary>
        /// <param name="damage"></param>
        public void Damaged(int damage)
        {
            _hp -= damage;

            if (_hp <= 0)
            {
                // HPがなくなったらスコアを加算し自身を破壊
                GameData.Instance.AddScore(_defeatPoint);
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// 毎フレーム呼ばれる処理
        /// </summary>
        private void Update()
        {
            // 自身を左側に移動
            transform.Translate(-0.1f, 0, 0);

            if (transform.position.x <= -9.5)
            {
                // 一定以上左に進んだら（画面外に行ったら）プレーヤーのライフを減算し自信を破壊
                DestroySelf();
                GameData.Instance.ChangeLife(-1);
            }
        }
    }
}
