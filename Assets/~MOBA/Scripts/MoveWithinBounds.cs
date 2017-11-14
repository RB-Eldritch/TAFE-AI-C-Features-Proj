using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA {
    public class MoveWithinBounds : MonoBehaviour {

        public float movementSpeed = 20f;
        public float zoomSensitivity = 10f;
        public CameraBounds bounds;

        // Use this for initialization
        void Start() {


        }

        // Update is called once per frame
        void Update() {

            Vector3 pos = transform.position;

            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");

            Vector3 inputDir = new Vector3(inputH, 0, inputV);
            pos += inputDir * movementSpeed * Time.deltaTime;

            float inputScroll = Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
            Vector3 scrollDir = transform.forward * inputScroll;
            pos += scrollDir;

            pos = bounds.GetAdjustedPos(pos);
            transform.position = pos;
        }
    }
}
