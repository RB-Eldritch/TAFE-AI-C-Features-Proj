using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense {
    public class AIAgentSpawner : MonoBehaviour {

        public GameObject aiAgentPrefab;
        public Transform target;
        public float spawnRate = 1f;
        public float spawnRadius = 1f;

        // Use this for initialization
        void Start() {

            InvokeRepeating("Spawn", 0, spawnRate);
        }

        // Update is called once per frame
        void Update() {


        }

        void OnDrawGizmos() {

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        void Spawn() {

            GameObject clone = Instantiate(aiAgentPrefab);
            Vector3 rand = Random.insideUnitSphere;
            rand.y = 0;
            clone.transform.position = transform.position + rand * spawnRadius;
            AIAgent aiAgent = clone.GetComponent<AIAgent>();
            aiAgent.target = target;
        }
    }
}
