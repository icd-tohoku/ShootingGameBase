using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VariousShooting
{
    public class TripleBulletGenerator : MonoBehaviour
    {
        public GameObject bulletPref;
        public string bulletLayer;

        public Transform generationPoint1;
        public Transform generationPoint2;
        
        private void Start()
        {
            var layer = LayerMask.NameToLayer(bulletLayer);
            
            // 弾丸を生成
            var upperBullet = Instantiate(bulletPref);
            var middleBullet = Instantiate(bulletPref);
            var downBullet = Instantiate(bulletPref);

            // 生成した弾丸を指定の位置に移動
            upperBullet.transform.position = generationPoint1.position;
            middleBullet.transform.position = transform.position;
            downBullet.transform.position = generationPoint2.position;

            // 生成した弾丸の向きも指定
            upperBullet.transform.forward = generationPoint1.forward;
            middleBullet.transform.forward = transform.forward;
            downBullet.transform.forward = generationPoint2.forward;
            
            // 生成した弾丸のレイヤーを変更
            upperBullet.layer = layer;
            
            // 自身を破壊
            Destroy(gameObject);
        }

        private void Generate(Transform generationPoint, int layer)
        {
            var bullet = Instantiate(bulletPref);
            bullet.transform.position = generationPoint.position;
            bullet.transform.forward = generationPoint.forward;
            bullet.layer = layer;
        }
    }
}
