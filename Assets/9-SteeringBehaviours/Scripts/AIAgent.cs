using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI {

    public class AIAgent : MonoBehaviour {

        public Vector3 force;
        public Vector3 velocity;
        public float maxVelocity = 100f;
        public float maxDistance;
        public bool freezeRotation = false;

        private NavMeshAgent nav;
        private List<SteeringBehaviour> behaviours;



        // Use this for initialization
        void Start() {

            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
        }

        // Update is called once per frame
        void Update() {

            ComputeForce();
            ApplyVelocity();
        }

        void ComputeForce() {

            //SET force = Vector3.zero
            force = Vector3.zero;

            //FOR i := 0 to behaviour count
            for (int i = 0; i < behaviours.Count; i++) {

                //LET Behaviour = behaviours[i]
                SteeringBehaviour behaviour = behaviours[i];

                //IF behaviour.setactive == false
                if (behaviour.isActiveAndEnabled == false) {

                    //continue
                    continue;
                }

                //SET force = force + behaviour.GetForce() x weighting
                force += behaviour.GetForce() * behaviour.weighting;

                //IF force.magnitude > maxVelocity
                if (force.magnitude < maxVelocity) {

                    //SET force = force.normalized x maxVelocity
                    force = force.normalized * maxVelocity;

                    //break
                    break;
                }
            }


        }

        void ApplyVelocity() {

            //SET velocity = velocity + force x deltaTime
            velocity = velocity + force * Time.deltaTime;

            //IF velocity.magnitude > maxVelocity
            if (velocity.magnitude > maxVelocity) {

                //SET velocity = velocity.normalized x maxVelocity
                velocity = velocity.normalized * maxVelocity;
            }

            //IF velocity.magnitude > 0
            if (velocity.magnitude > 0) {

                //SET transform.position = transform.position + velocity x deltaTime
                transform.position += velocity * Time.deltaTime;

                //SET transform.rotation = Quaternion LookRotation (velocity)
                transform.rotation = Quaternion.LookRotation(velocity);
            }
        }
    }
}