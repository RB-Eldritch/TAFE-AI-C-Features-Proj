using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards {
    public class Ball : MonoBehaviour {

        public float stopSpeed = 0.2f;

        private Rigidbody rigid;

        // Use this for initialization
        void Start() {

            rigid = GetComponent<Rigidbody>();
        }

        void FixedUpdate() {

            Vector3 vel = rigid.velocity;

            //check if velocity is increasing
            if (vel.y > 0) {

                //cap velocity
                vel.y = 0;
            }

            //if the velocity's speed is less than stop speed
            if (vel.magnitude < stopSpeed) {

                //cancel out velocity
                vel = Vector3.zero;
            }

            rigid.velocity = vel;
        }

        public void Hit(Vector3 dir, float impactForce) {

            rigid.AddForce(dir * impactForce, ForceMode.Impulse);
        }
    }
}