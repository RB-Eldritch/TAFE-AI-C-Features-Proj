using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA {
    public class CameraBounds : MonoBehaviour {

        public Vector3 size = new Vector3(80f, 0f, 50f);

        // Use this for initialization
        void Start() {


        }

        // Update is called once per frame
        void Update() {


        }

        void OnDrawGizmosSelected() {

            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, size);
        }

        public Vector3 GetAdjustedPos(Vector3 incomingPos) {

            Vector3 pos = transform.position;
            Vector3 halfSize = size * .5f;

            if (incomingPos.z > pos.z + halfSize.z) {

                incomingPos.z = pos.z + halfSize.z;
            }

            if (incomingPos.z < pos.z - halfSize.z) {

                incomingPos.z = pos.z - halfSize.z;
            }

            if (incomingPos.x > pos.x + halfSize.x) {

                incomingPos.x = pos.x + halfSize.x;
            }

            if (incomingPos.x < pos.x - halfSize.x) {

                incomingPos.x = pos.x - halfSize.x;
            }

            if (incomingPos.y > pos.y + halfSize.y) {

                incomingPos.y = pos.y + halfSize.y;
            }

            if (incomingPos.y < pos.y - halfSize.y) {

                incomingPos.y = pos.y - halfSize.y;
            }

            return incomingPos;
        }
    }
}
