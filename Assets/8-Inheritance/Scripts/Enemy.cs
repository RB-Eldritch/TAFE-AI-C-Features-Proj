using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Inheritance {
    public class Enemy : MonoBehaviour {

        [Header("Enemy")]
        public int health = 100;
        public int damage = 20;

        public float attackRate = .5f;
        public float attackRange = 2f;

        public Transform target;


        private float attackTimer = 0f;

        private Rigidbody rigid;

        private NavMeshAgent nav;

        void Awake() {

            rigid = GetComponent<Rigidbody>();
            nav = GetComponent<NavMeshAgent>();
        }

        // Use this for initialization
        void Start() {


        }

        // Update is called once per frame
        void Update() {

            attackTimer += Time.deltaTime;

            //get distance between this and target, ie enemy and player
            float distance = Vector3.Distance(transform.position, target.position);

            //if the distance is not further that the attack range
            if (distance < attackRange) {

                Attack();

                attackTimer = 0f;
            }

            if (target != null) {

                nav.SetDestination(target.position);
            }
        }

        public virtual void Attack() {

            print("geeeeeet dunked on!");
        }
    }
}