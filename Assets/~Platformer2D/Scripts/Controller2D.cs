using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D {

    [RequireComponent(typeof(Rigidbody2D))]
    public class Controller2D : MonoBehaviour {

        public float accelerate = 20f;
        public float jumpHeight = 10f;
        public float rayDistance = 1f;
        public bool isGrounded = false;

        public LayerMask hitLayers;

        private Rigidbody2D rigid2D;

        // Use this for initialization
        void Start() {

            rigid2D = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate() {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, rayDistance, hitLayers);

            if (hit.collider != null) {

                isGrounded = true;
            }
            else {

                isGrounded = false;
            }
        }

        public void Move(float inputH) {

            rigid2D.AddForce(transform.right * inputH * accelerate);
        }

        public void Jump() {

            rigid2D.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        }

        void OnDrawGizmos() {

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + -transform.up * rayDistance);
        }
    }
}
