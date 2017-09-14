using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense {
    public class Tower : MonoBehaviour {

        public Cannon cannon;
        public float attackRate = .25f;
        public float attackRadius = 5f;

        private float attackTimer = 0f;
        private List<Enemy> enemies = new List<Enemy>();

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

            attackTimer = attackTimer + Time.deltaTime;

            if (attackTimer >= attackRate) {

                Attack();
                attackTimer = 0;
            }
        }

        void OnTriggerEnter(Collider other) {

            Enemy e = other.GetComponent<Enemy>();

            if (e != null) {

                enemies.Add(e);
            }
        }

        void OnTriggerExit(Collider other) {

            Enemy e = other.GetComponent<Enemy>();

            if (e != null) {

                enemies.Remove(e);
            }
        }

        Enemy GetClosestEnemy() {

            enemies = RemoveAllNulls(enemies);

            Enemy closest = null;

            float minDistance = float.MaxValue;

            foreach (Enemy enemy in enemies) {

                float distance = Vector3.Distance(transform.position, enemy.transform.position);

                if (distance < minDistance) {

                    minDistance = distance;
                    closest = enemy;
                }
            }

            return closest;
        }

        void Attack() {

            Enemy closest = GetClosestEnemy();

            if (closest != null) {

                cannon.Fire(closest);
            }
        }

        List<Enemy> RemoveAllNulls(List<Enemy> listWithNulls) {

            List<Enemy> listWithoutNulls = new List<Enemy>();

            foreach (Enemy enemy in listWithNulls) {

                if (enemy != null) {

                    listWithoutNulls.Add(enemy);
                }
            }

            return listWithoutNulls;
        }
    }
}