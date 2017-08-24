using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Functions { 

    public class Shooting : MonoBehaviour {
        
        //stores the object we want to instantiate
        public GameObject projectilePrefab;

        //speed at which the the projectile will be flung
        public float projectileSpeed = 20f;
        //Rate of Fire
        public float shootRate = 0.1f;


        //Timer to count up to shootrate
        private float shootTimer = 0f;

        //Container for Rigidbody 2d
        private Rigidbody2D rigid;


	    // Use this for initialization
	    void Start () {

            //get rigidbody component
            rigid = GetComponent<Rigidbody2D>();
	    }
	
	    // Update is called once per frame
	    void Update () {

            shootTimer += Time.deltaTime;

            if (Input.GetKey(KeyCode.Space) && shootTimer >= shootRate) {

                Shoot();

                shootTimer = 0f;

                print("Firing Main Cannon -- Recharging: " + shootTimer);
            }
	    }

        void Shoot() {

            //instamtiate clone of projectile prefab
            GameObject projectileClone = Instantiate(projectilePrefab);

            //set position of clone
            projectileClone.transform.position = transform.position;

            //get the clones rigidbody
            Rigidbody2D cloneRB = projectileClone.GetComponent<Rigidbody2D>();

            //the projectile clone gets... projected
            cloneRB.AddForce(transform.right * 20, ForceMode2D.Impulse);

            //recoil on the player
            rigid.AddForce(-transform.right, ForceMode2D.Impulse);
        }
    }
}