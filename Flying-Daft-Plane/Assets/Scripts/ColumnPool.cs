using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public float spawnRate = 2f;
    public int columnPoolSize = 5;
    public float columnYMin = -7f;
    public float columnYMax = 1f;

    private float timeSinceLastSpawn;
    private float spawnXPos = 17f;
    private int currentColumn = 0;

    public GameObject columnPrefab;

    private GameObject[] columns;

    // początkowa pozycja pojawienia się kolumn
    private Vector2 objectPoolPosition = new Vector2(10, -7f);

	// Use this for initialization
	void Start () {
        columns = new GameObject[columnPoolSize];

        // tworzymy 5 kolumn 
        for(int i=0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawn += Time.deltaTime;

        if(!GameControl.Instance.isGameOver && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;

            //losowa wysokość kolumn
            float spawnYPos = Random.Range(columnYMin, columnYMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPos, spawnYPos);

            currentColumn++;

            // gdy obecna kolumna jest po za zasięgiem ustaw numer kolumny na zero
            if (currentColumn >= columnPoolSize) { currentColumn = 0; }
        }
	}
}
