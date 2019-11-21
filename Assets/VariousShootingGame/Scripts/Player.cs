using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VariousShooting
{
    public class Player : MonoBehaviour
    {
        public GameObject[] bulletGenerators;
        public int[] levelUpThresholds;
        public Transform muzzle;

        public Text hpText = null;
        public Text mpText = null;
        public Text epText = null;
        public Text levelText = null;

        private const float MoveSpeed = 0.1f;
        private const int MaxHitPoint = 100;
        private const int MaxMagicPoint = 100;
        
        private static int _hitPoint = MaxHitPoint;
        private static int _magicPoint = 0;
        private static int _experiencePoint = 0;
        private static int _level = 1;

        private static int[] _levelUpThresholds;

        // 連射関係
        public float continuousShootingInterval = 0.3f;
        private float _currentPressingTime = 0;

        // MP関係
        private float mpTimer = 0;
        private int MP上昇インターバル = 1;
        private int MP上昇量 = 1;

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
                Fire(_level - 1);
            }
            
            if (Input.GetKey(KeyCode.Space))
            {
                if (_currentPressingTime > continuousShootingInterval)
                {
                    // スペースボタンを一定時間以上押し続けた時
                    Fire(_level - 1);
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
            mpTimer += Time.deltaTime;
            if (mpTimer > MP上昇インターバル)
            {
                // MPを加算
                _magicPoint += MP上昇量;
                
                // MP最大値を超えないように
                if (_magicPoint >= MaxMagicPoint)
                {
                    _magicPoint = MaxHitPoint;
                }
                
                // タイマーをリセット
                mpTimer = 0;
            }
        }

        /// <summary>
        /// 弾丸をmuzzleの位置に生成する
        /// </summary>
        private void Fire(int index)
        {
            var bullet = Instantiate(bulletGenerators[index]);
            bullet.transform.position = muzzle.position;
        }

        /// <summary>
        /// 敵の弾が当たってしまった時に呼ばれるメソッド
        /// </summary>
        /// <param name="damage"></param>
        public void Damaged(int damage)
        {
            _hitPoint -= damage;

            if (_hitPoint <= 0)
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
            _experiencePoint += point;

            // レベルMAXに到達していない かつ 経験値の総量が次のレベルに上がるための閾値を超えているなら
            if (_level-1 < _levelUpThresholds.Length && _experiencePoint >= _levelUpThresholds[_level - 1])
            {
                // レベルアップする
                _experiencePoint -= _levelUpThresholds[_level - 1];
                _level += 1;
            }
        }
#endif
    }
}
