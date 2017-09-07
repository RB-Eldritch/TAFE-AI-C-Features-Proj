using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefence {

    [RequireComponent(typeof(NavMeshAgent))]
    public class AIAgent : MonoBehaviour {

        public Transform target;
        private NavMeshAgent navMeshAgent;


        // Use this for initialization
        void Awake() {

            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update() {

            //if target is not null
            if (target != null) {

                //set destination to target pos
                navMeshAgent.SetDestination(target.position);
            }
        }
    }
}