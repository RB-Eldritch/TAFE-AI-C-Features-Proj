﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Recursion {

    public class RecursiveSpawner : MonoBehaviour {

        public GameObject spawnPrefab;
        public int amount = 10;
        public float positionOffset;

        [Range(0, 1)]
        public float scalePercentage = 0.2f;

        // Use this for initialization
        void Start() {

            Vector3 position = transform.position;
            Vector3 scale = spawnPrefab.transform.localScale;

            RecursiveSpawn(amount, position, scale);
        }

        // Update is called once per frame
        void Update() {


        }

        void RecursiveSpawn(int currentAmount, Vector3 position, Vector3 scale) {

            Vector3 adjustedScale = scale * (1 - scalePercentage);
            Vector3 adjustedPos = position + Vector3.up * (adjustedScale.magnitude * positionOffset);

            GameObject clone = Instantiate(spawnPrefab);
            clone.transform.position = adjustedPos;
            clone.transform.localScale = adjustedScale;

            amount--;

            if (amount <= 0) {

                return;
            }

            RecursiveSpawn(amount, adjustedPos, adjustedScale);
        }
    }
}
