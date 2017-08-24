using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Classes { 

    public class EnemySpawner : MonoBehaviour {

        public GameObject enemyPrefab;

        public float spawnRate = 1f;
        public float spawnRadius = 5f;
        public float force = 300;

	    // Use this for initialization
	    void Start() {

            //InvokeRepeating(functionName, time, repeatRate);
                //time = delay for when function is called the first time
                //RepeatRate = how often the function is called

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

            //instantiate gameobject
            GameObject enemyClone = Instantiate(enemyPrefab);
            //set position to random... position
            enemyClone.transform.position = Random.insideUnitCircle * spawnRadius;
            //apply force to rigidbody randomly
            Rigidbody2D rigid2D = enemyClone.GetComponent<Rigidbody2D>();
            rigid2D.AddForce(Random.insideUnitCircle * force);
        }
    }
}