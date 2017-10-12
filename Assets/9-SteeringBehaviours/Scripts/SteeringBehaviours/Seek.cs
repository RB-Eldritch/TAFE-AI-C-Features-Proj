using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI {

    public class Seek : SteeringBehaviour {

        public float stoppingDistance = 1f;

        public Transform target;

        public override Vector3 GetForce() {

            Vector3 force = Vector3.zero;

            if (target == null) {

                return force;
            }

            //Let desiredForce = target position - transform position
            Vector3 desiredForce = target.position - transform.position;

            //If desiredForce magnitude > stoppingDistance
            if (desiredForce.magnitude > stoppingDistance) {

                //desiredForce = desiredForce normalized x weighting
                desiredForce = desiredForce.normalized * weighting;

                //force = desiredForce - owner.velocity
                force = desiredForce - owner.velocity;

            }

            //return force
            return force;
        }
    }
}