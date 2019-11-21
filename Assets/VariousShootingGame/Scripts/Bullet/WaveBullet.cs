using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VariousShooting
{
    [RequireComponent(typeof(Rigidbody))]
    public class WaveBullet : MonoBehaviour
    {
        public float speed;
        public float lifeTime;   // 自身を破壊するまでの時間

        public float waveHeight; // 振幅
        public float freq;
        
        private float _timer = 0;
        private Rigidbody _rigidbody;
        
        private void Start()
        {
            // このスクリプトがアタッチされているオブジェクトに付いているRigidbodyコンポーネントを取得する
            _rigidbody = gameObject.GetComponent<Rigidbody>();
            
            // 重力を使わないよう設定
            _rigidbody.useGravity = false;
            
            // 自身に前方向への力を加える
            _rigidbody.AddForce(transform.right * speed, ForceMode.Impulse);
        }

        private void FixedUpdate()
        {
            // Sin巻子を使って自身を上下方向に動かす
            _rigidbody.position += waveHeight * Mathf.Sin(_timer * freq) * transform.up;
        }

        private void Update()
        {
            // 一定時間以上経ったら自身を破壊する
            _timer += Time.deltaTime;
            if (_timer > lifeTime)
            {
                Destroy(gameObject);
            }
        }
    }
}