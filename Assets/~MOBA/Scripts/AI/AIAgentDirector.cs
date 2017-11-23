using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using GGL;

namespace MOBA {

    [RequireComponent(typeof(Camera))]
    public class AIAgentDirector : MonoBehaviour {

        public LayerMask hitLayers;
        public float rayDist = 1000f;
        public AIAgent[] agentsToDirect;

        private Camera cam;
        private Transform selectionPoint;

        // Use this for initialization
        void Start() {

            cam = GetComponent<Camera>();
            GameObject g = new GameObject("Target Location");
            selectionPoint = g.transform;
        }

        // Update is called once per frame
        void Update() {

            if (Input.GetMouseButtonDown(0)) {

                Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit rayHit;

                if (Physics.Raycast(camRay, out rayHit, rayDist, hitLayers)) {

                    NavMeshHit navHit;

                    if (NavMesh.SamplePosition(rayHit.point, out navHit, rayDist, -1)) {

                        selectionPoint.position = navHit.position;

                        AssignTargetToAllAgents(selectionPoint);
                    }
                }
            }
        }

        void AssignTargetToAllAgents(Transform target) {

            foreach (var agent in agentsToDirect) {

                Seek s = agent.GetComponent<Seek>();

                if (s != null) {

                    s.target = target;
                }

                PathFollowing p = agent.GetComponent<PathFollowing>();

                if (p != null) {

                    p.target = target;
                }
            }
        }
    }
}