using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance {
    public class Splodey : Enemy {

        [Header("Splodey")]
        public float splosionRadius = 5f;
        public float splosionRate = 3f;
        public float impactForce = 10f;

        public GameObject splosionParticles;

        private float splosionTimer = 0f;
        
        protected override void Update() {

            base.Update();

            splosionTimer += Time.deltaTime;
        }
        protected override void OnAttackEnd() {

            //IF splosionTimer < splosion Rate
            if (splosionTimer > splosionRate) {

                //Call Splode()
                Splode();
                //destroy self
                Destroy(this.gameObject);
            }
        }

        void Splode() {

            //perform Physics Overlapsphere with splosionRadius
            Collider[] hits = Physics.OverlapSphere(transform.position, splosionRadius);

            //Loop through all Hits
            foreach (Collider hit in hits) {

                Health h = hit.GetComponent<Health>();
                //Rigidbody r = GetComponent<Rigidbody>();

                //IF player
                if (h != null) {

                    h.TakeDamage(damage);
                }

                Rigidbody r = hit.GetComponent<Rigidbody>();

                if (r != null) {

                    //add impact force to rigidbody
                    //--rigid.AddExplosionForce(impactForce, transform.position, splosionRadius, 1, ForceMode.Impulse);
                    r.AddExplosionForce(impactForce, transform.position, splosionRadius, .1f, ForceMode.Impulse);
                }
            }            
        }
    }
}