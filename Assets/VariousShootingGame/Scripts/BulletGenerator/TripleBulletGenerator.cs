using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VariousShooting
{
    public class TripleBulletGenerator : MonoBehaviour
    {
        public GameObject bulletPref;

        public Transform upperGenerationPoint;
        public Transform downGenerationPoint;
        
        private void Start()
        {
            // 弾丸を生成
            var upperBullet = Instantiate(bulletPref);
            var middleBullet = Instantiate(bulletPref);
            var downBullet = Instantiate(bulletPref);

            // 生成した弾丸を指定の位置に移動
            upperBullet.transform.position = upperGenerationPoint.position;
            middleBullet.transform.position = transform.position;
            downBullet.transform.position = downGenerationPoint.position;

            // 生成した弾丸の向きも指定
            upperBullet.transform.right = upperGenerationPoint.right;
            middleBullet.transform.right = transform.right;
            downBullet.transform.right = downGenerationPoint.right;
            
            // 自身を破壊
            Destroy(gameObject);
        }
    }
}
