using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VariousShooting
{
    public class Player : MonoBehaviour
    {
        // 必須項目
        public GameObject[] bulletGenerators;
        public Transform muzzle;
        private const float MoveSpeed = 0.1f;

        // 連射関係
        public float continuousShootingInterval = 0.3f;
        private float _currentPressingTime = 0;

        // HP関係
        public Text hpText = null;

        // MP関係
        public Text mpText = null;
        private float _mpTimer = 0;
        private int _mpIncrementInterval = 1;
        private int _mpIncrementAmount = 1;

        // レベル関係
        public Text epText = null;
        public Text levelText = null;
        public int[] levelUpThresholds;
        private static int[] _levelUpThresholds;

        private void Awake()
        {
            _levelUpThresholds = levelUpThresholds;
        }

        private void Update()
        {
            // ================================================================================
            // ゲームプレイ可能でないなら何もしない
            // ================================================================================
            if (!GameData.isPlayable) return;
            
            // ================================================================================
            // WASDキー / 矢印キーで自身を移動
            // ================================================================================
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, MoveSpeed, 0);
            }
            
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, -MoveSpeed, 0);
            }
            
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-MoveSpeed, 0, 0);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(MoveSpeed, 0, 0);
            }
            
#if ENABLE_LEVEL
            // ================================================================================
            // レベルに応じた弾丸を発射
            // スペースボタンを押したとき / 押し続けている時に弾丸を発射
            // ================================================================================
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire(GameData.level - 1);
            }
            
            if (Input.GetKey(KeyCode.Space))
            {
                if (_currentPressingTime > continuousShootingInterval)
                {
                    // スペースボタンを一定時間以上押し続けた時
                    Fire(GameData.level - 1);
                    _currentPressingTime = 0;
                }
                else
                {
                    // スペースボタンを押している時間が一定時間以下の時
                    _currentPressingTime += Time.deltaTime;
                }
            }
            else
            {
                // スペースボタンを押していないとき、
                _currentPressingTime = 0;
            }
#endif
            
#if BUTTON_MAPPED_BULLET
            // ================================================================================
            // ユーザのボタン入力に応じた弾丸を発射（例）
            // 長押しのサンプルは上のサンプルを参考にしてください
            // ================================================================================
            if (Input.GetKeyDown(KeyCode.U)) Fire(0);
            if (Input.GetKeyDown(KeyCode.I)) Fire(1);
            if (Input.GetKeyDown(KeyCode.O)) Fire(2);
            if (Input.GetKeyDown(KeyCode.P)) Fire(3);
#endif
            
            // ================================================================================
            // 時間経過とともにMPが溜まっていく
            // ================================================================================
            _mpTimer += Time.deltaTime;
            if (_mpTimer > _mpIncrementInterval)
            {
                // MPを加算
                GameData.magicPoint += _mpIncrementAmount;
                
                // MP最大値を超えないように
                if (GameData.magicPoint >= GameData.MaxMagicPoint)
                {
                    GameData.magicPoint = GameData.MaxMagicPoint;
                }
                
                // タイマーをリセット
                _mpTimer = 0;
            }
        }

        /// <summary>
        /// 弾丸をmuzzleの位置に生成する
        /// </summary>
        private void Fire(int index)
        {
            var bullet = Instantiate(bulletGenerators[index]);
            bullet.transform.position = muzzle.position;
            bullet.transform.forward = Vector3.right;
            ;
        }

        /// <summary>
        /// 敵の弾が当たってしまった時に呼ばれるメソッド
        /// </summary>
        /// <param name="damage"></param>
        public void Damaged(int damage)
        {
            GameData.hitPoint -= damage;

            if (GameData.hitPoint <= 0)
            {
                Debug.Log("Game Over");
                GameData.isPlayable = false;
            }
        }

#if ENABLE_LEVEL
        /// <summary>
        /// 経験値を手に入れる
        /// </summary>
        /// <param name="point"></param>
        public static void AddExperience(int point)
        {
            if (GameData.level == _levelUpThresholds.Length)
            {
                Debug.Log("Level Maxなので経験値は破棄します。");
                GameData.experiencePoint = 0;
                return;
            }
            
            GameData.experiencePoint += point;
            Debug.Log($"現在の経験値：{GameData.experiencePoint}");

            // レベルMAXに到達していない かつ 経験値の総量が次のレベルに上がるための閾値を超えているなら
            if (GameData.level-1 < _levelUpThresholds.Length && GameData.experiencePoint >= _levelUpThresholds[GameData.level - 1])
            {
                // レベルアップする
                GameData.experiencePoint -= _levelUpThresholds[GameData.level - 1];
                GameData.level += 1;
                Debug.Log($"Lv.{GameData.level-1} -> Lv.{GameData.level}");
            }
        }
#endif
    }
}
