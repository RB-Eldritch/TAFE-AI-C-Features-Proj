using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout {
    public class Ball : MonoBehaviour {

        public float speed = 25f;

        public GameManager gameManager;

        private Vector3 velocity;

        // Use this for initialization
        void Start() {

            
        }

        // Update is called once per frame
        void Update() {

            transform.position += velocity * Time.deltaTime;
        }

        public void Fire(Vector3 direction) {

            velocity = direction * speed;
        }

        void OnCollisionEnter2D(Collision2D other) {

            ContactPoint2D contact = other.contacts[0];

            //calculate reflect using velocity and normal
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);

            //redirectin the velocity to direction
            velocity = reflect.normalized * velocity.magnitude;

            if (other.gameObject.tag == "Box") {

                Destroy(other.gameObject);
                gameManager.score++;
            }
        }
    }
}