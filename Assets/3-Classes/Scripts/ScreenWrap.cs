using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script depends on the SpriteRenderer component attached to the same GameObject


namespace Classes {

    [RequireComponent(typeof(SpriteRenderer))]
    public class ScreenWrap : MonoBehaviour {

        private SpriteRenderer spriteRenderer;

        private Bounds camBounds;

        private float camWidth;
        private float camHeight;

        // Use this for initialization
        void Start() {


        }

        // Update is called once per frame
        void Update() {


        }

        void Awake() {

            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        //use LateUpdate since we are using the camera to wrap objects back around
        void LateUpdate() {

            UpdateCameraBounds();

            //store position ad size in shorter variable names
            Vector3 pos = transform.position;
            Vector3 size = spriteRenderer.bounds.size;

            //calculate the sprites half width and height
            float halfWidth = size.x / 2f;
            float halfHeight = size.y / 2f;
            //float halfCamWidth = camWidth / 2f;
            // float halfCamHeight = camHeight / 2f;

            //check left
            if (pos.x + halfWidth < camBounds.min.x) {

                pos.x = camBounds.max.x + halfWidth;
            }
            //check right
            if (pos.x - halfWidth > camBounds.max.x) {

                pos.x = camBounds.min.x - halfWidth;
            }
            //check top
            if (pos.y - halfHeight > camBounds.max.y) {

                pos.y = camBounds.min.y - halfHeight;
            }
            //check bottom
            if (pos.y + halfHeight < camBounds.min.y) {

                pos.y = camBounds.max.y + halfHeight;
            }

            //set new position
            transform.position = pos;
        }

        void UpdateCameraBounds() {

            //Calculate camera bounds
            Camera cam = Camera.main;
            camHeight = 2f * cam.orthographicSize;
            camWidth = camHeight * cam.aspect;
            camBounds = new Bounds(cam.transform.position, new Vector2(camWidth, camHeight));
        }
    }
}
