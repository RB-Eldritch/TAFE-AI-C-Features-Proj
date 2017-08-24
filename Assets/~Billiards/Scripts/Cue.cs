using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards {
    public class Cue : MonoBehaviour {

        public float minPower = 0f; //min power which maps to the distance
        public float maxPower = 80f; //max powet which maps to the distance
        public float maxDistance = 5f; //max distance in units that the cue can be dragged back
        public Ball targetBall; //target ball selected (should be Cue Ball, unless your cheating...)

        private float hitPower; //final calculated hit power to fire the ball
        private Vector3 aimDir; // the aim direction the ball should fire
        private Vector3 prevMousePos; //the mouse position obtained when left-clicking
        private Ray mouseRay; // the ray of the mouse

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

            //check if left mouse button is pressed
            if (Input.GetMouseButtonDown(0)) {

                //store the click position as the prevmousepos
                prevMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            //check if left mouse button is pressed
            if (Input.GetMouseButton(0)) {

                //perform drag mechanic
                Drag();
            }
            else {

                Aim();
            }

            //check if left mouse button is released
            if (Input.GetMouseButtonUp(0)) {

                //hit the ball
                Fire();
            }
        }

        //helps visualise the mouse ray and direction of fire
        private void OnDrawGizmos() {

            Gizmos.DrawLine(mouseRay.origin, mouseRay.origin + mouseRay.direction * 1000f);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(targetBall.transform.position, targetBall.transform.position + aimDir * hitPower);
        }

        void Aim() {

            //calculate mouse ray before performing raycast
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            //raycast hit container for the hit information
            RaycastHit hit;

            if (Physics.Raycast(mouseRay, out hit)) {

                // obtain direction from the cue's position to the raycast's hit point
                Vector3 dir = transform.position - hit.point;

                //convert direction to angle in degrees
                float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

                //rotate towards that angle
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

                //position cue to the ball's position
                transform.position = targetBall.transform.position;
            }
        }

        //activates the cue
        public void Activate() {

            Aim();
            gameObject.SetActive(true);
        }

        //deactivates cue
        public void Deactivate() {

            gameObject.SetActive(false);
        }

        void Drag() {

            //store target ball's position in smaller variables
            Vector3 targetPos = targetBall.transform.position;

            //get mouse position in world units
            Vector3 currMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //calculate distance from previous mous position to the current mnouse position
            float distance = Vector3.Distance(prevMousePos, currMousePos);

            //clamp the distance between 0 - maxDistance
            distance = Mathf.Clamp(distance, 0, maxDistance);

            //calculate a percentage for the distance
            float distPercentage = distance / maxDistance;

            //use percentage of distance to map to the minPowr - maxpower values
            hitPower = Mathf.Lerp(minPower, maxPower, distPercentage);

            //position the cue back using distance
            transform.position = targetPos - transform.forward * distance;

            //get direction to target ball
            aimDir = (targetPos - transform.position).normalized;
        }

        //fires off the ball
        void Fire() {

            //hit the ball with direction and power
            targetBall.Hit(aimDir, hitPower);

            //deactivate the cue when done
            Deactivate();
        }
    }
}