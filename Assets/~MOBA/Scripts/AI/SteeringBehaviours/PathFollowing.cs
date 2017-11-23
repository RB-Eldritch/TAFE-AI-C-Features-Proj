using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using GGL;

namespace MOBA {
    public class PathFollowing : SteeringBehaviour {

        public Transform target;
        public float nodeRadius = .1f;
        public float targetRadius = 3f;

        private int currentNode = 0;
        private bool isAtTarget = false;
        private NavMeshAgent nav;
        private NavMeshPath path;

        private void Start() {

            nav = GetComponent<NavMeshAgent>();
            path = new NavMeshPath();
        }

        void Update() {

            if (path != null) {

                Vector3[] corners = path.corners;

                if (corners.Length > 0) {

                    Vector3 targetPos = corners[corners.Length - 1];

                    GizmosGL.color = Color.cyan;
                    GizmosGL.AddSphere(targetPos, targetRadius);

                    float distance = Vector3.Distance(transform.position, targetPos);

                    if (distance >= targetRadius) {

                        GizmosGL.color = Color.magenta;

                        for (int i = 0; i < corners.Length - 1; i++) {

                            Vector3 nodeA = corners[i];
                            Vector3 nodeB = corners[i + 1];
                            GizmosGL.AddLine(nodeA, nodeB, .1f, .1f);
                            GizmosGL.AddSphere(nodeB, 1f);

                            GizmosGL.color = Color.red;
                        }
                    }
                }
            }
        }

        Vector3 Seek(Vector3 target) {

            Vector3 force = Vector3.zero;

            Vector3 desiredForce = target - transform.position;

            float distance = isAtTarget ? targetRadius : nodeRadius;

            if (desiredForce.magnitude > distance) {

                desiredForce = desiredForce.normalized * weighting;
                force = desiredForce - owner.velocity;
            }

            return force;
        }

        public override Vector3 GetForce() {

            Vector3 force = Vector3.zero;

            if (target == null)
                return force;

            if (nav.CalculatePath(target.position, path)) {

                if (path.status == NavMeshPathStatus.PathComplete) {

                    Vector3[] corners = path.corners;

                    if (corners.Length > 0) {

                        int lastIndex = corners.Length - 1;

                        if (currentNode >= corners.Length) {

                            currentNode = corners.Length - 1;
                        }

                        Vector3 currentPos = corners[currentNode];

                        float distance = Vector3.Distance(transform.position, currentPos);

                        if (distance <= nodeRadius) {

                            currentNode++;
                        }

                        // Is the agent at the target?
                        float distanceToTarget = Vector3.Distance(transform.position, target.position);
                        isAtTarget = distanceToTarget <= targetRadius;

                        // Seek towards current node's position
                        force = Seek(currentPos);
                    }
                }
            }

            return force;
        }
    }
}