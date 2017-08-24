using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Variables {

    public class RigidMovement : MonoBehaviour {

        public float movementSpeed = 20f;
        public float rotationSpeed = 100f;
        public float deceleration = 5f;

        private Rigidbody2D rigid2D;

	    // Use this for initialization
	    void Start () {

            rigid2D = GetComponent<Rigidbody2D>();
	    }
	
	    // Update is called once per frame
	    void Update () {

            Movement();
            Rotation();
	    }

        void Movement() {

            float inputV = Input.GetAxis("Vertical");
            rigid2D.AddForce(transform.right * inputV * movementSpeed);
            rigid2D.velocity += -rigid2D.velocity * deceleration * Time.deltaTime;
        }

        void Rotation() {

            float inputH = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.back * inputH * rotationSpeed * Time.deltaTime);
        }
    }
}