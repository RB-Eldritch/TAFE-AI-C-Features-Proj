using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour {

    public int spawnAmount = 500;

    public float printTime = 2f;
    public float spawnRadius = 5f;
    public float frequency = 3f;
    public float amplitude = 6f;

    public string message = "Lorem Ipsum, dolore sit amet";

    public GameObject[] spawnPrefabs;


    private float timer = 0f;

	// Use this for initialization
	void Start () {

        //SpawnObjects();
        SpawnObjectsWithSine();
	}
	
	// Update is called once per frame
	void Update () {

        while (timer <= printTime) {

            timer += Time.deltaTime;
            print(message);
        }
    }

    void OnDrawGizmos() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    void SpawnObjects() {

        for (int i = 0; i < spawnAmount; i++) {

            GameObject clone = Instantiate(spawnPrefabs[0]);
            Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
            randomPos.z = 0;
            clone.transform.position = randomPos;
        }
    }

    void SpawnObjectsWithSine() {

        for (int i = 0; i < spawnAmount; i++) {

            int randomIndex = Random.Range(0, spawnPrefabs.Length);
            GameObject randomPrefab = spawnPrefabs[randomIndex];
            GameObject clone = Instantiate(randomPrefab);

            //GameObject clone = Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Length)]);

            Renderer cloneRend = clone.GetComponent<Renderer>();
            float r = Random.Range(0, 2);
            float g = Random.Range(0, 2);
            float b = Random.Range(0, 2);
            cloneRend.material.color = new Color(r, g, b);
            float x = Mathf.Sin(i * frequency) * amplitude;
            float y = i;
            float z = 0;
            Vector3 randomPos = transform.position + new Vector3(x, y, z);
            randomPos.z = 0;
            clone.transform.position = randomPos;
        }
    }
    
}
