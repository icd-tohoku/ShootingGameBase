using System.Collections;
using Systems;
using UnityEngine;

namespace Fields
{
    [RequireComponent(typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
    
        /// <summary>
        /// 自身のアタッチされているGameObjectがActiveになった時
        /// </summary>
        private void OnEnable()
        {
            // コルーチンを開始
            StartCoroutine(DestroySelfCoroutine());
        }

        /// <summary>
        /// 一定時間経過後に自身を破壊するコルーチン
        /// </summary>
        /// <returns></returns>
        private IEnumerator DestroySelfCoroutine()
        {
            // 一定時間待つ
            yield return new WaitForSeconds(2f);
        
            // 自身を破壊
            Destroy(gameObject);
        }

        /// <summary>
        /// 何かと衝突した時に呼ばれるコールバック
        /// </summary>
        /// <param name="other"></param>
        private void OnCollisionEnter(Collision other)
        {
            // 敵に当たった時
            if (other.transform.TryGetComponent<Enemy>(out var enemy))
            {
                // 敵にダメージを与える処理
                enemy.Damaged(damage);
            
                // 自身を破壊
                Destroy(gameObject);
            }
        }
    }
}
