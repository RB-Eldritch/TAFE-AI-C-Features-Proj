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
        public float attackDuration = 1f;

        public Transform target;

        protected Rigidbody rigid;
        protected NavMeshAgent nav;

        private float attackTimer = 0f;

        

        protected virtual void Awake() {

            rigid = GetComponent<Rigidbody>();
            nav = GetComponent<NavMeshAgent>();
        }

        // Use this for initialization
        void Start() {


        }

        // Update is called once per frame
        protected virtual void Update() {

            if (target == null) {

                return;
            }

            nav.SetDestination(target.position);

            attackTimer += Time.deltaTime;

            if (attackTimer >= attackRate) {

                //get distance between this and target, ie enemy and player
                float distance = Vector3.Distance(transform.position, target.position);

                //if the distance is not further that the attack range
                if (distance < attackRange) {

                    Attack();

                    attackTimer = 0f;

                    StartCoroutine(AttackDelay(attackRate));
                }
            }

            nav.SetDestination(target.position);
        }

        protected virtual void Attack() {

            
        }

        protected virtual void OnAttackEnd() {


        }

        IEnumerator AttackDelay(float delay) {

            //stop navigation
            nav.Stop();

            yield return new WaitForSeconds(delay);

            if (nav.isOnNavMesh) {

                //resume navigation
                nav.Resume();
            }

            //Call OnAttackEnd()
            OnAttackEnd();
        }
    }
}