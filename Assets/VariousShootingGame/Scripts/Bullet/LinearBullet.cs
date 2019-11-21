using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VariousShooting
{
    [RequireComponent(typeof(Rigidbody))]
    public class LinearBullet : MonoBehaviour
    {
        public float speed;
        public float lifeTime;
        
        private float _timer = 0;
        
        private void Start()
        {
            // このスクリプトがアタッチされているオブジェクトに付いているRigidbodyコンポーネントを取得する
            var rb = gameObject.GetComponent<Rigidbody>();
            
            // 重力を使わないよう設定
            rb.useGravity = false;
            
            // 自身に前方向への力を加える
            rb.AddForce(transform.right * speed, ForceMode.Impulse);
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