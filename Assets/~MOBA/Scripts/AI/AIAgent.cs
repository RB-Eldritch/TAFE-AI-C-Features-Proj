using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace MOBA
{
    public class AIAgent : MonoBehaviour {

        public float maxSpeed = 10f;
        public float maxDist = 5f;

        public bool updatePos = true;
        public bool updateRot = true;

        [HideInInspector]
        public Vector3 velocity;


        private Vector3 force;
        private List<SteeringBehaviour> behaviours;
        private NavMeshAgent nav;

        void Awake() {

            nav = GetComponent<NavMeshAgent>();
            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
        }

        void Update() {

            nav.updatePosition = updatePos;
            nav.updateRotation = updateRot;
            ComputeForces();
            ApplyVelocity();
        }

        void ComputeForces() {

            force = Vector3.zero;

            for (int i = 0; i < behaviours.Count; i++) {

                SteeringBehaviour b = behaviours[i];

                if (!b.isActiveAndEnabled) {

                    continue;
                }

                force += b.GetForce() * b.weighting;

                if (force.magnitude > maxSpeed) {

                    force = force.normalized * maxSpeed;

                    break;
                }
            }
        }

        void ApplyVelocity() {

            velocity += force * Time.deltaTime;

            nav.speed = velocity.magnitude;

            if (velocity.magnitude > 0) {

                if (velocity.magnitude > maxSpeed) {

                    velocity = velocity.normalized * maxSpeed;
                }
            }

            Vector3 pos = transform.position + velocity;

            NavMeshHit navHit;
            if (NavMesh.SamplePosition(pos, out navHit, maxDist, -1)) {

                nav.SetDestination(navHit.position);
            }       
        }
    }
}