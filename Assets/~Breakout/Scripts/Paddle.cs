using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout {
    public class Paddle : MonoBehaviour {

        public float movementSpeed = 25f;
        public Ball currentBall;
        public bool isFired = false;

        public Vector3[] directions = new Vector3[] { new Vector3(.5f, .5f), new Vector3(-.5f, .5f) };

        // Use this for initialization
        void Start() {

            currentBall = GetComponentInChildren<Ball>();
        }

        // Update is called once per frame
        void Update() {

            CheckInput();
            Movement();
        }

        void Fire() {

            //detach children
            currentBall.transform.SetParent(null);

            //randomly select a direction
            Vector3 randomDir = directions[Random.Range(0, directions.Length)];

            //fire off the ball in the random direction
            currentBall.Fire(randomDir);
        }

        void CheckInput() {

            if (Input.GetKeyDown(KeyCode.Space) && isFired == false) {

                Fire();
                isFired = true;
            }
        }

        void Movement() {

            //get input axis horizontal
            float inputH = Input.GetAxis("Horizontal");

            //create force in direction
            Vector3 force = transform.right * inputH;

            //apply movementSpeed to force
            force *= movementSpeed;

            //apply deltatime to force
            force *= Time.deltaTime;

            transform.position += force;
        }
    }
}