using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance {
    public class Charger : Enemy {

        [Header("Charger")]
        public float impactForce = 10f;
        public float knockback = 5f;

        public bool charging = false;

        protected override void Awake() {

            base.Awake();
        }

        void OnCollisionEnter(Collision other) {

            if (charging == true) {

                //if collision hits player 
                Health h = other.gameObject.GetComponent<Health>();
                if (h != null) {

                    h.TakeDamage(damage);
                }

                //add impactForce to player
                Rigidbody r = other.gameObject.GetComponent<Rigidbody>();
                if (r != null) {

                    r.AddForce(transform.forward * impactForce, ForceMode.Impulse);
                }

                charging = false;
            }
        }

        protected override void Attack() {

            charging = true;

            //add force to self
            rigid.AddForce(transform.forward * knockback, ForceMode.Impulse);
        }
    }
}