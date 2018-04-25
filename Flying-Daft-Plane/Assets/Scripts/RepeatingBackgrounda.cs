using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

	// Use this for initialization
	void Start () {
        // po dodaniu box collidera automatycznie przejmuje szerokość obiektu
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
	}
	// Update is called once per frame
	void Update ()
    {

        // przenoszenie tła
        if(transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
        }
	}
    private void RepositionBackground()
    {
        // ustaw pozycje obiektu na aktualną + offset
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
