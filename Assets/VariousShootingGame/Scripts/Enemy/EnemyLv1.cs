using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VariousShooting
{
    public class EnemyLv1 : MonoBehaviour
    {
        public GameObject bulletGenerator;
        public Transform muzzle;
        public float speed;
        public float fireInterval;

        private float _timer = 0;
        
        private void Start()
        {
            
        }

        private void Update()
        {
            transform.Translate(0, 0, speed);

            _timer += Time.deltaTime;
            if (_timer > fireInterval)
            {
                var gen = Instantiate(bulletGenerator);
                gen.transform.position = muzzle.position;
                gen.transform.forward = transform.forward;
                
                _timer = 0;
            }
        }
    }
}
