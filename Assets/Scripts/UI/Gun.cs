using UnityEngine;

namespace UI
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private GameObject bullet = null;
        [SerializeField] private float bulletSpeed = 10f;
        [SerializeField] private float continuousShootingInterval = 0.3f;

        private float _currentPressingTime = 0;
    
        /// <summary>
        /// 毎フレーム呼ばれる処理
        /// </summary>
        private void Update()
        {
            // スペースボタンを押したとき
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        
            if (Input.GetKey(KeyCode.Space))
            {
                if (_currentPressingTime > continuousShootingInterval)
                {
                    // スペースボタンを一定時間以上押し続けた時
                    Fire();
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
        }

        /// <summary>
        /// 弾を発射する処理
        /// </summary>
        private void Fire()
        {
            var bulletInstance = Instantiate(bullet);
            bulletInstance.transform.position = transform.position;
        
            var rb = bulletInstance.GetComponent<Rigidbody>();
            rb.AddForce(-bulletSpeed * transform.up, ForceMode.Impulse);
        }
    }
}
