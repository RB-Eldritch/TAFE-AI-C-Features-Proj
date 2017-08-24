using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class KeepWithinScreen : MonoBehaviour {

    private Renderer rend;
    private Camera cam;
    private Bounds camBounds;
    private float camWidth, camHeight;


	// Use this for initialization
	void Start () {

        //set cam to main camera
        cam = Camera.main;

        //get renderer component
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

        UpdateCamBounds();

        transform.position = CheckBounds();
	}

    void UpdateCamBounds() {

        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        camBounds = new Bounds(cam.transform.position, new Vector3(camWidth, camHeight));
    }

    Vector3 CheckBounds() {

        Vector3 pos = transform.position;
        Vector3 size = rend.bounds.size;
        float halfWidth = size.x * .5f;
        float halfHeight = size.y * .5f;

        //check left
        if (pos.x - halfWidth < camBounds.min.x) {

            pos.x = camBounds.min.x + halfWidth;
        }

        //check right
        if (pos.x + halfWidth > camBounds.max.x) {

            pos.x = camBounds.max.x - halfWidth;
        }

        //check down
        if (pos.y - halfWidth < camBounds.min.y) {

            pos.y = camBounds.min.y + halfHeight;
        }

        //check up
        if (pos.y + halfWidth > camBounds.max.y) {

            pos.y = camBounds.max.y - halfHeight;
        }

        return pos;
    }
}
