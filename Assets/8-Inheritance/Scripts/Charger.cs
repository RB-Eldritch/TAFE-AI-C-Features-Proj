using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance {
    public class Charger : Enemy {

        [Header("Charger")]
        public float impactForce = 10f;
        public float knockback = 5f;

        public Rigidbody rigid;
        
        void OnCollisionEnter(Collision other) {

            //if collision hits player
                //add impactForce to player
        }

        public override void Attack() {

            //add force to self
        }
    }
}