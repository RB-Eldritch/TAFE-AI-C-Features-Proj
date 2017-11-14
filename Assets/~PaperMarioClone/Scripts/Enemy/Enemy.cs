using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperMarioClone {

    [RequireComponent(typeof(BoxCollider))]
    public class Enemy : MonoBehaviour {

        public float movementSpeed = 4f;
        public float rayDistance = 1.2f;

        public enum MovementDirection {

            IDLE,
            LEFT,
            RIGHT
        }

        public MovementDirection moveDir;

        private BoxCollider box;
        private Ray leftRay, rightRay;

        void Awake() {

            box = GetComponent<BoxCollider>();
        }

        // Update is called once per frame
        public virtual void Update() {

            Move();
        }

        void OnDrawGizmos() {

            box = GetComponent<BoxCollider>();
            RecalculateRays();

            Gizmos.color = Color.red;
            Gizmos.DrawLine(leftRay.origin, leftRay.origin + leftRay.direction * rayDistance);
            Gizmos.DrawLine(rightRay.origin, rightRay.origin + rightRay.direction * rayDistance);
        }

        void RecalculateRays() {

            Vector3 halfSize = box.bounds.size * .5f;
            Vector3 leftPos = transform.position - Vector3.left * halfSize.x;
            Vector3 rightPos = transform.position - Vector3.right * halfSize.x;

            leftRay = new Ray(leftPos, Vector3.down);
            rightRay = new Ray(rightPos, Vector3.down);
        }

        void Move() {

            RecalculateRays();

            Vector3 pos = transform.position;

            bool isLeftHitting = Physics.Raycast(leftRay, rayDistance);
            bool isRightHitting = Physics.Raycast(rightRay, rayDistance);

            if (isLeftHitting && !isRightHitting)
                moveDir = MovementDirection.RIGHT;
            else if (isRightHitting && !isLeftHitting)
                moveDir = MovementDirection.LEFT;


            Vector3 dir = Vector3.zero;

            switch (moveDir) {

                case MovementDirection.IDLE:
                    break;

                case MovementDirection.LEFT:
                    dir += Vector3.left;
                    break;

                case MovementDirection.RIGHT:
                    dir += Vector3.right;
                    break;

                default:
                    break;
            }


            pos += dir * movementSpeed * Time.deltaTime;

            transform.position = pos;
        }

        public virtual void Damage(int combo = 0) {}
    }
}
