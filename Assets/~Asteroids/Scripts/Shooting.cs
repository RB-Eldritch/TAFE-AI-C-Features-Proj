using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid {

    public class Shooting : MonoBehaviour {

        public GameObject bulletPrefab;
        public float bulletSpeed = 20f;
        public float shootRate = .2f;

        private float shootTimer = 0f;

        // Update is called once per frame
        void Update() {

            shootTimer += Time.deltaTime;

            if (shootTimer > shootRate) {

                if (Input.GetKey(KeyCode.Space)) {

                    Shoot();
                    shootTimer = 0;
                }
            }
        }

        void Shoot() {

            GameObject bulletClone = Instantiate(bulletPrefab);
            Rigidbody2D cloneRigid = bulletClone.GetComponent<Rigidbody2D>();
            cloneRigid.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}