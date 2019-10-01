using Systems;
using UnityEngine;

namespace Fields
{
    public class Enemy : MonoBehaviour
    {
        // Enemyの体力
        [SerializeField] private int hitPoint = 1;

        // 撃破時にユーザがもらえるポイント
        [SerializeField] private int defeatPoint = 100;

    
        public void Damaged(int damage)
        {
            hitPoint -= damage;

            if (hitPoint <= 0)
            {
                GameData.AddScore(defeatPoint);
                Destroy(gameObject);
            }
        }
    }
}
