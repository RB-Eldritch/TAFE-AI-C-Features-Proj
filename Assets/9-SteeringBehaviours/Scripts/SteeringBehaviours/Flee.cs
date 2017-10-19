using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GGL;

namespace AI {

    public class Flee : SteeringBehaviour {

        public float stoppingDistance = 1f;

        public Transform target;

        public override Vector3 GetForce() {

            Vector3 force = Vector3.zero;

            if (target == null) {

                return force;
            }

            //Let desiredForce = target position - transform position
            Vector3 desiredForce = transform.position - target.position;

            //If desiredForce magnitude > stoppingDistance
            if (desiredForce.magnitude > stoppingDistance) {

                //desiredForce = desiredForce normalized x weighting
                desiredForce = desiredForce.normalized * weighting;

                //force = desiredForce - owner.velocity
                force = desiredForce - owner.velocity;

            }

            #region GizmosGL

            //GizmosGL.color = Color.green;
            GizmosGL.AddLine(transform.position, transform.position + force, .2f, .2f, Color.green, Color.green);

            // GizmosGL.color = Color.red;
            GizmosGL.AddLine(transform.position, transform.position + desiredForce, .2f, .2f, Color.red, Color.red);

            #endregion

            //return force
            return force;
        }
    }
}