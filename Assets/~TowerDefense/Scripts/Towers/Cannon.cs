using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense {
    public class Cannon : MonoBehaviour {

        public Transform barrel;
        public GameObject projectilePrefab;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void Fire(Enemy targetEnemy) {

            Vector3 targetPos = targetEnemy.transform.position;
            Vector3 barrelPos = barrel.position;
            Quaternion barrelRot = barrel.rotation;
            Vector3 fireDirection = targetPos - barrelPos;

            transform.rotation = Quaternion.LookRotation(fireDirection);
            GameObject projectileClone = Instantiate(projectilePrefab, barrelPos, barrelRot);

            Projectile p = projectileClone.GetComponent<Projectile>();
            p.direction = fireDirection;
        }
    }
}