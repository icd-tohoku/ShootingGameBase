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

        public void Initialize(int hp, int defeatPoint)
        {
            _hp = hp;
            _defeatPoint = defeatPoint;
        }
    
        public void Damaged(int damage)
        {
            _hp -= damage;

            if (_hp <= 0)
            {
                GameData.AddScore(_defeatPoint);
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            transform.Translate(-0.1f, 0, 0);
        }
    }
}
