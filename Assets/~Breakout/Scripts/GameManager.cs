using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout {

    public class GameManager : MonoBehaviour {

        public int width = 20;
        public int height = 13;

        public Vector2 spacing = new Vector2(25f, 25f);
        public Vector2 offset = new Vector2(25f, 10f);

        public GameObject[] blockPrefabs;

        [Header("Debug")]

        public bool isDebugging = false;


        private GameObject[,] spawnedBlocks;

        // Use this for initialization
        void Start() {

            GenerateBlocks();
        }

        // Update is called once per frame
        void Update() {

            if (isDebugging) {

                UpdateBlock();
            }
        }

        //Finding array object by index number using an argument
        GameObject GetBlockByIndex(int index) {

            if (index > blockPrefabs.Length || index < 0) {

                return null;
            }

            GameObject clone = Instantiate(blockPrefabs[index]);
            return clone;
        }

        GameObject GetRandomBlock() {

            int randomIndex = Random.Range(0, blockPrefabs.Length);
            GameObject randomPrefab = blockPrefabs[randomIndex];
            GameObject clone = Instantiate(randomPrefab);
            return clone;
        }

        void GenerateBlocks() {

            spawnedBlocks = new GameObject[width, height];
            for (int x = 0; x < width; x++) {

                for (int y = 0; y < height; y++) {

                    GameObject blockClone = GetRandomBlock();
                    Vector3 pos = new Vector3(x, y, 0);
                    blockClone.transform.position = pos;

                    //add block to 2d array
                    spawnedBlocks[x, y] = blockClone;
                }
            }
        }

        void UpdateBlock() {

            for (int x = 0; x < width; x++) {

                for (int y = 0; y < height; y++) {

                    Vector2 pos = new Vector2(x * spacing.x, y * spacing.y);
                    pos += offset;
                    GameObject currentBlock = spawnedBlocks[x, y];
                    currentBlock.transform.position = pos;
                }
            }
        }
    }
}

