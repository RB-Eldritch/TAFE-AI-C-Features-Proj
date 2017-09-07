using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D {
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour {

        //store x and y coordinate in array for later use
        public int x = 0;
        public int y = 0;

        public bool isMine = false; //is the current tile a mine?
        public bool isRevealed = false; //has the tile already been revealed

        [Header("References")]
        public Sprite[] emptySprite; // list of empty sprites i.e, empty, 1, 2, 3, 4, 
        public Sprite[] mineSprite; //the mine sprites

        private SpriteRenderer rend; //reference to sprite renderer


        void Awake() {

            rend = GetComponent<SpriteRenderer>();
        }


        void Start() {

            isMine = Random.value < .05f;
        }

        // Update is called once per frame
        void Update() {


        }

        public void Reveal(int adjacentMines, int mineState = 0) {

            isRevealed = true;

            if (isMine) {

                rend.sprite = mineSprite[mineState];
            }
            else {

                rend.sprite = emptySprite[adjacentMines];
            }
        }
    }
}
