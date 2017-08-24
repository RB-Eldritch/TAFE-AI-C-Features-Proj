﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class VisualiseBounds : MonoBehaviour {

    private Renderer rend;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmos() {

        rend = GetComponent<Renderer>();
        Gizmos.DrawWireCube(transform.position, rend.bounds.size);
    }
}
