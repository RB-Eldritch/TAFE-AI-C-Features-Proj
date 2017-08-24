using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrays {
    public class Weapon : MonoBehaviour
    {

        public int damage = 10;
        public int maxBullets = 30;

        public float bulletSpeed = 20f;
        public float fireInterval = 0.2f;

        public GameObject bulletPrefab;

        public Transform spawnPoint;


        private Bullet[] spawnedBullets;

        private int currentBullets = 0;

        private bool isFired = false;

        private Transform target;

        // Use this for initialization
        void Start() {

            spawnedBullets = new Bullet[maxBullets];
        }

        // Update is called once per frame
        void Update() {

            //If !isFired && currentBullets < maxBullets
            if (!isFired && currentBullets < maxBullets) {

                //StartCorourine
                StartCoroutine(Fire());
            }
        }

        IEnumerator Fire() {

            //run whatever is here first
            isFired = true;

            // spawn the bullet
            SpawnBullet();

            yield return new WaitForSeconds(fireInterval); //wait a few seconds
            // run whatever is here last

            isFired = false;
        }

        //fire a bullet
        void SpawnBullet() {

            // 1: Instantiate a bullet clone
            GameObject bulletClone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

            // 2: make a direction that goes to target
            Vector2 direction = target.position - transform.position;
            direction.Normalize();

            // 2.5: rotate the barrel
            //--transform.rotation = Quaternion.LookRotation(direction);
            Vector3 eulerAngles = transform.eulerAngles;

            float angle = Vector3.Angle(Vector3.right, direction);

            eulerAngles.z = angle;

            transform.eulerAngles = eulerAngles;

            // 3: grab bullet script from clone
            Bullet bullet = bulletClone.GetComponent<Bullet>();

            // 4: send bullet to target
            bullet.direction = direction;

            // 5: store bullet in array
            spawnedBullets[currentBullets] = bullet;

            // 6: increment currentBullets
            currentBullets++;
        }

        public void SetTarget(Transform target) {

            this.target = target;
        }
    }
}
