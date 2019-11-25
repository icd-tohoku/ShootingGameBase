using System;
using System.Data;
using System.Timers;
using UnityEngine;

namespace VariousShooting
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyPrefabs = null;
        [SerializeField] private float enemyPopInterval = 1;

        [SerializeField] private Transform enemyPopAnchor = null;

        private System.Random _random;
        private float _currentTime = 0;

        private void Awake()
        {
            _random = new System.Random(DateTime.Now.Millisecond);
        }

        private void Update()
        {
            // ゲームプレイ中でない / Enemyのprefabに何も登録されていないなら何もしない
            if (!GameData.isPlayable || enemyPrefabs.Length == 0) return;
            
            // 一定時間経過したなら
            if (_currentTime >= enemyPopInterval)
            {
                // どの敵を生成するか選択する
                var index = DecideEnemyIndex();
                PopEnemy(index);

                _currentTime = 0;
            }
            else
            {
                _currentTime += Time.deltaTime;
            }
        }

        private int DecideEnemyIndex()
        {
            // ランダムな敵を選択
            return _random.Next(0, enemyPrefabs.Length);

            // レベルに応じた敵を選択
//            return GameData.level - 1;
        }

        private void PopEnemy(int index)
        {
            var enemyObj = Instantiate(enemyPrefabs[index]);
            enemyObj.transform.position = new Vector3(enemyPopAnchor.position.x, 
                (float)(_random.NextDouble() - 0.5f) * 2 * enemyPopAnchor.position.y, 0);
            enemyObj.transform.forward = Vector3.left;
        }
    }
}
