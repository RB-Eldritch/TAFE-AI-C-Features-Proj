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
        
        public override void Attack() {
            
            //start to ignite
            //IF splosionTimer < splosion Rate
                //Call Splode()
        }

        void Splode() {

            //perform Physics Overlapsphere with splosionRadius
                //Loop through all Hits
                    //IF player
                        //add impact force to rigidbody

            //destroy self
        }
    }
}