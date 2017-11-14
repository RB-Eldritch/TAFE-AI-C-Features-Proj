using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperMarioClone {

    [RequireComponent(typeof(PlayerController))]
    public class Mario : MonoBehaviour {

        public float rayDistance;

        private PlayerController pC;
        private Ray stompRay;


        void Awake() {

            pC = GetComponent<PlayerController>();
        }

        // Update is called once per frame
        void Update() {

            CheckStomp();
        }

        void OnDrawGizmos() {

            RecalculateRay();
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(stompRay.origin, stompRay.origin + stompRay.direction * rayDistance);
        }

        void RecalculateRay() {

            stompRay = new Ray(transform.position, Vector3.down);
        }

        void CheckStomp() {

            RaycastHit hit;

            if (Physics.Raycast(stompRay, out hit, rayDistance)) {

                Enemy e = hit.collider.GetComponent<Enemy>();

                if (e != null) {

                    e.Damage();
                }

            }
        }
    }
}
