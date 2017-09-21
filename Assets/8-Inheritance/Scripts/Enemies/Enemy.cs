using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Inheritance {

    public class Enemy : MonoBehaviour {

        [Header("Base Enemy")]

        public float damage = 50;
        public float speed = 20;
        public float attackDuration = .5f;
        public float attackRange = 2f;
        public Transform target;

        private float attackTimer = 0f;
        private float attackRate = 5f;

        protected Rigidbody rigid;
        protected NavMeshAgent nav;

        void Awake() {

            nav = GetComponent<NavMeshAgent>();
            rigid = GetComponent<Rigidbody>();
        }

        protected virtual void Attack() { }
        protected virtual void OnAttackEnd() { }

        IEnumerator AttackDelay(float delay) {

            nav.Stop();

            yield return new WaitForSeconds(delay);

            nav.Resume();
            OnAttackEnd();
        }

        void Start() {


        }

        protected virtual void Update() {

            //set nav destination
            nav.SetDestination(target.position);

            //increase attack timer
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackRate) {

                //get distance to target
                float distance = Vector3.Distance(transform.position, target.position);

                if (distance <= attackRange) {

                    StartCoroutine(AttackDelay(attackDuration));
                    Attack();
                    attackTimer = 0f;
                }
            }
        }
    }
}