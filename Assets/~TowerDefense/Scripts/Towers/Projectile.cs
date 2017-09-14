using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense {
    public class Projectile : MonoBehaviour {

        public float damage = 50f;
        public float speed = 50f;
        public Vector3 direction;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

            Vector3 velocity = direction.normalized * speed;
            transform.position += velocity * Time.deltaTime;
        }

        void OnTriggerEnter(Collider other) {

            Enemy e = other.GetComponent<Enemy>();

            if (e != null) {

                e.DealDamage(damage);
                Destroy(this.gameObject);
            }

            if (other.name == "Ground") {

                Destroy(this.gameObject);
            }
        }
    }
}