using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VariousShooting
{
    public class SingleBulletGenerator : MonoBehaviour
    {
        public GameObject bulletPref;
        public string bulletLayer;
        
        private void Start()
        {
            // 弾丸を生成
            var bullet = Instantiate(bulletPref);
            
            // 生成した弾丸を自身と同じ位置に移動
            bullet.transform.position = transform.position;
            bullet.transform.forward = transform.forward;
            
            // 自身を破壊
            Destroy(gameObject);
        }
    }
}
