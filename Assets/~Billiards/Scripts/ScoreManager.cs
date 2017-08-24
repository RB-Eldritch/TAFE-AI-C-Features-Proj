using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Billiards {
    public class ScoreManager : MonoBehaviour {

        public int score;
        public Text scoreText;

        public Text gameOverText;

        // Use this for initialization
        void Start() {

            scoreText.text = "Score: " + score;
            gameOverText.text = "";
        }

        // Update is called once per frame
        void Update() {

        }

        void OnCollisionEnter(Collision other) {

            int otherInt;

            if (int.TryParse(other.gameObject.name, out otherInt)) {

                score++;
            }
            else{

                gameOverText.text = "Game Over";
            }

            Destroy(other.gameObject);
        }
    }
}