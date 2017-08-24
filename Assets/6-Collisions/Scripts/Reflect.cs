using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collisions { 

    public class Reflect : MonoBehaviour {

        private Rigidbody2D rigid;

	    // Use this for initialization
	    void Start () {

            rigid = GetComponent<Rigidbody2D>();
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        void OnCollisionEnter2D(Collision2D other) {

            //input direction for reflect function
            Vector3 inDirection = rigid.velocity.normalized;

            //contact information with cillision
            ContactPoint2D contact = other.contacts[0];

            //input normal of the contact's surface
            Vector3 inNormal = contact.normal;
            
            //reflection vector pointing in the direction we want to go
            Vector3 reflect = Vector3.Reflect(inDirection, inNormal);

            //newly calculated force from reflection
            Vector3 newForce = reflect * rigid.velocity.magnitude;

            //replace velocity on object with reflection direction
            rigid.velocity = newForce;

            print(rigid.velocity);
        }
    }
}
